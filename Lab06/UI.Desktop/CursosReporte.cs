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
    public partial class CursosReporte : Form
    {
        public CursosReporte()
        {
            InitializeComponent();
        }

        private void CursosReporte_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'AcademiaDataSet.cursos' table. You can move, or remove it, as needed.
            this.cursosTableAdapter.Fill(this.AcademiaDataSet.cursos);

            this.repViewerCursos.RefreshReport();
        }
    }
}
