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
    public partial class Especialidades : Form
    {
        //Constructor
        public Especialidades()
        {
            InitializeComponent();
            GenerarColumnas();
        }

        //Métodos
        private void GenerarColumnas()
        {
            this.dgvEspecialidades.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.Name = "id";
            colID.HeaderText = "ID";
            colID.DataPropertyName = "ID";
            colID.DisplayIndex = 0;
            this.dgvEspecialidades.Columns.Add(colID);

            DataGridViewTextBoxColumn colDescripcion = new DataGridViewTextBoxColumn();
            colDescripcion.Name = "descripcion";
            colDescripcion.HeaderText = "Descripcion";
            colDescripcion.DataPropertyName = "Descripcion";
            colDescripcion.DisplayIndex = 1;
            this.dgvEspecialidades.Columns.Add(colDescripcion);

        }
        public void Listar()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            try
            {
                this.dgvEspecialidades.DataSource = el.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de especialidades.", Ex);
                MessageBox.Show(Ex.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        //Eventos
        private void Especialidades_Load(object sender, EventArgs e)
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
            EspecialidadDesktop formEspecialidad = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
            formEspecialidad.ShowDialog();
            this.Listar();
        }
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
            EspecialidadDesktop formEspecialidad = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formEspecialidad.ShowDialog();
            this.Listar();
        }
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Está seguro de que desea eliminar esta especialidad? ", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                new EspecialidadLogic().Delete(ID);
                this.Listar();
            }
        }
    }
}
