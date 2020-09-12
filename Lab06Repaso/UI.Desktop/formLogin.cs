using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            UsuarioLogic ul = new UsuarioLogic();
            List<Business.Entities.Usuario> usuarios = ul.GetAll();
            Business.Entities.Usuario currentUser = null;
            
            foreach (Business.Entities.Usuario usu in usuarios)
            {
                if (usu.NombreUsuario == txtUsuario.Text)
                {
                    currentUser = usu;
                    break;
                }
            }
            if (currentUser == null)
            {
                MessageBox.Show("Usuario incorrecto.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (currentUser.Clave != txtPass.Text)
            {
                MessageBox.Show("Contraseña incorrecta.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Usted ha ingresado al sistema correctamente.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
        }
        private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Usted es un usuario muy descuidado, haga memoria.", "Olvidé mi contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

    }
}
