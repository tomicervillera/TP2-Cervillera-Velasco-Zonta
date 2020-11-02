using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class AlumnosInscripcionesReporte : Form
    {
        #region Miembros

        #endregion

        #region Métodos
        public AlumnosInscripcionesReporte()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        private void AlumnosInscripcionesReporte_Load(object sender, EventArgs e)
        {
            alumnos_inscripcionesTableAdapter.Fill(AcademiaDataSet.alumnos_inscripciones);
            repViewInscripciones.RefreshReport();
        }
        #endregion
    }
}
