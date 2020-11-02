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
    public partial class MateriasReporte : Form
    {
        public MateriasReporte()
        {
            InitializeComponent();
        }

        private void MateriasReporte_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'AcademiaDataSet.materias' table. You can move, or remove it, as needed.
            this.materiasTableAdapter.Fill(this.AcademiaDataSet.materias);

            this.reportViewer1.RefreshReport();
        }
    }
}
