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
    public partial class PersonaDesktop : ApplicationForm
    {
        #region Miembros
        private Business.Entities.Persona _PersonaActual;
        public Business.Entities.Persona PersonaActual { get => _PersonaActual; set => _PersonaActual = value; }
        #endregion

        #region Métodos
        //Constructores
        public PersonaDesktop()
        {
            InitializeComponent();
        }
        public PersonaDesktop(ModoForm modo) : this()
        {
            Modo = modo;

            PlanLogic pl = new PlanLogic();
            cboxPlan.DataSource = pl.GetAll();
            cboxPlan.ValueMember = "ID";
            cboxPlan.DisplayMember = "Descripcion";

            cbTipoPersona.DataSource = Enum.GetNames(typeof(Persona.TipoPersonas));
        }
        public PersonaDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            PersonaActual = new PersonaLogic().GetOne(ID);
            MapearDeDatos();
        }

        //Funciones
        public override void MapearDeDatos()
        {
            txtID.Text = PersonaActual.ID.ToString();
            txtNombre.Text = PersonaActual.Nombre;
            txtApellido.Text = PersonaActual.Apellido;
            txtDireccion.Text = PersonaActual.Direccion;
            txtEmail.Text = PersonaActual.Email;
            txtLegajo.Text = PersonaActual.Legajo.ToString();
            txtTelefono.Text = PersonaActual.Telefono;
            dtFechaNacimiento.Value = PersonaActual.FechaNacimiento;
            chkHabilitado.Checked = PersonaActual.Habilitado;
            txtUsuario.Text = PersonaActual.NombreUsuario;
            txtClave.Text = PersonaActual.Clave;
            txtConfirmarClave.Text = PersonaActual.Clave;

            PlanLogic pl = new PlanLogic();
            cboxPlan.DataSource = pl.GetAll();
            cboxPlan.ValueMember = "ID";
            cboxPlan.DisplayMember = "Descripcion";
            cboxPlan.SelectedValue = PersonaActual.IDPlan;

            cbTipoPersona.DataSource = Enum.GetNames(typeof(Persona.TipoPersonas));
            cbTipoPersona.SelectedIndex = (int)PersonaActual.TipoPersona;

            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Baja)
            {
                btnAceptar.Text = "Eliminar";
            }
            else if (Modo == ModoForm.Consulta)
            {
                btnAceptar.Text = "Aceptar";
            }
        }
        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                PersonaActual = new Business.Entities.Persona();
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                PersonaActual.Nombre = txtNombre.Text;
                PersonaActual.Apellido = txtApellido.Text;
                PersonaActual.Direccion = txtDireccion.Text;
                PersonaActual.Email = txtEmail.Text;
                PersonaActual.FechaNacimiento = dtFechaNacimiento.Value.Date;
                PersonaActual.Legajo = Convert.ToInt32(txtLegajo.Text);
                PersonaActual.Telefono = txtTelefono.Text;
                PersonaActual.NombreUsuario = txtUsuario.Text;
                PersonaActual.Clave = txtClave.Text;
                PersonaActual.Habilitado = chkHabilitado.Checked;

                PersonaActual.IDPlan = Convert.ToInt32(((Plan)cboxPlan.SelectedItem).ID);
                PersonaActual.TipoPersona = (Persona.TipoPersonas)cbTipoPersona.SelectedIndex;

                switch (Modo)
                {
                    case ModoForm.Alta:
                        {
                            PersonaActual.State = BusinessEntity.States.New;
                            break;
                        }
                    case ModoForm.Modificacion:
                        {
                            PersonaActual.State = BusinessEntity.States.Modified;
                            break;
                        }
                    case ModoForm.Consulta:
                        {
                            PersonaActual.State = BusinessEntity.States.Unmodified;
                            break;
                        }
                    case ModoForm.Baja:
                        {
                            PersonaActual.State = BusinessEntity.States.Deleted;
                            break;
                        }
                }
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            new PersonaLogic().Save(PersonaActual);
        }
        #endregion

        #region Eventos
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidateChildren() == true)
            {
                GuardarCambios();
                Close();
            }
        }
        private void txtClave_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtClave.Text) == true)
            {
                e.Cancel = true;
                errorProviderPersona.SetError(txtClave, "La clave no debe estar vacía.");
            }
            else if (txtClave.Text.Length < 8)
            {
                e.Cancel = true;
                errorProviderPersona.SetError(txtClave, "La clave ingresada debe ser al menos de 8 carateres de longitud.");
            }
            else if (txtClave.Text != txtConfirmarClave.Text)
            {
                e.Cancel = true;
                errorProviderPersona.SetError(txtClave, "La clave ingresada no coincide con la clave de confirmación.");
            }
            else
            {
                errorProviderPersona.SetError(txtClave, null);
            }
        }
        private void txtUsuario_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtUsuario.Text) == true)
            {
                e.Cancel = true;
                errorProviderPersona.SetError(txtUsuario, "El nombre de usuario no debe estar vacío.");
            }
            else
            {
                errorProviderPersona.SetError(txtUsuario, null);
            }
        }
        private void txtTelefono_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtTelefono.Text) == true)
            {
                e.Cancel = true;
                errorProviderPersona.SetError(txtTelefono, "El teléfono no debe estar vacío.");
            }
            else
            {
                errorProviderPersona.SetError(txtTelefono, null);
            }
        }
        private void txtLegajo_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtLegajo.Text) == true)
            {
                e.Cancel = true;
                errorProviderPersona.SetError(txtLegajo, "El legajo no debe estar vacío.");
            }
            else if (int.TryParse(txtLegajo.Text, out int result) == false)
            {
                errorProviderPersona.SetError(txtLegajo, "El legajo debe ser numérico.");
                e.Cancel = true;
            }
            else if (!(Convert.ToInt32(txtLegajo.Text) >= 0 && Convert.ToInt32(txtLegajo.Text) <= 99999))
            {
                errorProviderPersona.SetError(txtLegajo, "El legajo debe ser positivo.");
                e.Cancel = true;
            }
            else
            {
                errorProviderPersona.SetError(txtLegajo, null);
            }
        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtEmail.Text) == true)
            {
                e.Cancel = true;
                errorProviderPersona.SetError(txtEmail, "El email no debe estar vacío.");
            }
            else
            {
                try
                {
                    var eMailValidator = new System.Net.Mail.MailAddress(txtEmail.Text);
                    errorProviderPersona.SetError(txtEmail, null);
                }
                catch (FormatException)
                {
                    e.Cancel = true;
                    errorProviderPersona.SetError(txtEmail, "El email no es válido.");
                }
            }
        }
        private void txtDireccion_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtDireccion.Text) == true)
            {
                e.Cancel = true;
                errorProviderPersona.SetError(txtDireccion, "La dirección no debe estar vacía.");
            }
            else
            {
                errorProviderPersona.SetError(txtDireccion, null);
            }
        }
        private void txtApellido_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtApellido.Text) == true)
            {
                e.Cancel = true;
                errorProviderPersona.SetError(txtApellido, "El apellido no debe estar vacío.");
            }
            else
            {
                errorProviderPersona.SetError(txtApellido, null);
            }
        }
        private void txtNombre_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombre.Text) == true)
            {
                e.Cancel = true;
                errorProviderPersona.SetError(txtNombre, "El nombre no debe estar vacío.");
            }
            else
            {
                errorProviderPersona.SetError(txtNombre, null);
            }
        }
        #endregion
    }
}
