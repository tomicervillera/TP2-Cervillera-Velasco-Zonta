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
    public partial class Site : System.Web.UI.MasterPage
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
                TreeNode node;

                if (Session["tipoPersona"].ToString() == Persona.TipoPersonas.Admin.ToString())
                {
                    node = new TreeNode("Comisiones", "Comisiones", null, "~/Comisiones.aspx", null);
                    TreeNav.Nodes[0].ChildNodes.Add(node);

                    node = new TreeNode("Cursos", "Cursos", null, "~/Cursos.aspx", null);
                    TreeNav.Nodes[0].ChildNodes.Add(node);

                    node = new TreeNode("Comisiones", "Comisiones", null, "~/Comisiones.aspx", null);
                    TreeNav.Nodes[0].ChildNodes.Add(node);

                    node = new TreeNode("Docentes-Cursos", "Docentes-Cursos", null, "~/DocentesCursos.aspx", null);
                    TreeNav.Nodes[0].ChildNodes.Add(node);

                    node = new TreeNode("Especialidades", "Especialidades", null, "~/Especialidades.aspx", null);
                    TreeNav.Nodes[0].ChildNodes.Add(node);

                    node = new TreeNode("Inscripciones de Alumnos", "AlumnosInscripciones", null, "~/AlumnosInscripciones.aspx", null);
                    TreeNav.Nodes[0].ChildNodes.Add(node);

                    node = new TreeNode("Materias", "Materias", null, "~/Materias.aspx", null);
                    TreeNav.Nodes[0].ChildNodes.Add(node);

                    node = new TreeNode("Personas", "Personas", null, "~/Personas.aspx", null);
                    TreeNav.Nodes[0].ChildNodes.Add(node);

                    node = new TreeNode("Planes", "Planes", null, "~/Planes.aspx", null);
                    TreeNav.Nodes[0].ChildNodes.Add(node);
                }
                else if (Session["tipoPersona"].ToString() == Persona.TipoPersonas.Alumno.ToString())
                {
                    node = new TreeNode("Comisiones", "Comisiones", null, "~/Comisiones.aspx", null);
                    TreeNav.Nodes[0].ChildNodes.Add(node);

                    node = new TreeNode("Especialidades", "Especialidades", null, "~/Especialidades.aspx", null);
                    TreeNav.Nodes[0].ChildNodes.Add(node);

                    node = new TreeNode("Materias", "Materias", null, "~/Materias.aspx", null);
                    TreeNav.Nodes[0].ChildNodes.Add(node);
                }
                else if (Session["tipoPersona"].ToString() == Persona.TipoPersonas.Docente.ToString())
                {
                    node = new TreeNode("Comisiones", "Comisiones", null, "~/Comisiones.aspx", null);
                    TreeNav.Nodes[0].ChildNodes.Add(node);

                    node = new TreeNode("Docentes-Cursos", "Docentes-Cursos", null, "~/DocentesCursos.aspx", null);
                    TreeNav.Nodes[0].ChildNodes.Add(node);

                    node = new TreeNode("Especialidades", "Especialidades", null, "~/Especialidades.aspx", null);
                    TreeNav.Nodes[0].ChildNodes.Add(node);

                    node = new TreeNode("Inscripciones de Alumnos", "AlumnosInscripciones", null, "~/AlumnosInscripciones.aspx", null);
                    TreeNav.Nodes[0].ChildNodes.Add(node);

                    node = new TreeNode("Materias", "Materias", null, "~/Materias.aspx", null);
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