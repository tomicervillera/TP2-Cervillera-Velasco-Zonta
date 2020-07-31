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
    public partial class Usuarios : Form
    {
        //Constructor
        public Usuarios()
        {
            InitializeComponent();
            GenerarColumnas();
        }

        //Métodos
        private void GenerarColumnas()
        {
            this.dgvUsuarios.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.Name = "id";
            colID.HeaderText = "ID";
            colID.DataPropertyName = "ID";
            colID.DisplayIndex = 0;
            this.dgvUsuarios.Columns.Add(colID);

            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.DataPropertyName = "Nombre";
            colNombre.DisplayIndex = 1;
            this.dgvUsuarios.Columns.Add(colNombre);

            DataGridViewTextBoxColumn colApellido = new DataGridViewTextBoxColumn();
            colApellido.Name = "apellido";
            colApellido.HeaderText = "Apellido";
            colApellido.DataPropertyName = "Apellido";
            colApellido.DisplayIndex = 2;
            this.dgvUsuarios.Columns.Add(colApellido);

            DataGridViewTextBoxColumn colUsuario = new DataGridViewTextBoxColumn();
            colUsuario.Name = "usuario";
            colUsuario.HeaderText = "Usuario";
            colUsuario.DataPropertyName = "NombreUsuario";
            colUsuario.DisplayIndex = 3;
            this.dgvUsuarios.Columns.Add(colUsuario);

            DataGridViewTextBoxColumn colEmail = new DataGridViewTextBoxColumn();
            colEmail.Name = "email";
            colEmail.HeaderText = "E-Mail";
            colEmail.DataPropertyName = "Email";
            colEmail.DisplayIndex = 4;
            this.dgvUsuarios.Columns.Add(colEmail);

            DataGridViewTextBoxColumn colHabilitado = new DataGridViewTextBoxColumn();
            colHabilitado.Name = "habilitado";
            colHabilitado.HeaderText = "Habilitado";
            colHabilitado.DataPropertyName = "Habilitado";
            colHabilitado.DisplayIndex = 5;
            this.dgvUsuarios.Columns.Add(colHabilitado);
        }
        public void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            try
            {
                this.dgvUsuarios.DataSource = ul.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios.", Ex);
                MessageBox.Show(Ex.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        //Eventos
        private void Usuarios_Load(object sender, EventArgs e)
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
            UsuarioDesktop formUsuario = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            formUsuario.ShowDialog();
            this.Listar();
        }
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            UsuarioDesktop formUsuario = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formUsuario.ShowDialog();
            this.Listar();
        }
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Está seguro de que desea eliminar este usuario? ", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                new UsuarioLogic().Delete(ID);
                this.Listar();
            }
        }
    }
}
