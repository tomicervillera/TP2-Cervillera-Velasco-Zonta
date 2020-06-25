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
        private Usuario _UsuarioActual;

        public Usuario UsuarioActual { get => _UsuarioActual; set => _UsuarioActual = value; }

        public override void MapearDeDatos()
        {

        }
        public override void MapearADatos()
        {

        }
        public override void GuardarCambios()
        {

        }
        public override bool Validar() { return false; }
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
            MapearDeDatos();
            

        }

    }
}
