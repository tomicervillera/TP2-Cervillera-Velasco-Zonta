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
    

        //Propiedades
        private Business.Entities.Persona _PersonaActual;
        public Business.Entities.Persona PersonaActual { get => _PersonaActual; set => _PersonaActual = value; }

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

        //METODOS
        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PersonaActual.ID.ToString();
            this.txtNombre.Text = this.PersonaActual.Nombre;
            this.txtApellido.Text = this.PersonaActual.Apellido;
            this.txtDireccion.Text = this.PersonaActual.Direccion;
            this.txtEmail.Text = this.PersonaActual.Email;
            this.txtLegajo.Text = this.PersonaActual.Legajo.ToString();
            this.txtTelefono.Text = this.PersonaActual.Telefono;
            this.dtFechaNacimiento.Value = this.PersonaActual.FechaNacimiento;
            this.chkHabilitado.Checked = this.PersonaActual.Habilitado;
            this.txtUsuario.Text = this.PersonaActual.NombreUsuario;
            this.txtClave.Text = this.PersonaActual.Clave;
            this.txtConfirmarClave.Text = this.PersonaActual.Clave;

            PlanLogic pl = new PlanLogic();         
            cboxPlan.DataSource = pl.GetAll();
            cboxPlan.ValueMember = "ID";
            cboxPlan.DisplayMember = "Descripcion";
            cboxPlan.SelectedValue = this.PersonaActual.IDPlan;
            
            cbTipoPersona.DataSource = Enum.GetNames(typeof(Persona.TipoPersonas));
            cbTipoPersona.SelectedIndex = (int)PersonaActual.TipoPersona;

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
                PersonaActual = new Business.Entities.Persona();
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.PersonaActual.Nombre = this.txtNombre.Text;
                this.PersonaActual.Apellido = this.txtApellido.Text;
                this.PersonaActual.Direccion= this.txtDireccion.Text;
                this.PersonaActual.Email = this.txtEmail.Text; 
                this.PersonaActual.FechaNacimiento = this.dtFechaNacimiento.Value.Date;
                this.PersonaActual.Legajo = Convert.ToInt32(this.txtLegajo.Text);
                this.PersonaActual.Telefono = this.txtTelefono.Text;
                this.PersonaActual.NombreUsuario = txtUsuario.Text;
                this.PersonaActual.Clave = txtClave.Text;
                this.PersonaActual.Habilitado = chkHabilitado.Checked;

                this.PersonaActual.IDPlan = Convert.ToInt32(((Plan)cboxPlan.SelectedItem).ID);
                this.PersonaActual.TipoPersona = (Persona.TipoPersonas)cbTipoPersona.SelectedIndex;

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
        public override bool Validar()
        {

            foreach (Control oControls in this.tableLayoutPanel1.Controls) // Buscamos en cada TextBox de nuestro Formulario.
            {
                if (oControls is TextBox & oControls.Text == String.Empty & oControls.Name != "txtID") // Verificamos que no este vacio exceptuando al txtID porque se asigna automáticamente.
                {
                    Notificar("Hay al menos un campo vacío. Por favor, completelo/s. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return (false);
                }
            }

            foreach (char c in txtLegajo.Text)
            {
                if (c < '0' || c > '9')
                {
                    Notificar("Legajo no válido. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
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
        
        
        
        //EVENTOS
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        } //Botón Cancelar

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }//Botón Aceptar

    
    }
}
