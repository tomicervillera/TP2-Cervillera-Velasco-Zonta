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
    public partial class PlanDesktop : ApplicationForm
    {
        //Propiedades
        private Business.Entities.Plan _PlanActual;
        public Business.Entities.Plan PlanActual { get => _PlanActual; set => _PlanActual = value; }

        //Constructores
        public PlanDesktop()
        {
            InitializeComponent();
        }
        public PlanDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            EspecialidadLogic el = new EspecialidadLogic(); 
            cboxEspecialidad.DataSource = el.GetAll();
            cboxEspecialidad.ValueMember = "ID";
            cboxEspecialidad.DisplayMember = "Descripcion";
        }
        public PlanDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            PlanActual = new PlanLogic().GetOne(ID);
            MapearDeDatos();
        }

        //Métodos
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PlanActual.ID.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion;
            EspecialidadLogic el = new EspecialidadLogic();
            cboxEspecialidad.DataSource = el.GetAll();
            cboxEspecialidad.ValueMember = "ID";
            cboxEspecialidad.DisplayMember = "Descripcion";
            cboxEspecialidad.SelectedValue = el.GetOne(PlanActual.IdEspecialidad).ID;

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
                PlanActual = new Business.Entities.Plan();
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                PlanActual.Descripcion = txtDescripcion.Text;
                PlanActual.IdEspecialidad = Convert.ToInt32(((Especialidad)cboxEspecialidad.SelectedItem).ID);

                switch (Modo)
                {
                    case ModoForm.Alta:
                        {
                            PlanActual.State = BusinessEntity.States.New;
                            break;
                        }
                    case ModoForm.Modificacion:
                        {
                            PlanActual.State = BusinessEntity.States.Modified;
                            break;
                        }
                    case ModoForm.Consulta:
                        {
                            PlanActual.State = BusinessEntity.States.Unmodified;
                            break;
                        }
                    case ModoForm.Baja:
                        {
                            PlanActual.State = BusinessEntity.States.Deleted;
                            break;
                        }
                }
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            new PlanLogic().Save(PlanActual);
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

        private void cboxEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
