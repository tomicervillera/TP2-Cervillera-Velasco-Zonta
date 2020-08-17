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
    public partial class MateriaDesktop : ApplicationForm
    {
        //Propiedades
        private Business.Entities.Materia _MateriaActual;
        public Business.Entities.Materia MateriaActual { get => _MateriaActual; set => _MateriaActual = value; }

        //Constructores
        public MateriaDesktop()
        {
            InitializeComponent();
        }
        public MateriaDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            PlanLogic pl = new PlanLogic();
            cboxIDPlan.DataSource = pl.GetAll();
            cboxIDPlan.ValueMember = "ID";
            cboxIDPlan.DisplayMember = "Descripcion";


        }
        public MateriaDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            MateriaActual = new MateriaLogic().GetOne(ID);
            // MessageBox.Show(PersonaActual.TipoPersona.ToString());
            MapearDeDatos();
        }


        //METODOS
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.MateriaActual.ID.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion;
            PlanLogic pl = new PlanLogic();
            /*  cboxPlan.DataSource = pl.GetAll();
              cboxPlan.ValueMember = "ID";
              cboxPlan.DisplayMember = "Descripcion";
              cboxPlan.SelectedValue = pl.GetOne(PersonaActual.IDPlan).ID;*/
            this.txtHSSemanales.Text = this.MateriaActual.HSSemanales.ToString();
            this.txtHSTotales.Text = this.MateriaActual.HSTotales.ToString();
            cboxIDPlan.DataSource = pl.GetAll();
            cboxIDPlan.ValueMember = "ID";
            cboxIDPlan.DisplayMember = "Descripcion";
            cboxIDPlan.SelectedValue = this.MateriaActual.IDPlan;

            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.btAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Baja)
            {
                this.btAceptar.Text = "Eliminar";
            }
            else if (Modo == ModoForm.Consulta)
            {
                this.btAceptar.Text = "Aceptar";
            }

        }
        public override void MapearADatos()
        {

            if (Modo == ModoForm.Alta)
            {
                MateriaActual = new Business.Entities.Materia();
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                // this.PersonaActual.ID = Convert.ToInt32( this.txtID.Text);
                this.MateriaActual.Descripcion = this.txtDescripcion.Text;
                MateriaActual.IDPlan = Convert.ToInt32(((Plan)cboxIDPlan.SelectedItem).ID);
                this.MateriaActual.HSSemanales = Convert.ToInt32( this. txtHSSemanales.Text);
                this.MateriaActual.HSTotales = Convert.ToInt32(this.txtHSTotales.Text);



                switch (Modo)
                {
                    case ModoForm.Alta:
                        {
                            MateriaActual.State = BusinessEntity.States.New;
                            break;
                        }
                    case ModoForm.Modificacion:
                        {
                            MateriaActual.State = BusinessEntity.States.Modified;
                            break;
                        }
                    case ModoForm.Consulta:
                        {
                            MateriaActual.State = BusinessEntity.States.Unmodified;
                            break;
                        }
                    case ModoForm.Baja:
                        {
                            MateriaActual.State = BusinessEntity.States.Deleted;
                            break;
                        }
                }
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            new MateriaLogic().Save(MateriaActual);
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
        
        //EVENTOS
        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
