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
    public partial class DocentesCursos : Form
    {
        //Constructor
        public DocentesCursos()
        {
            InitializeComponent();
            GenerarColumnas();
        }

        //Métodos
        private void GenerarColumnas()
        {
            this.dgvDocentesCursos.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.Name = "id";
            colID.HeaderText = "ID";
            colID.DataPropertyName = "ID";
            colID.DisplayIndex = 0;
            this.dgvDocentesCursos.Columns.Add(colID);

            DataGridViewTextBoxColumn colIDCurso = new DataGridViewTextBoxColumn();
            colIDCurso.Name = "idCurso";
            colIDCurso.HeaderText = "ID Curso";
            colIDCurso.DataPropertyName = "IDCurso";
            colIDCurso.DisplayIndex = 1;
            this.dgvDocentesCursos.Columns.Add(colIDCurso);

            DataGridViewTextBoxColumn colIDDocente = new DataGridViewTextBoxColumn();
            colIDDocente.Name = "idDocente";
            colIDDocente.HeaderText = "ID Docente";
            colIDDocente.DataPropertyName = "IDDocente";
            colIDDocente.DisplayIndex = 2;
            this.dgvDocentesCursos.Columns.Add(colIDDocente);

            DataGridViewTextBoxColumn colCargo = new DataGridViewTextBoxColumn();
            colCargo.Name = "cargo";
            colCargo.HeaderText = "Cargo";
            colCargo.DataPropertyName = "Cargo";
            colCargo.DisplayIndex = 3;
            this.dgvDocentesCursos.Columns.Add(colCargo);

        }
        public void Listar()
        {
            DocenteCursoLogic docCur = new DocenteCursoLogic();
            try
            {
                this.dgvDocentesCursos.DataSource = docCur.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de docentes por cursos.", Ex);
                MessageBox.Show(Ex.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        //Eventos
        private void DocentesCursos_Load(object sender, EventArgs e)
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
            DocenteCursoDesktop formDocentesCursos = new DocenteCursoDesktop(ApplicationForm.ModoForm.Alta);
            formDocentesCursos.ShowDialog();
            this.Listar();
        }
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.DocenteCurso)this.dgvDocentesCursos.SelectedRows[0].DataBoundItem).ID;
            DocenteCursoDesktop formDocentesCursos = new DocenteCursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formDocentesCursos.ShowDialog();
            this.Listar();
        }
        private void tsbEliminar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Está seguro de que desea eliminar este docente por curso? ", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int ID = ((Business.Entities.DocenteCurso)this.dgvDocentesCursos.SelectedRows[0].DataBoundItem).ID;
                new DocenteCursoLogic().Delete(ID);
                this.Listar();
            }
        }

    }
}


