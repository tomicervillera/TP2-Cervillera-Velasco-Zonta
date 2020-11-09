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
        #region Miembros
        private Business.Entities.Materia _MateriaActual;
        public Business.Entities.Materia MateriaActual { get => _MateriaActual; set => _MateriaActual = value; }
        #endregion

        #region Metodos
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
            MapearDeDatos();
        }

        //Funciones
        public override void MapearDeDatos()
        {
            txtID.Text = MateriaActual.ID.ToString();
            txtDescripcion.Text = MateriaActual.Descripcion;
            txtHSSemanales.Text = MateriaActual.HSSemanales.ToString();
            txtHSTotales.Text = MateriaActual.HSTotales.ToString();
            
            PlanLogic pl = new PlanLogic();
            cboxIDPlan.DataSource = pl.GetAll();
            cboxIDPlan.ValueMember = "ID";
            cboxIDPlan.DisplayMember = "Descripcion";
            cboxIDPlan.SelectedValue = MateriaActual.IDPlan;

            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                btAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Baja)
            {
                btAceptar.Text = "Eliminar";
            }
            else if (Modo == ModoForm.Consulta)
            {
                btAceptar.Text = "Aceptar";
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
                MateriaActual.Descripcion = txtDescripcion.Text;
                MateriaActual.IDPlan = Convert.ToInt32(((Plan)cboxIDPlan.SelectedItem).ID);
                MateriaActual.HSSemanales = Convert.ToInt32(txtHSSemanales.Text);
                MateriaActual.HSTotales = Convert.ToInt32(txtHSTotales.Text);

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
        #endregion

        #region Eventos
        private void btAceptar_Click(object sender, EventArgs e)
        {
            if (ValidateChildren() == true)
            {
                GuardarCambios();
                Close();
            }
        }
        private void btCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void txtHSTotales_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtHSTotales.Text) == true)
            {
                e.Cancel = true;
                errorProviderMateria.SetError(txtHSTotales, "Las horas totales no deben estar vacías.");
            }
            else if (int.TryParse(txtHSTotales.Text, out int result) == false)
            {
                errorProviderMateria.SetError(txtHSTotales, "Sólo se permite un valor numérico.");
                e.Cancel = true;
            }
            else if (!(Convert.ToInt32(txtHSTotales.Text) > 0 && Convert.ToInt32(txtHSTotales.Text) <= 100))
            {
                errorProviderMateria.SetError(txtHSTotales, "Inserte un valor de horas válido.");
                e.Cancel = true;
            }
            else
            {
                errorProviderMateria.SetError(txtHSTotales, null);
            }
        }
        private void txtDescripcion_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtDescripcion.Text) == true)
            {
                e.Cancel = true;
                errorProviderMateria.SetError(txtDescripcion, "La descripción no debe estar vacía.");
            }
            else
            {
                errorProviderMateria.SetError(txtDescripcion, null);
            }
        }
        private void txtHSSemanales_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtHSSemanales.Text) == true)
            {
                e.Cancel = true;
                errorProviderMateria.SetError(txtHSSemanales, "Las horas semanales no deben estar vacías.");
            }
            else if (int.TryParse(txtHSSemanales.Text, out int result) == false)
            {
                errorProviderMateria.SetError(txtHSSemanales, "Sólo se permite un valor numérico.");
                e.Cancel = true;
            }
            else if (!(Convert.ToInt32(txtHSSemanales.Text) > 0 && Convert.ToInt32(txtHSSemanales.Text) <= 100))
            {
                errorProviderMateria.SetError(txtHSSemanales, "Inserte un valor de horas válido.");
                e.Cancel = true;
            }
            else
            {
                errorProviderMateria.SetError(txtHSSemanales, null);
            }
        }
        #endregion
    }
}
