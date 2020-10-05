using Business.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class formMain : Form
    {
        #region Miembros
        private Persona _PersonaActiva;
        public Persona PersonaActiva
        {
            get
            {
                return _PersonaActiva;
            }
            set
            {
                _PersonaActiva = value;
            }
        }
        #endregion

        #region Métodos
        public formMain()
        {
            InitializeComponent();
        }
        private void ChangeMenu()
        {
            if (PersonaActiva.TipoPersona == Persona.TipoPersonas.Alumno)
            {
                mnuArchivo.DropDownItems.RemoveByKey("alumnosInscripcionesToolStripMenuItem");
                mnuArchivo.DropDownItems.RemoveByKey("cursosToolStripMenuItem");
                mnuArchivo.DropDownItems.RemoveByKey("docentesCursosToolStripMenuItem");
                mnuArchivo.DropDownItems.RemoveByKey("personasToolStripMenuItem");
                mnuArchivo.DropDownItems.RemoveByKey("planesToolStripMenuItem");
            }
            else if (PersonaActiva.TipoPersona == Persona.TipoPersonas.Docente)
            {
                mnuArchivo.DropDownItems.RemoveByKey("cursosToolStripMenuItem");
                mnuArchivo.DropDownItems.RemoveByKey("personasToolStripMenuItem");
                mnuArchivo.DropDownItems.RemoveByKey("planesToolStripMenuItem");
            }
        }
        #endregion

        #region Eventos
        private void formMain_Shown(object sender, EventArgs e)
        {
            formLogin appLogin = new formLogin();
            if (appLogin.ShowDialog(this) != DialogResult.OK)
            {
                Dispose();
            }
            ChangeMenu();
        }
        private void alumnosInscripcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlumnosInscripciones formAlumnosInscripciones = new AlumnosInscripciones();
            formAlumnosInscripciones.ShowDialog(this);
        }
        private void comisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comisiones formComisiones = new Comisiones();
            formComisiones.ShowDialog(this);
        }
        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Especialidades formEspecialidades = new Especialidades();
            formEspecialidades.ShowDialog(this);
        }
        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Materias formMaterias = new Materias();
            formMaterias.ShowDialog(this);
        }
        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personas formPersonas = new Personas();
            formPersonas.ShowDialog(this);
        }
        private void planesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Planes formPlanes = new Planes();
            formPlanes.ShowDialog(this);
        }
        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursos formCursos = new Cursos();
            formCursos.ShowDialog(this);
        }
        private void docentesCursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocentesCursos formDocentesCursos = new DocentesCursos();
            formDocentesCursos.ShowDialog(this);
        }
        private void mnuSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        #endregion


    }
}
