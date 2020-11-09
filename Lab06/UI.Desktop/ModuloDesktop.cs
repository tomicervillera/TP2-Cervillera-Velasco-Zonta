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
    public partial class ModuloDesktop : ApplicationForm
    {
        #region Miembros
        private Business.Entities.Modulo _ModuloActual;
        public Business.Entities.Modulo ModuloActual { get => _ModuloActual; set => _ModuloActual = value; }
        #endregion
        
        #region Métodos
        //Constructores
        public ModuloDesktop()
        {
            InitializeComponent();
        }
        public ModuloDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }
        public ModuloDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            ModuloActual = new ModuloLogic().GetOne(ID);
            MapearDeDatos();
        }

        //Funciones
        public override void MapearDeDatos()
        {
            txtID.Text = ModuloActual.ID.ToString();
            txtDescripcion.Text = ModuloActual.Descripcion;

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
                ModuloActual = new Business.Entities.Modulo();
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                ModuloActual.Descripcion = txtDescripcion.Text;

                switch (Modo)
                {
                    case ModoForm.Alta:
                        {
                            ModuloActual.State = BusinessEntity.States.New;
                            break;
                        }
                    case ModoForm.Modificacion:
                        {
                            ModuloActual.State = BusinessEntity.States.Modified;
                            break;
                        }
                    case ModoForm.Consulta:
                        {
                            ModuloActual.State = BusinessEntity.States.Unmodified;
                            break;
                        }
                    case ModoForm.Baja:
                        {
                            ModuloActual.State = BusinessEntity.States.Deleted;
                            break;
                        }
                }
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            new ModuloLogic().Save(ModuloActual);
        }
        #endregion

        #region Eventos
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
        #endregion

    }
}
