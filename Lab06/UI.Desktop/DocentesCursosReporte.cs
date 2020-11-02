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
    public partial class DocentesCursosReporte : Form
    {
        public DocentesCursosReporte()
        {
            InitializeComponent();
        }

        private void DocentesCursosReporte_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'AcademiaDataSet.docentes_cursos' table. You can move, or remove it, as needed.
            this.docentes_cursosTableAdapter.Fill(this.AcademiaDataSet.docentes_cursos);

            this.repViewerDocentesCursos.RefreshReport();
        }
    }
}
