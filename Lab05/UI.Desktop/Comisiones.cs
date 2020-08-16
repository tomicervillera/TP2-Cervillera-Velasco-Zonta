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
        public partial class Comisiones : Form
        {
            //Constructor
            public Comisiones()
            {
                InitializeComponent();
                GenerarColumnas();
            }

            //Métodos
            private void GenerarColumnas()
            {
                this.dgvComisiones.AutoGenerateColumns = false;

                DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
                colID.Name = "id";
                colID.HeaderText = "ID";
                colID.DataPropertyName = "ID";
                colID.DisplayIndex = 0;
                this.dgvComisiones.Columns.Add(colID);

                DataGridViewTextBoxColumn colDescripcion = new DataGridViewTextBoxColumn();
                colDescripcion.Name = "descripcion";
                colDescripcion.HeaderText = "Descripcion";
                colDescripcion.DataPropertyName = "Descripcion";
                colDescripcion.DisplayIndex = 1;
                this.dgvComisiones.Columns.Add(colDescripcion);

                DataGridViewTextBoxColumn colIdEspecialidad = new DataGridViewTextBoxColumn();
                colIdEspecialidad.Name = "idEspecialidad";
                colIdEspecialidad.HeaderText = "ID Especialidad";
                colIdEspecialidad.DataPropertyName = "idEspecialidad";
                colIdEspecialidad.DisplayIndex = 2;
                this.dgvComisiones.Columns.Add(colIdEspecialidad);

            }
            public void Listar()
            {
                ComisionLogic pl = new ComisionLogic();
                try
                {
                    this.dgvComisiones.DataSource = pl.GetAll();
                }
                catch (Exception Ex)
                {
                    Exception ExcepcionManejada = new Exception("Error al recuperar lista de comisiones.", Ex);
                    MessageBox.Show(Ex.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }

            //Eventos
            private void Comisiones_Load(object sender, EventArgs e)
            {
                Listar();
            }
            private void btnActualizar_Click(object sender, EventArgs e)
            {
                Listar();
            }
            private void btnSalir_Click(object sender, EventArgs e)
            {
                this.Close();
            }
            private void tsbNuevo_Click(object sender, EventArgs e)
            {
                ComisionDesktop formComision = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
                formComision.ShowDialog();
                this.Listar();
            }
            private void tsbEditar_Click(object sender, EventArgs e)
            {
                int ID = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                ComisionDesktop formComision = new ComisionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formComision.ShowDialog();
                this.Listar();
            }
            private void tsbEliminar_Click(object sender, EventArgs e)
            {

                if (MessageBox.Show("Está seguro de que desea eliminar esta comision? ", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int ID = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                    new ComisionLogic().Delete(ID);
                    this.Listar();
                }
            }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ComisionDesktop formComision = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            formComision.ShowDialog();
            this.Listar();

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
            ComisionDesktop formComision = new ComisionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formComision.ShowDialog();
            this.Listar();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro de que desea eliminar esta comision? ", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int ID = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                new ComisionLogic().Delete(ID);
                this.Listar();
            }
        }
    }
    }


