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
    public partial class UsuarioDesktop : ApplicationForm
    {
        private Business.Entities.Usuario _UsuarioActual;

        public Business.Entities.Usuario UsuarioActual { get => _UsuarioActual; set => _UsuarioActual = value; }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;
            
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }
            else if (Modo == ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }

        }
        public override void MapearADatos()
        {
            
            if (Modo == ModoForm.Alta)
            {
                UsuarioActual = new Usuario();
            }
            if(Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                UsuarioActual.Nombre = txtNombre.Text;
                UsuarioActual.Apellido = txtApellido.Text;
                UsuarioActual.Email = txtEmail.Text;
                UsuarioActual.NombreUsuario = txtUsuario.Text;
                UsuarioActual.Clave = txtClave.Text;
                //UsuarioActual.Clave = txtConfirmarClave.Text;

                switch (Modo)
                {
                    case ModoForm.Alta:
                        {
                            UsuarioActual.State = BusinessEntity.States.New;
                            break;
                        }
                    case ModoForm.Modificacion:
                        {
                            UsuarioActual.State = BusinessEntity.States.Modified;
                            break;
                        }
                    case ModoForm.Consulta:
                        {
                            UsuarioActual.State = BusinessEntity.States.Unmodified;
                            break;
                        }
                    case ModoForm.Baja:
                        {
                            UsuarioActual.State = BusinessEntity.States.Deleted;
                            break;
                        }
                }
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            new UsuarioLogic().Save(UsuarioActual);

        }
        /*public override bool Validar() 
        {
            if (String.IsNullOrEmpty(txtNombre.Text) == false || (String.IsNullOrEmpty(txtApellido.Text) == false) || (String.IsNullOrEmpty(txtClave.Text) == false)
                || (String.IsNullOrEmpty(txtConfirmarClave.Text) == false) || (String.IsNullOrEmpty(txtEmail.Text) == false) || (String.IsNullOrEmpty(txtUsuario.Text) == false))
            {
                Notificar("Hay al menos un campo vacío. Por favor, completelo/s.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false);
            }
            else return (true);
        }*/
        public override bool Validar()
        {
            foreach (Control oControls in this.Controls) // Buscamos en cada TextBox de nuestro Formulario.
            {
                if (oControls is TextBox & oControls.Text == String.Empty) // Verificamos que no este vacio.
                {
                    Notificar("Hay al menos un campo vacío. Por favor, completelo/s. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return (false);
                }
            }

            if (txtClave.Text != txtConfirmarClave.Text)
            {
                Notificar("La clave ingresada no coincide con la clave de confirmación. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false);
            }
            else if (txtClave.Text.Length < 8)
            {
                Notificar("La clave ingresada debe ser al menos de 8 carateres de longitud.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false);
            }
            
            if (!((txtEmail.Text.Contains("@")) && (txtEmail.Text.Contains(".com"))))
            {
                Notificar("El email ingresado no es válido. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (false);
            }
             
            return (true);

        }





        public UsuarioDesktop()
        {
            InitializeComponent();
        }
        public UsuarioDesktop(ModoForm modo) : this()
        {

        }
        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            UsuarioActual = new UsuarioLogic().GetOne(ID);
            Modo = modo;
            MapearDeDatos();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
