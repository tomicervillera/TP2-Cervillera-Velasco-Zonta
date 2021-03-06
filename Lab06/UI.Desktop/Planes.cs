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
    public partial class Planes : Form
    {
        #region Métodos
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

            DataGridViewTextBoxColumn colIdEspecialidad = new DataGridViewTextBoxColumn();
            colIdEspecialidad.Name = "idEspecialidad";
            colIdEspecialidad.HeaderText = "ID Especialidad";
            colIdEspecialidad.DataPropertyName = "idEspecialidad";
            colIdEspecialidad.DisplayIndex = 2;
            this.dgvPlanes.Columns.Add(colIdEspecialidad);

        }
        public void Listar()
        {
            PlanLogic pl = new PlanLogic();
            try
            {
                this.dgvPlanes.DataSource = pl.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de planes.", Ex);
                MessageBox.Show(Ex.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void ValidateUser()
        {
            //Espacio para futura implementación
        }
        #endregion
        #region Eventos
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
        private void Planes_Shown(object sender, EventArgs e)
        {
            ValidateUser();
        }
        #endregion
    }
}
