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
    public partial class PersonasReporte : Form
    {
        public PersonasReporte()
        {
            InitializeComponent();
        }

        private void PersonasReporte_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'AcademiaDataSet.personas' table. You can move, or remove it, as needed.
            this.personasTableAdapter.Fill(this.AcademiaDataSet.personas);

            this.repViewerPersonas.RefreshReport();
        }
    }
}
