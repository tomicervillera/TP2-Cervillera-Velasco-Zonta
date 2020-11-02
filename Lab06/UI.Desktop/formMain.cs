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

                mnuReportes.Visible = false;
            }
            else if (PersonaActiva.TipoPersona == Persona.TipoPersonas.Docente)
            {
                mnuArchivo.DropDownItems.RemoveByKey("cursosToolStripMenuItem");
                mnuArchivo.DropDownItems.RemoveByKey("personasToolStripMenuItem");
                mnuArchivo.DropDownItems.RemoveByKey("planesToolStripMenuItem");

                mnuReportes.Visible = false;
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
        private void inscripcionesDeAlumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlumnosInscripcionesReporte formInscripcionesReporte = new AlumnosInscripcionesReporte();
            formInscripcionesReporte.ShowDialog();
        }
        private void comisionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ComisionesReporte formComisionesReporte = new ComisionesReporte();
            formComisionesReporte.ShowDialog();
        }
        private void cursosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CursosReporte formCursosReporte = new CursosReporte();
            formCursosReporte.ShowDialog();
        }
        private void docentesCursosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DocentesCursosReporte formDocentesCursosReporte = new DocentesCursosReporte();
            formDocentesCursosReporte.ShowDialog();
        }
        private void especialidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EspecialidadesReporte formEspecialidadesReporte = new EspecialidadesReporte();
            formEspecialidadesReporte.ShowDialog();
        }
        private void materiasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MateriasReporte formMateriasReporte = new MateriasReporte();
            formMateriasReporte.ShowDialog();
        }
        private void personasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PersonasReporte formPersonasReporte = new PersonasReporte();
            formPersonasReporte.ShowDialog();
        }
        private void planesToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            PlanesReporte formPlanesReporte = new PlanesReporte();
            formPlanesReporte.ShowDialog();
        }
        #endregion
    }
}
