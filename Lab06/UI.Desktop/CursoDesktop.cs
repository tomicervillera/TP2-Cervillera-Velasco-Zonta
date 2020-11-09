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
    public partial class CursoDesktop : ApplicationForm
    {
        #region Miembros
        private Business.Entities.Curso _CursoActual;
        public Business.Entities.Curso CursoActual { get => _CursoActual; set => _CursoActual = value; }
        #endregion

        #region Métodos
        //Constructores
        public CursoDesktop()
        {
            InitializeComponent();
        }
        public CursoDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            ComisionLogic cl = new ComisionLogic();
            cboxComision.DataSource = cl.GetAll();
            cboxComision.ValueMember = "ID";
            cboxComision.DisplayMember = "Descripcion";

            MateriaLogic ml = new MateriaLogic();
            cboxMateria.DataSource = ml.GetAll();
            cboxMateria.ValueMember = "ID";
            cboxMateria.DisplayMember = "Descripcion";
        }
        public CursoDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            CursoActual = new CursoLogic().GetOne(ID);
            MapearDeDatos();
        }

        //Funciones
        public override void MapearDeDatos()
        {
            txtID.Text = CursoActual.ID.ToString();
            txtAnioCalendario.Text = CursoActual.AnioCalendario.ToString();
            txtCupo.Text= CursoActual.Cupo.ToString();

            ComisionLogic cl = new ComisionLogic();
            cboxComision.DataSource = cl.GetAll();
            cboxComision.ValueMember = "ID";
            cboxComision.DisplayMember = "Descripcion";
            cboxComision.SelectedValue = cl.GetOne(CursoActual.IDComision).ID;

            MateriaLogic ml = new MateriaLogic();
            cboxMateria.DataSource = ml.GetAll();
            cboxMateria.ValueMember = "ID";
            cboxMateria.DisplayMember = "Descripcion";
            cboxMateria.SelectedValue = ml.GetOne(CursoActual.IDMateria).ID;

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
                CursoActual = new Business.Entities.Curso();
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                CursoActual.AnioCalendario = Convert.ToInt32(txtAnioCalendario.Text);
                CursoActual.Cupo = Convert.ToInt32(txtCupo.Text);

                CursoActual.IDComision = Convert.ToInt32(((Comision)cboxComision.SelectedItem).ID);
                CursoActual.IDMateria = Convert.ToInt32(((Materia)cboxMateria.SelectedItem).ID);

                switch (Modo)
                {
                    case ModoForm.Alta:
                        {
                            CursoActual.State = BusinessEntity.States.New;
                            break;
                        }
                    case ModoForm.Modificacion:
                        {
                            CursoActual.State = BusinessEntity.States.Modified;
                            break;
                        }
                    case ModoForm.Consulta:
                        {
                            CursoActual.State = BusinessEntity.States.Unmodified;
                            break;
                        }
                    case ModoForm.Baja:
                        {
                            CursoActual.State = BusinessEntity.States.Deleted;
                            break;
                        }
                }
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            new CursoLogic().Save(CursoActual);
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
        private void txtCupo_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtCupo.Text) == true)
            {
                e.Cancel = true;
                errorProviderCurso.SetError(txtCupo, "El cupo no debe estar vacío.");
            }
            else if (int.TryParse(txtCupo.Text, out int result) == false)
            {
                e.Cancel = true;
                errorProviderCurso.SetError(txtCupo, "Sólo se permiten cupos numéricos.");
            }
            else if (!(Convert.ToInt32(txtCupo.Text) >= 0 && Convert.ToInt32(txtCupo.Text) <= 500))
            {
                e.Cancel = true;
                errorProviderCurso.SetError(txtCupo, "Inserte un número de cupo válido.");
            }
            else
            {
                errorProviderCurso.SetError(txtCupo, null);
            }
        }
        private void txtAnioCalendario_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtAnioCalendario.Text) == true)
            {
                e.Cancel = true;
                errorProviderCurso.SetError(txtAnioCalendario, "El año calendario no debe estar vacío.");
            }
            else if (int.TryParse(txtAnioCalendario.Text, out int result) == false)
            {
                e.Cancel = true;
                errorProviderCurso.SetError(txtAnioCalendario, "Sólo se permiten años numéricos.");
            }
            else if (!(Convert.ToInt32(txtAnioCalendario.Text) >= 1000 && Convert.ToInt32(txtAnioCalendario.Text) <= 9999))
            {
                e.Cancel = true;
                errorProviderCurso.SetError(txtAnioCalendario, "Inserte un año de 4 dígitos válido.");
            }
            else
            {
                errorProviderCurso.SetError(txtAnioCalendario, null);
            }
        }
        #endregion
    }
}
