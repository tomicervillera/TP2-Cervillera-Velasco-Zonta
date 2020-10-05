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
    public partial class ModulosUsuarios : Form
    {
        //Constructor
        public ModulosUsuarios()
        {
            InitializeComponent();
            GenerarColumnas();
        }

        //Métodos
        private void GenerarColumnas()
        {
            this.dgvModulosUsuarios.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.Name = "id";
            colID.HeaderText = "ID";
            colID.DataPropertyName = "ID";
            colID.DisplayIndex = 0;
            this.dgvModulosUsuarios.Columns.Add(colID);

            DataGridViewTextBoxColumn colIDModulo = new DataGridViewTextBoxColumn();
            colIDModulo.Name = "idModulo";
            colIDModulo.HeaderText = "ID Modulo";
            colIDModulo.DataPropertyName = "idModulo";
            colIDModulo.DisplayIndex = 1;
            this.dgvModulosUsuarios.Columns.Add(colIDModulo);

            DataGridViewTextBoxColumn colIDUsuario = new DataGridViewTextBoxColumn();
            colIDUsuario.Name = "idUsuario";
            colIDUsuario.HeaderText = "ID Usuario";
            colIDUsuario.DataPropertyName = "idUsuario";
            colIDUsuario.DisplayIndex = 2;
            this.dgvModulosUsuarios.Columns.Add(colIDUsuario);

            DataGridViewCheckBoxColumn colAlta = new DataGridViewCheckBoxColumn();
            colAlta.Name = "alta";
            colAlta.HeaderText = "Alta";
            colAlta.DataPropertyName = "PermiteAlta";
            colAlta.DisplayIndex = 3;
            this.dgvModulosUsuarios.Columns.Add(colAlta);

            DataGridViewCheckBoxColumn colBaja = new DataGridViewCheckBoxColumn();
            colBaja.Name = "baja";
            colBaja.HeaderText = "Baja";
            colBaja.DataPropertyName = "PermiteBaja";
            colBaja.DisplayIndex = 4;
            this.dgvModulosUsuarios.Columns.Add(colBaja);

            DataGridViewCheckBoxColumn colModificacion = new DataGridViewCheckBoxColumn();
            colModificacion.Name = "modificacion";
            colModificacion.HeaderText = "Modificacion";
            colModificacion.DataPropertyName = "PermiteModificacion";
            colModificacion.DisplayIndex = 5;
            this.dgvModulosUsuarios.Columns.Add(colModificacion);

            DataGridViewCheckBoxColumn colConsulta = new DataGridViewCheckBoxColumn();
            colConsulta.Name = "consulta";
            colConsulta.HeaderText = "Consulta";
            colConsulta.DataPropertyName = "PermiteConsulta";
            colConsulta.DisplayIndex = 6;
            this.dgvModulosUsuarios.Columns.Add(colConsulta);

        }
        public void Listar()
        {
            ModuloUsuarioLogic modUs = new ModuloUsuarioLogic();
            try
            {
                this.dgvModulosUsuarios.DataSource = modUs.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de módulos por usuarios.", Ex);
                MessageBox.Show(Ex.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void ValidateUser()
        {
            //Espacio para futura implementación
        }
        //Eventos
        private void ModulosUsuarios_Load(object sender, EventArgs e)
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
            ModuloUsuarioDesktop formModuloUsuario = new ModuloUsuarioDesktop(ApplicationForm.ModoForm.Alta);
            formModuloUsuario.ShowDialog();
            this.Listar();
        }
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.ModuloUsuario)this.dgvModulosUsuarios.SelectedRows[0].DataBoundItem).ID;
            ModuloUsuarioDesktop formModuloUsuario = new ModuloUsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formModuloUsuario.ShowDialog();
            this.Listar();
        }
        private void tsbEliminar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Está seguro de que desea eliminar esta módulo por usuario? ", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int ID = ((Business.Entities.ModuloUsuario)this.dgvModulosUsuarios.SelectedRows[0].DataBoundItem).ID;
                new ModuloUsuarioLogic().Delete(ID);
                this.Listar();
            }
        }

        private void ModulosUsuarios_Shown(object sender, EventArgs e)
        {
            ValidateUser();
        }
    }
}
