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
    public partial class Default : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                ((Site1)this.Master).HeaderText = "Home";
                ValidateUser();
            }
            
        }
        #endregion

        #region Métodos
        private void ValidateUser()
        {
            if (Session["tipoPersona"] == null)
            {
                this.bienvenidaPanel.Visible = false;
                this.errorPanel.Visible = true;
                this.lblError.Visible = true;
                this.lblError.Text = "Usted no está logueado en el sistema. Por favor, inicie sesión <a href=/Login.aspx>aquí</a> .";
            }
        }
        #endregion
    }
}