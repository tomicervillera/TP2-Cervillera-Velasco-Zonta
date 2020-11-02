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
    public partial class PlanesReporte : Form
    {
        public PlanesReporte()
        {
            InitializeComponent();
        }

        private void PlanesReporte_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'AcademiaDataSet.planes' table. You can move, or remove it, as needed.
            this.planesTableAdapter.Fill(this.AcademiaDataSet.planes);

            this.repViewerPlanes.RefreshReport();
        }
    }
}
