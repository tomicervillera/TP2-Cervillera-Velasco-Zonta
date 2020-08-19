using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class ComisionDesktop : ApplicationForm
    {
        //Propiedades
        private Business.Entities.Comision _ComisionActual;
        public Business.Entities.Comision ComisionActual { get => _ComisionActual; set => _ComisionActual = value; }

        //Constructores
        public ComisionDesktop()
        {
            InitializeComponent();
        }
        public ComisionDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            PlanLogic cl =new PlanLogic();
            cmbIDPlan.DataSource = cl.GetAll();
            cmbIDPlan.ValueMember = "ID";
            cmbIDPlan.DisplayMember = "Descripcion";
            


        }
        public ComisionDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            ComisionActual = new ComisionLogic().GetOne(ID);
            MapearDeDatos();
        }

        //Métodos
        public override void MapearDeDatos()
        {
            //this.txtID.Text = this.ComisionActual.ID.ToString();
            this.txtDescripcion.Text = this.ComisionActual.Descripcion;
            this.txtAñoEspecialidad.Text = this.ComisionActual.AnioEspecialidad.ToString();
           
            PlanLogic el = new PlanLogic();
            cmbIDPlan.DataSource = el.GetAll();
            cmbIDPlan.ValueMember = "ID";
            cmbIDPlan.DisplayMember = "Descripcion";
            cmbIDPlan.SelectedValue = this.ComisionActual.IDPlan;
             

            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }
            else if (Modo == ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }

        }
        public override void MapearADatos()
        {

            if (Modo == ModoForm.Alta)
            {
                ComisionActual = new Business.Entities.Comision();
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                
                ComisionActual.AnioEspecialidad = Convert.ToInt32(txtAñoEspecialidad.Text);
                ComisionActual.Descripcion = txtDescripcion.Text;
                ComisionActual.IDPlan = Convert.ToInt32(((Business.Entities.Plan)cmbIDPlan.SelectedItem).ID);

                switch (Modo)
                {
                    case ModoForm.Alta:
                        {
                            ComisionActual.State = BusinessEntity.States.New;
                            break;
                        }
                    case ModoForm.Modificacion:
                        {
                            ComisionActual.State = BusinessEntity.States.Modified;
                            break;
                        }
                    case ModoForm.Consulta:
                        {
                            ComisionActual.State = BusinessEntity.States.Unmodified;
                            break;
                        }
                    case ModoForm.Baja:
                        {
                            ComisionActual.State = BusinessEntity.States.Deleted;
                            break;
                        }
                }
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            new ComisionLogic().Save(ComisionActual);
        }
        public override bool Validar()
        {
            foreach (Control oControls in this.tableLayoutPanel1.Controls) // Buscamos en cada TextBox de nuestro Formulario.
            {
                if (oControls is TextBox & oControls.Text == String.Empty & oControls.Name != "txtID") // Verificamos que no este vacio exceptuando al txtID porque se asigna automáticamente.
                {
                    Notificar("Hay al menos un campo vacío. Por favor, completelo/s. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return (false);
                }
            }
            return (true);
        }

        //Eventos
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbIDEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
