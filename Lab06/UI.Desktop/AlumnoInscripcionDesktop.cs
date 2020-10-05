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
            txtID.Text = this.AlumnoInscripcionActual.ID.ToString();
            txtNota.Text = this.AlumnoInscripcionActual.Nota.ToString();
            txtCondicion.Text = this.AlumnoInscripcionActual.Condicion;
            
            PersonaLogic pl = new PersonaLogic();
            cboxAlumno.DataSource = pl.GetAll();
            cboxAlumno.ValueMember = "ID";
            cboxAlumno.DisplayMember = "ID";
            cboxAlumno.SelectedValue = pl.GetOne(AlumnoInscripcionActual.IDAlumno).ID;

            CursoLogic cl = new CursoLogic();
            cboxCurso.DataSource = cl.GetAll();
            cboxCurso.ValueMember = "ID";
            cboxCurso.DisplayMember = "Descripcion";
            cboxCurso.SelectedValue = cl.GetOne(AlumnoInscripcionActual.IDCurso).ID;

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
                AlumnoInscripcionActual = new Business.Entities.AlumnoInscripcion();
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                AlumnoInscripcionActual.Condicion = txtCondicion.Text;
                AlumnoInscripcionActual.Nota = Convert.ToInt32(txtNota.Text);
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
        #endregion

        #region Eventos
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
        #endregion
    }
}