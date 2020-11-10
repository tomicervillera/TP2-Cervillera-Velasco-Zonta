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
    public partial class AlumnoInscripcionDesktop : ApplicationForm
    {
        #region Miembros
        private Business.Entities.AlumnoInscripcion _AlumnoInscripcionActual;
        public Business.Entities.AlumnoInscripcion AlumnoInscripcionActual { get => _AlumnoInscripcionActual; set => _AlumnoInscripcionActual = value; }
        #endregion

        #region Métodos
        //Constructores
        public AlumnoInscripcionDesktop()
        {
            InitializeComponent();
        }
        public AlumnoInscripcionDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            
            PersonaLogic pl = new PersonaLogic();
            List<Persona> alumnos= new List<Persona>();
            foreach (Persona per in pl.GetAll())
            {
                if (per.TipoPersona == Persona.TipoPersonas.Alumno)
                {
                    alumnos.Add(per);
                }
            }
            cboxAlumno.DataSource = alumnos;
            cboxAlumno.ValueMember = "ID";
            cboxAlumno.DisplayMember = "Legajo";

            CursoLogic cl = new CursoLogic();
            cboxCurso.DataSource = cl.GetAll();
            cboxCurso.ValueMember = "ID";
            cboxCurso.DisplayMember = "ID";

            cboxCondicion.SelectedIndex = 0;
        }
        public AlumnoInscripcionDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            AlumnoInscripcionActual = new AlumnoInscripcionLogic().GetOne(ID);
            MapearDeDatos();
        }

        //Funciones
        private void ValidateUser()
        {

        }
        public override void MapearDeDatos()
        {
            txtID.Text = AlumnoInscripcionActual.ID.ToString();
            txtNota.Text = AlumnoInscripcionActual.Nota.ToString();
            cboxCondicion.SelectedItem = AlumnoInscripcionActual.Condicion;

            PersonaLogic pl = new PersonaLogic();
            List<Persona> alumnos = new List<Persona>();
            foreach (Persona per in pl.GetAll())
            {
                if (per.TipoPersona == Persona.TipoPersonas.Alumno)
                {
                    alumnos.Add(per);
                }
            }
            cboxAlumno.DataSource = alumnos;
            cboxAlumno.ValueMember = "ID";
            cboxAlumno.DisplayMember = "Legajo";
            cboxAlumno.SelectedValue = pl.GetOne(AlumnoInscripcionActual.IDAlumno).ID;

            CursoLogic cl = new CursoLogic();
            cboxCurso.DataSource = cl.GetAll();
            cboxCurso.ValueMember = "ID";
            cboxCurso.DisplayMember = "ID";
            cboxCurso.SelectedValue = cl.GetOne(AlumnoInscripcionActual.IDCurso).ID;

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
                AlumnoInscripcionActual = new Business.Entities.AlumnoInscripcion();
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                AlumnoInscripcionActual.Condicion = (string)cboxCondicion.SelectedItem;
                if (string.IsNullOrEmpty(txtNota.Text))
                {
                    AlumnoInscripcionActual.Nota = 0;
                }
                else
                {
                    AlumnoInscripcionActual.Nota = Convert.ToInt32(txtNota.Text);
                }
                AlumnoInscripcionActual.IDAlumno = Convert.ToInt32(((Persona)cboxAlumno.SelectedItem).ID);
                AlumnoInscripcionActual.IDCurso = Convert.ToInt32(((Curso)cboxCurso.SelectedItem).ID);

                switch (Modo)
                {
                    case ModoForm.Alta:
                        {
                            AlumnoInscripcionActual.State = BusinessEntity.States.New;
                            break;
                        }
                    case ModoForm.Modificacion:
                        {
                            AlumnoInscripcionActual.State = BusinessEntity.States.Modified;
                            break;
                        }
                    case ModoForm.Consulta:
                        {
                            AlumnoInscripcionActual.State = BusinessEntity.States.Unmodified;
                            break;
                        }
                    case ModoForm.Baja:
                        {
                            AlumnoInscripcionActual.State = BusinessEntity.States.Deleted;
                            break;
                        }
                }
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            new AlumnoInscripcionLogic().Save(AlumnoInscripcionActual);
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
        private void txtNota_Validating(object sender, CancelEventArgs e)
        {
            if (cboxCondicion.SelectedIndex == 0 && string.IsNullOrEmpty(txtNota.Text) == false)
            {
                errorProviderAlumnoInscripcion.SetError(txtNota, "Los alumnos libres no deben llevar nota.");
                e.Cancel = true;
            }
            else if (cboxCondicion.SelectedIndex != 0 && string.IsNullOrEmpty(txtNota.Text) == true)
            {
                errorProviderAlumnoInscripcion.SetError(txtNota, "Los alumnos regulares o aprobados deben llevar nota.");
                e.Cancel = true;
            }
            else if (cboxCondicion.SelectedIndex != 0 && int.TryParse(txtNota.Text, out int result) == false)
            {
                errorProviderAlumnoInscripcion.SetError(txtNota, "Sólo se permiten notas numéricas.");
                e.Cancel = true;
            }
            else if (cboxCondicion.SelectedIndex != 0 && !(Convert.ToInt32(txtNota.Text) >= 5 && Convert.ToInt32(txtNota.Text) <= 10))
            {
                errorProviderAlumnoInscripcion.SetError(txtNota, "Los alumnos regulares/aprobados deben tener nota igual o superior a 5.");
                e.Cancel = true;
            }
            else
            {
                errorProviderAlumnoInscripcion.SetError(txtNota, null);
            }

        }
        private void AlumnoInscripcionDesktop_Load(object sender, EventArgs e)
        {
            AlumnosInscripciones formAlIn = ((AlumnosInscripciones)Owner);
            if (((formMain)((AlumnosInscripciones)Owner).Owner).PersonaActiva.TipoPersona == Persona.TipoPersonas.Alumno)
            {
                lblCondicion.Visible = false;
                cboxCondicion.Visible = false;

                lblNota.Visible = false;
                txtNota.Visible = false;

                cboxAlumno.SelectedValue = ((formMain)((AlumnosInscripciones)Owner).Owner).PersonaActiva.ID;
                cboxAlumno.Enabled = false;
            }
            else if (((formMain)((AlumnosInscripciones)Owner).Owner).PersonaActiva.TipoPersona == Persona.TipoPersonas.Docente)
            {
                cboxAlumno.Enabled = false;
                cboxCurso.Enabled = false;
            }
        }
        #endregion
    }
}