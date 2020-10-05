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
        #region Miembros

        #endregion
        #region Métodos
        public formLogin()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            PersonaLogic pl = new PersonaLogic();
            List<Business.Entities.Persona> personas = pl.GetAll();
            Business.Entities.Persona personaActiva = null;
            
            foreach (Business.Entities.Persona usu in personas)
            {
                if (usu.NombreUsuario == txtUsuario.Text)
                {
                    personaActiva = usu;
                    break;
                }
            }
            if (personaActiva == null)
            {
                MessageBox.Show("Usuario incorrecto.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (personaActiva.Clave != txtPass.Text)
            {
                MessageBox.Show("Contraseña incorrecta.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (personaActiva.Habilitado == false)
            {
                MessageBox.Show("Usuario no habilitado.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ((formMain)this.Owner).PersonaActiva = personaActiva;
                MessageBox.Show("Usted ha ingresado al sistema correctamente.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
        }
        private void lnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Usted es un usuario muy descuidado, haga memoria.", "Olvidé mi contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        #endregion
    }
}
