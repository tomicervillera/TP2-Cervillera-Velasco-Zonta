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
    public partial class Cursos : Form
    {
        //Constructor
        public Cursos()
        {
            InitializeComponent();
            GenerarColumnas();
        }

        //Métodos
        private void GenerarColumnas()
        {
            this.dgvCursos.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.Name = "id";
            colID.HeaderText = "ID";
            colID.DataPropertyName = "ID";
            colID.DisplayIndex = 0;
            this.dgvCursos.Columns.Add(colID);

            DataGridViewTextBoxColumn colIDComision = new DataGridViewTextBoxColumn();
            colIDComision.Name = "idComision";
            colIDComision.HeaderText = "ID Comisión";
            colIDComision.DataPropertyName = "IDComision";
            colIDComision.DisplayIndex = 1;
            this.dgvCursos.Columns.Add(colIDComision);

            DataGridViewTextBoxColumn colIDMateria = new DataGridViewTextBoxColumn();
            colIDMateria.Name = "idMateria";
            colIDMateria.HeaderText = "ID Materia";
            colIDMateria.DataPropertyName = "IDMateria";
            colIDMateria.DisplayIndex = 2;
            this.dgvCursos.Columns.Add(colIDMateria);

            DataGridViewTextBoxColumn colAnioCalendario = new DataGridViewTextBoxColumn();
            colAnioCalendario.Name = "anioCalendario";
            colAnioCalendario.HeaderText = "Año Calendario";
            colAnioCalendario.DataPropertyName = "AnioCalendario";
            colAnioCalendario.DisplayIndex = 3;
            this.dgvCursos.Columns.Add(colAnioCalendario);

            DataGridViewTextBoxColumn colCupo = new DataGridViewTextBoxColumn();
            colCupo.Name = "cupo";
            colCupo.HeaderText = "Cupo";
            colCupo.DataPropertyName = "cupo";
            colCupo.DisplayIndex = 4;
            this.dgvCursos.Columns.Add(colCupo);

        }
        public void Listar()
        {
            CursoLogic cur = new CursoLogic();
            try
            {
                this.dgvCursos.DataSource = cur.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos.", Ex);
                MessageBox.Show(Ex.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        //Eventos
        private void Cursos_Load(object sender, EventArgs e)
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
            CursoDesktop formCurso = new CursoDesktop(ApplicationForm.ModoForm.Alta);
            formCurso.ShowDialog();
            this.Listar();
        }
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
            CursoDesktop formCurso = new CursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formCurso.ShowDialog();
            this.Listar();
        }
        private void tsbEliminar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Está seguro de que desea eliminar este curso? ", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int ID = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                new CursoLogic().Delete(ID);
                this.Listar();
            }
        }

    }
}


