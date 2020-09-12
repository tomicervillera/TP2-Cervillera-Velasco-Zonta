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
    public partial class ModuloUsuarioDesktop : ApplicationForm
    {
        //Propiedades
        private Business.Entities.ModuloUsuario _ModuloUsuarioActual;
        public Business.Entities.ModuloUsuario ModuloUsuarioActual { get => _ModuloUsuarioActual; set => _ModuloUsuarioActual = value; }

        //Constructores
        public ModuloUsuarioDesktop()
        {
            InitializeComponent();
        }
        public ModuloUsuarioDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            UsuarioLogic ul = new UsuarioLogic();
            cboxUsuario.DataSource = ul.GetAll();
            cboxUsuario.ValueMember = "ID";
            cboxUsuario.DisplayMember = "NombreUsuario";

            ModuloLogic ml = new ModuloLogic();
            cboxModulo.DataSource = ml.GetAll();
            cboxModulo.ValueMember = "ID";
            cboxModulo.DisplayMember = "Descripcion";
        }
        public ModuloUsuarioDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            ModuloUsuarioActual = new ModuloUsuarioLogic().GetOne(ID);
            MapearDeDatos();
        }

        //Métodos
        public override void MapearDeDatos()
        {
            txtID.Text = this.ModuloUsuarioActual.ID.ToString();
            checkBoxAlta.Checked = ModuloUsuarioActual.PermiteAlta;
            checkBoxBaja.Checked = ModuloUsuarioActual.PermiteBaja;
            checkBoxModificacion.Checked = ModuloUsuarioActual.PermiteModificacion;
            checkBoxConsulta.Checked = ModuloUsuarioActual.PermiteConsulta;

            UsuarioLogic ul = new UsuarioLogic();
            cboxUsuario.DataSource = ul.GetAll();
            cboxUsuario.ValueMember = "ID";
            cboxUsuario.DisplayMember = "NombreUsuario";
            cboxUsuario.SelectedValue = ul.GetOne(ModuloUsuarioActual.IdUsuario).ID;

            ModuloLogic ml = new ModuloLogic();
            cboxModulo.DataSource = ml.GetAll();
            cboxModulo.ValueMember = "ID";
            cboxModulo.DisplayMember = "Descripcion";
            cboxModulo.SelectedValue = ml.GetOne(ModuloUsuarioActual.IdModulo).ID;

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
                ModuloUsuarioActual = new Business.Entities.ModuloUsuario();
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {

                ModuloUsuarioActual.PermiteAlta = checkBoxAlta.Checked;
                ModuloUsuarioActual.PermiteBaja = checkBoxBaja.Checked;
                ModuloUsuarioActual.PermiteModificacion = checkBoxModificacion.Checked;
                ModuloUsuarioActual.PermiteConsulta = checkBoxConsulta.Checked;

                ModuloUsuarioActual.IdUsuario = Convert.ToInt32(((Usuario)cboxUsuario.SelectedItem).ID);
                ModuloUsuarioActual.IdModulo = Convert.ToInt32(((Modulo)cboxModulo.SelectedItem).ID);

                switch (Modo)
                {
                    case ModoForm.Alta:
                        {
                            ModuloUsuarioActual.State = BusinessEntity.States.New;
                            break;
                        }
                    case ModoForm.Modificacion:
                        {
                            ModuloUsuarioActual.State = BusinessEntity.States.Modified;
                            break;
                        }
                    case ModoForm.Consulta:
                        {
                            ModuloUsuarioActual.State = BusinessEntity.States.Unmodified;
                            break;
                        }
                    case ModoForm.Baja:
                        {
                            ModuloUsuarioActual.State = BusinessEntity.States.Deleted;
                            break;
                        }
                }
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            new ModuloUsuarioLogic().Save(ModuloUsuarioActual);
        }
        public override bool Validar()
        {
            foreach (ComboBox oControls in this.tableLayoutPanel1.Controls.OfType<ComboBox>()) // Buscamos en cada TextBox de nuestro Formulario.
            {
                if (oControls.SelectedItem == null) // Verificamos que no este vacio exceptuando al txtID porque se asigna automáticamente.
                {
                    Notificar("Hay al menos un campo vacío. Por favor, completelo/s. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return (false);
                }
            }
            return (true);
        }

        //Eventos
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
