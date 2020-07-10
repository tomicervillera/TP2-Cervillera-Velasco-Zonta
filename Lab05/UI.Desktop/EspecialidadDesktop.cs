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
    public partial class EspecialidadDesktop : ApplicationForm
    {
        //Propiedades
        private Business.Entities.Especialidad _EspecialidadActual;
        public Business.Entities.Especialidad EspecialidadActual { get => _EspecialidadActual; set => _EspecialidadActual = value; }


        //Constructores
        public EspecialidadDesktop()
        {
            InitializeComponent();
        }
        public EspecialidadDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }
        public EspecialidadDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            EspecialidadActual = new EspecialidadLogic().GetOne(ID);
            MapearDeDatos();
        }

        //Métodos
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.EspecialidadActual.ID.ToString();          
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion;          

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
                EspecialidadActual = new Business.Entities.Especialidad();
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                EspecialidadActual.Descripcion = txtDescripcion.Text;
                //UsuarioActual.Clave = txtConfirmarClave.Text;

                switch (Modo)
                {
                    case ModoForm.Alta:
                        {
                            EspecialidadActual.State = BusinessEntity.States.New;
                            break;
                        }
                    case ModoForm.Modificacion:
                        {
                            EspecialidadActual.State = BusinessEntity.States.Modified;
                            break;
                        }
                    case ModoForm.Consulta:
                        {
                            EspecialidadActual.State = BusinessEntity.States.Unmodified;
                            break;
                        }
                    case ModoForm.Baja:
                        {
                            EspecialidadActual.State = BusinessEntity.States.Deleted;
                            break;
                        }
                }
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            new EspecialidadLogic().Save(EspecialidadActual);

        }
        /*
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
        */
        
        //Eventos
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (true /*Validar()*/) //TERMINAR VALIDACION 
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
