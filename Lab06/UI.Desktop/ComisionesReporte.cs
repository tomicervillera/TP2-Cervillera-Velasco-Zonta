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
    public partial class ComisionesReporte : Form
    {
        public ComisionesReporte()
        {
            InitializeComponent();
        }

        private void ComisionesReporte_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'AcademiaDataSet.comisiones' table. You can move, or remove it, as needed.
            this.comisionesTableAdapter.Fill(this.AcademiaDataSet.comisiones);

            this.repViewerComisiones.RefreshReport();
        }
    }
}
