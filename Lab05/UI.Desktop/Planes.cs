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
    public partial class Planes : Form
    {
        //Constructor
        public Planes()
        {
            InitializeComponent();
            GenerarColumnas();
        }

        //Métodos
        private void GenerarColumnas()
        {
            this.dgvPlanes.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.Name = "id";
            colID.HeaderText = "ID";
            colID.DataPropertyName = "ID";
            colID.DisplayIndex = 0;
            this.dgvPlanes.Columns.Add(colID);

            DataGridViewTextBoxColumn colDescripcion = new DataGridViewTextBoxColumn();
            colDescripcion.Name = "descripcion";
            colDescripcion.HeaderText = "Descripcion";
            colDescripcion.DataPropertyName = "Descripcion";
            colDescripcion.DisplayIndex = 1;
            this.dgvPlanes.Columns.Add(colDescripcion);

        }
        public void Listar()
        {
            PlanLogic el = new PlanLogic();
            this.dgvPlanes.DataSource = el.GetAll();
        }

        //Eventos
        private void Planes_Load(object sender, EventArgs e)
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
            PlanDesktop formPlan = new PlanDesktop(ApplicationForm.ModoForm.Alta);
            formPlan.ShowDialog();
            this.Listar();
        }
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
            PlanDesktop formPlan = new PlanDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formPlan.ShowDialog();
            this.Listar();
        }
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Está seguro de que desea eliminar esta plan? ", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                new PlanLogic().Delete(ID);
                this.Listar();
            }
        }
    }
}
