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
    public partial class Personas : Form
    {
        //Constructor
        public Personas()
        {
            InitializeComponent();
            GenerarColumnas();
        }

        //Métodos
        private void GenerarColumnas()
        {
            this.dgvPersonas.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.Name = "id";
            colID.HeaderText = "ID";
            colID.DataPropertyName = "ID";
            colID.DisplayIndex = 0;
            this.dgvPersonas.Columns.Add(colID);

            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.DataPropertyName = "Nombre";
            colNombre.DisplayIndex = 1;
            this.dgvPersonas.Columns.Add(colNombre);

            DataGridViewTextBoxColumn colApellido= new DataGridViewTextBoxColumn();
            colApellido.Name = "apellido";
            colApellido.HeaderText = "Apellido";
            colApellido.DataPropertyName = "Apellido";
            colApellido.DisplayIndex = 2;
            this.dgvPersonas.Columns.Add(colApellido);

            DataGridViewTextBoxColumn colDireccion = new DataGridViewTextBoxColumn();
            colDireccion.Name = "direccion";
            colDireccion.HeaderText = "Dirección";
            colDireccion.DataPropertyName = "Direccion";
            colDireccion.DisplayIndex = 3;
            this.dgvPersonas.Columns.Add(colDireccion);

            DataGridViewTextBoxColumn colEmail = new DataGridViewTextBoxColumn();
            colEmail.Name = "email";
            colEmail.HeaderText = "E-mail";
            colEmail.DataPropertyName = "Email";
            colEmail.DisplayIndex = 4;
            this.dgvPersonas.Columns.Add(colEmail);

            DataGridViewTextBoxColumn colTelefono = new DataGridViewTextBoxColumn();
            colTelefono.Name = "telefono";
            colTelefono.HeaderText = "Teléfono";
            colTelefono.DataPropertyName = "Telefono";
            colTelefono.DisplayIndex = 5;
            this.dgvPersonas.Columns.Add(colTelefono);

            DataGridViewTextBoxColumn colFechaNacimiento = new DataGridViewTextBoxColumn();
            colFechaNacimiento.Name = "fecha_nac";
            colFechaNacimiento.HeaderText = "Fecha de nacimiento";
            colFechaNacimiento.DataPropertyName = "FechaNacimiento";
            colFechaNacimiento.DisplayIndex = 6;
            this.dgvPersonas.Columns.Add(colFechaNacimiento);

            DataGridViewTextBoxColumn colLegajo = new DataGridViewTextBoxColumn();
            colLegajo.Name = "legajo";
            colLegajo.HeaderText = "Legajo";
            colLegajo.DataPropertyName = "Legajo";
            colLegajo.DisplayIndex = 7;
            this.dgvPersonas.Columns.Add(colLegajo);

            DataGridViewTextBoxColumn colUsuario = new DataGridViewTextBoxColumn();
            colUsuario.Name = "usuario";
            colUsuario.HeaderText = "Usuario";
            colUsuario.DataPropertyName = "NombreUsuario";
            colUsuario.DisplayIndex = 8;
            this.dgvPersonas.Columns.Add(colUsuario);


            DataGridViewCheckBoxColumn colHabilitado = new DataGridViewCheckBoxColumn();
            colHabilitado.Name = "habilitado";
            colHabilitado.HeaderText = "Habilitado";
            colHabilitado.DataPropertyName = "Habilitado";
            colHabilitado.DisplayIndex = 9;
            this.dgvPersonas.Columns.Add(colHabilitado);

            DataGridViewTextBoxColumn colTipoPersona = new DataGridViewTextBoxColumn();
            colTipoPersona.Name = "tipo_persona";
            colTipoPersona.HeaderText = "TipoPersona";
            colTipoPersona.DataPropertyName = "TipoPersona";
            colTipoPersona.DisplayIndex = 10;
            this.dgvPersonas.Columns.Add(colTipoPersona);

            DataGridViewTextBoxColumn colIdPlan = new DataGridViewTextBoxColumn();
            colIdPlan.Name = "id_plan";
            colIdPlan.HeaderText = "ID Plan";
            colIdPlan.DataPropertyName = "IDPlan";
            colIdPlan.DisplayIndex = 11;
            this.dgvPersonas.Columns.Add(colIdPlan);
        }

        public void Listar()
        {
            PersonaLogic per = new PersonaLogic();
            try
            {
                this.dgvPersonas.DataSource = per.GetAll();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de personas.", Ex);
                MessageBox.Show(Ex.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        //Eventos
        private void Personas_Load(object sender, EventArgs e)
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
            PersonaDesktop formPersona = new PersonaDesktop(ApplicationForm.ModoForm.Alta);
            formPersona.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
            PersonaDesktop formPersona = new PersonaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formPersona.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro de que desea eliminar esta persona? ", "Atención", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int ID = ((Business.Entities.Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
                new PersonaLogic().Delete(ID);
                this.Listar();
            }
        }
    }
}
