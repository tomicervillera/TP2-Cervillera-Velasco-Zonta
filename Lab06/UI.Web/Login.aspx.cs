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
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tipoPersona"] != null)
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                ((Site)this.Master).HeaderText = "Login";
            }
            
        }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            PersonaLogic pl = new PersonaLogic();
            List<Business.Entities.Persona> usuarios = pl.GetAll();
            Business.Entities.Persona currentUser = null;

            foreach (Business.Entities.Persona usu in usuarios)
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
                Session["tipoPersona"] = currentUser.TipoPersona;
                Session["idPersona"] = currentUser.ID;
                Response.Redirect("/Default.aspx");
            }
        }
        protected void lnkRecordarClave_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Usted es un usuario muy descuidado, haga memoria.');</script>");
        }
        #endregion
    }
}