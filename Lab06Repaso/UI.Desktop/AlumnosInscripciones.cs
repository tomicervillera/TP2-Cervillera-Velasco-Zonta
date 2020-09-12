﻿using System;
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
    public partial class AlumnosInscripciones : Form
    {
        //Constructor
        public AlumnosInscripciones()
        {
            InitializeComponent();
            GenerarColumnas();
        }

        //Métodos
        private void GenerarColumnas()
        {
            this.dgvAlumnosInscripciones.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.Name = "id";
            colID.HeaderText = "ID";
            colID.DataPropertyName = "ID";
            colID.DisplayIndex = 0;
            this.dgvAlumnosInscripciones.Columns.Add(colID);

            DataGridViewTextBoxColumn colIDAlumno = new DataGridViewTextBoxColumn();
            colIDAlumno.Name = "idAlumno";
            colIDAlumno.HeaderText = "ID Alumno";
            colIDAlumno.DataPropertyName = "IDAlumno";
            colIDAlumno.DisplayIndex = 1;
            this.dgvAlumnosInscripciones.Columns.Add(colIDAlumno);

            DataGridViewTextBoxColumn colIDCurso = new DataGridViewTextBoxColumn();
            colIDCurso.Name = "idCurso";
            colIDCurso.HeaderText = "ID Curso";
            colIDCurso.DataPropertyName = "IDCurso";
            colIDCurso.DisplayIndex = 2;
            this.dgvAlumnosInscripciones.Columns.Add(colIDCurso);

            DataGridViewTextBoxColumn colCondicion = new DataGridViewTextBoxColumn();
            colCondicion.Name = "condicion";
            colCondicion.HeaderText = "Condicion";
            colCondicion.DataPropertyName = "Condicion";
            colCondicion.DisplayIndex = 3;
            this.dgvAlumnosInscripciones.Columns.Add(colCondicion);

            DataGridViewTextBoxColumn colNota = new DataGridViewTextBoxColumn();
            colNota.Name = "nota";
            colNota.HeaderText = "Nota";
            colNota.DataPropertyName = "Nota";
            colNota.DisplayIndex = 4;
            this.dgvAlumnosInscripciones.Columns.Add(colNota);

        }
        public void Listar()
        {
            AlumnoInscripcionLogic alIns = new AlumnoInscripcionLogic();
            try
            {
                this.dgvAlumnosInscripciones.DataSource = alIns.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de inscripciones de alumnos. ", Ex);
                MessageBox.Show(Ex.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        //Eventos
        private void AlumnosInscripciones_Load(object sender, EventArgs e)
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
            AlumnoInscripcionDesktop formAlumnoInscripcion = new AlumnoInscripcionDesktop(ApplicationForm.ModoForm.Alta);
            formAlumnoInscripcion.ShowDialog();
            this.Listar();
        }
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.AlumnoInscripcion)this.dgvAlumnosInscripciones.SelectedRows[0].DataBoundItem).ID;
            AlumnoInscripcionDesktop formAlumnoInscripcion = new AlumnoInscripcionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formAlumnoInscripcion.ShowDialog();
            this.Listar();
        }
        private void tsbEliminar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Está seguro de que desea eliminar esta inscripción de alumno? ", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int ID = ((Business.Entities.AlumnoInscripcion)this.dgvAlumnosInscripciones.SelectedRows[0].DataBoundItem).ID;
                new AlumnoInscripcionLogic().Delete(ID);
                this.Listar();
            }
        }

    }
}
