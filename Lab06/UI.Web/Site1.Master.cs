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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        #region Miembros
        public string HeaderText
        {
            get
            {
                return HeaderText;
            }
            set
            {
                lblHeader.Text = value;
            }
        }
        public TreeView TreeNav
        {
            get
            {
                return TreeViewNavegacion;
            }
        }
        #endregion

        #region Métodos
        private void ChangeMenu()
        {
            TreeNav.Nodes[0].ChildNodes.Clear();
            if (Session["tipoPersona"] != null)
            {
                if (Session["tipoPersona"].ToString() == Persona.TipoPersonas.Admin.ToString())
                {
                    TreeNode node = new TreeNode("Especialidades", "Especialidades", null, "~/Especialidades.aspx", null);
                    TreeNav.Nodes[0].ChildNodes.Add(node);

                    node = new TreeNode("Personas", "Personas", null, "~/Personas.aspx", null);
                    TreeNav.Nodes[0].ChildNodes.Add(node);

                    node = new TreeNode("Planes", "Planes", null, "~/Planes.aspx", null);
                    TreeNav.Nodes[0].ChildNodes.Add(node);
                }
                else if (Session["tipoPersona"].ToString() == Persona.TipoPersonas.Alumno.ToString())
                {

                }
                else if (Session["tipoPersona"].ToString() == Persona.TipoPersonas.Docente.ToString())
                {
                    TreeNode node = new TreeNode("Personas", "Personas", null, "~/Personas.aspx", null);
                    TreeNav.Nodes[0].ChildNodes.Add(node);
                }
            }
            else
            {
                TreeNav.Visible = false;
                cerrarSesionButton.Visible = false;
            }
        }
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                ChangeMenu();
            }
        }
        protected void cerrarSesionButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
        #endregion
    }
}