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
    public partial class EspecialidadesReporte : Form
    {
        public EspecialidadesReporte()
        {
            InitializeComponent();
        }

        private void EspecialidadesReporte_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'AcademiaDataSet.especialidades' table. You can move, or remove it, as needed.
            this.especialidadesTableAdapter.Fill(this.AcademiaDataSet.especialidades);

            this.repViewerEspecialidades.RefreshReport();
        }
    }
}
