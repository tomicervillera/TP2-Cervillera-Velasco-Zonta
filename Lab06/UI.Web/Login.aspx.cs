using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
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
                Response.Write("<script>alert('Usuario incorrecto.');</script>");
            }
            else if (currentUser.Clave != txtClave.Text)
            {
                Response.Write("<script>alert('Contraseña incorrecta.');</script>");
            }
            else if (currentUser.Habilitado == false)
            {
                Response.Write("<script>alert('Usuario no habilitado.');</script>");
            }
            else
            {
                Response.Write("<script>alert('Usted ha ingresado al sistema correctamente.');</script>");
                Response.Redirect("/Default.aspx");
            }
        }
        protected void lnkRecordarClave_Click(object sender, EventArgs e)
        {
            //Redirecciono a otra página que debería existir y para mostrar el mensaje tener dicho elemento.
            Response.Write("<script>alert('Es Ud. un usuario muy descuidado, haga memoria. ');</script>");
            //Response.Redirect("/Login.aspx?msj=Es Ud. un usuario muy descuidado, haga memoria. ");
        }
    }
}