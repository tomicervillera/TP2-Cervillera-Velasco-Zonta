using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class Materias : Form
    {
        //Constructor
        public Materias()
        {
            InitializeComponent();
            GenerarColumnas();
        }

        //Métodos
        private void GenerarColumnas()
        {
            this.dgvMaterias.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.Name = "id";
            colID.HeaderText = "ID";
            colID.DataPropertyName = "ID";
            colID.DisplayIndex = 0;
            this.dgvMaterias.Columns.Add(colID);

            DataGridViewTextBoxColumn colDescripcion = new DataGridViewTextBoxColumn();
            colDescripcion.Name = "desc_materia";
            colDescripcion.HeaderText = "Descripción";
            colDescripcion.DataPropertyName = "Descripcion";
            colDescripcion.DisplayIndex = 1;
            this.dgvMaterias.Columns.Add(colDescripcion);

            DataGridViewTextBoxColumn colHsSemanales = new DataGridViewTextBoxColumn();
            colHsSemanales.Name = "hs_semanales";
            colHsSemanales.HeaderText = "Horas semanales";
            colHsSemanales.DataPropertyName = "HSSemanales";
            colHsSemanales.DisplayIndex = 2;
            this.dgvMaterias.Columns.Add(colHsSemanales);

            DataGridViewTextBoxColumn colHsTotales = new DataGridViewTextBoxColumn();
            colHsTotales.Name = "hs_totales";
            colHsTotales.HeaderText = "Horas Totales";
            colHsTotales.DataPropertyName = "HSTotales";
            colHsTotales.DisplayIndex = 3;
            this.dgvMaterias.Columns.Add(colHsTotales);

            DataGridViewTextBoxColumn colIdPlan = new DataGridViewTextBoxColumn();
            colIdPlan.Name = "id_plan";
            colIdPlan.HeaderText = "ID Plan";
            colIdPlan.DataPropertyName = "IDPlan";
            colIdPlan.DisplayIndex = 4;
            this.dgvMaterias.Columns.Add(colIdPlan);


        }

        public void Listar()
        {
            MateriaLogic mat = new MateriaLogic();
            try
            {
                this.dgvMaterias.DataSource = mat.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de materias.", Ex);
                MessageBox.Show(Ex.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }


        //eventos

        private void Materias_Load(object sender, EventArgs e)
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
            MateriaDesktop formMateria = new MateriaDesktop(ApplicationForm.ModoForm.Alta);
            formMateria.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
            MateriaDesktop formMateria = new MateriaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formMateria.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro de que desea eliminar esta materia? ", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                new MateriaLogic().Delete(ID);
                this.Listar();
            }
        }


    }
}
