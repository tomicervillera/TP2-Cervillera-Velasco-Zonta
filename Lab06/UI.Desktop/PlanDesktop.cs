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
        #region Métodos
        private Business.Entities.Plan _PlanActual;
        public Business.Entities.Plan PlanActual { get => _PlanActual; set => _PlanActual = value; }
        #endregion

        #region Métodos
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

        //Funciones
        public override void MapearDeDatos()
        {
            txtID.Text = PlanActual.ID.ToString();
            txtDescripcion.Text = PlanActual.Descripcion;

            EspecialidadLogic el = new EspecialidadLogic();
            cboxEspecialidad.DataSource = el.GetAll();
            cboxEspecialidad.ValueMember = "ID";
            cboxEspecialidad.DisplayMember = "Descripcion";
            cboxEspecialidad.SelectedValue = el.GetOne(PlanActual.IdEspecialidad).ID;

            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Baja)
            {
                btnAceptar.Text = "Eliminar";
            }
            else if (Modo == ModoForm.Consulta)
            {
                btnAceptar.Text = "Aceptar";
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
        #endregion

        #region Eventos
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidateChildren() == true) 
            {
                GuardarCambios();
                Close();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void txtDescripcion_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtDescripcion.Text) == true)
            {
                e.Cancel = true;
                errorProviderPlan.SetError(txtDescripcion, "La descripción no debe estar vacía.");
            }
            else
            {
                errorProviderPlan.SetError(txtDescripcion, null);
            }
        }
        #endregion
    }
}
