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
        #region Miembros
        private Business.Entities.Comision _ComisionActual;
        public Business.Entities.Comision ComisionActual { get => _ComisionActual; set => _ComisionActual = value; }
        #endregion

        #region Métodos
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

        //Funciones
        public override void MapearDeDatos()
        {
            txtID.Text = ComisionActual.ID.ToString();
            txtDescripcion.Text = ComisionActual.Descripcion;
            txtAñoEspecialidad.Text = ComisionActual.AnioEspecialidad.ToString();
           
            PlanLogic el = new PlanLogic();
            cmbIDPlan.DataSource = el.GetAll();
            cmbIDPlan.ValueMember = "ID";
            cmbIDPlan.DisplayMember = "Descripcion";
            cmbIDPlan.SelectedValue = ComisionActual.IDPlan;

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
        private void txtAñoEspecialidad_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtAñoEspecialidad.Text) == true)
            {
                e.Cancel = true;
                errorProviderComision.SetError(txtAñoEspecialidad, "El año de especialidad no debe estar vacío.");
            }
            else if (int.TryParse(txtAñoEspecialidad.Text, out int result) == false)
            {
                errorProviderComision.SetError(txtAñoEspecialidad, "Sólo se permiten años numéricos.");
                e.Cancel = true;
            }
            else if (!(Convert.ToInt32(txtAñoEspecialidad.Text) >= 1000 && Convert.ToInt32(txtAñoEspecialidad.Text) <= 9999 ))
            {
                errorProviderComision.SetError(txtAñoEspecialidad, "Inserte un año de 4 dígitos válido.");
                e.Cancel = true;
            }
            else
            {
                errorProviderComision.SetError(txtAñoEspecialidad, null);
            }
        }
        private void txtDescripcion_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtDescripcion.Text) == true)
            {
                e.Cancel = true;
                errorProviderComision.SetError(txtDescripcion, "La descripción no debe estar vacía.");
            }
            else
            {
                errorProviderComision.SetError(txtDescripcion, null);
            }
        }
        #endregion
    }
}
