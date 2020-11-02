using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;

namespace UI.Web
{
    public partial class AlumnosInscripcionesReporte : System.Web.UI.Page
    {
        #region Métodos
        private void ValidateUser()
        {
            if (Session["tipoPersona"] != null)
            {
                if (Session["tipoPersona"].ToString() != Persona.TipoPersonas.Admin.ToString())
                {
                    reportePanel.Visible = false;
                    errorPanel.Visible = true;
                    lblError.Visible = true;
                    lblError.Text = "Usted no tiene el permiso necesario para acceder aquí.";
                }
            }
            else
            {
                reportePanel.Visible = false;
                errorPanel.Visible = true;
                lblError.Visible = true;
                lblError.Text = "Usted no está logueado en el sistema. Por favor, inicie sesión <a href=/Login.aspx>aquí</a> .";
            }
        }
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                ((Site)this.Master).HeaderText = "Reporte de Inscripciones";
                ValidateUser();
            }
        }
        #endregion
    }

}