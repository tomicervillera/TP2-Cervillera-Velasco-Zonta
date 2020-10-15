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
    public partial class DocentesCursos : System.Web.UI.Page
    {
        #region Miembros
        private DocenteCursoLogic _logic;
        private DocenteCursoLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new DocenteCursoLogic();
                }
                return _logic;
            }
        }
        public enum FormModes
        {
            Alta, Baja, Modificacion
        }
        public FormModes FormMode
        {
            get
            {
                return (FormModes)this.ViewState["FormMode"];
            }
            set
            {
                this.ViewState["FormMode"] = value;
            }
        }
        private DocenteCurso Entity
        {
            get;
            set;
        }
        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }
        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }
        #endregion

        #region Metodos
        private void LoadGrid()
        {
            gridView.DataSource = this.Logic.GetAll();
            gridView.DataBind();
        }
        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);

            ddlCargo.DataSource = Enum.GetNames(typeof(DocenteCurso.TiposCargos));
            ddlCargo.DataBind();
            ddlCargo.SelectedIndex = (int)Entity.Cargo;

            CursoLogic cl = new CursoLogic();
            ddlCurso.DataSource = cl.GetAll();
            ddlCurso.DataTextField = "ID";
            ddlCurso.DataValueField = "ID";
            ddlCurso.DataBind();
            ddlCurso.SelectedValue = cl.GetOne(Entity.IDCurso).ID.ToString();

            PersonaLogic pl = new PersonaLogic();
            List<Persona> docentes = new List<Persona>();
            foreach (Persona per in pl.GetAll())
            {
                if (per.TipoPersona == Persona.TipoPersonas.Docente)
                {
                    docentes.Add(per);
                }
            }
            ddlDocente.DataSource = docentes;
            ddlDocente.DataTextField = "Legajo";
            ddlDocente.DataValueField = "ID";
            ddlDocente.DataBind();
            ddlDocente.SelectedValue = pl.GetOne(Entity.IDDocente).ID.ToString();
        }
        private void LoadEntity(DocenteCurso docenteCurso)
        {
            docenteCurso.IDCurso = Convert.ToInt32(this.ddlCurso.SelectedValue);
            docenteCurso.IDDocente= Convert.ToInt32(this.ddlDocente.SelectedValue);
            docenteCurso.Cargo = (DocenteCurso.TiposCargos)ddlCargo.SelectedIndex;
        }
        private void SaveEntity(DocenteCurso docenteCurso)
        {
            this.Logic.Save(docenteCurso);
        }
        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }
        private void EnableForm(bool enable)
        {
            ddlCargo.DataSource = Enum.GetNames(typeof(DocenteCurso.TiposCargos));
            ddlCargo.DataBind();
            ddlCargo.Enabled = enable;
            
            CursoLogic cl = new CursoLogic();
            ddlCurso.DataSource = cl.GetAll();
            ddlCurso.DataTextField = "ID";
            ddlCurso.DataValueField = "ID";
            ddlCurso.DataBind();
            ddlCurso.Enabled = enable;

            PersonaLogic pl = new PersonaLogic();
            List<Persona> docentes = new List<Persona>();
            foreach (Persona per in pl.GetAll())
            {
                if (per.TipoPersona == Persona.TipoPersonas.Docente)
                {
                    docentes.Add(per);
                }
            }
            ddlDocente.DataSource = docentes;
            ddlDocente.DataTextField = "Legajo";
            ddlDocente.DataValueField = "ID";
            ddlDocente.DataBind();
            ddlDocente.Enabled = enable;
        }
        private void ClearForm()
        {
        }
        private void ValidateUser()
        {
            if (Session["tipoPersona"] != null)
            {
                if (Session["tipoPersona"].ToString() == Persona.TipoPersonas.Admin.ToString())
                {
                    LoadGrid();
                }
                else if (Session["tipoPersona"].ToString() == Persona.TipoPersonas.Docente.ToString())
                {
                    this.gridActionsPanel.Visible = false;
                    LoadGrid();
                }
                else if (Session["tipoPersona"].ToString() == Persona.TipoPersonas.Alumno.ToString())
                {
                    this.gridPanel.Visible = false;
                    this.gridActionsPanel.Visible = false;
                    this.lblError.Visible = true;
                    this.lblError.Text = "Usted no tiene el permiso necesario para acceder aquí.";
                }
            }
            else
            {
                this.gridActionsPanel.Visible = false;
                this.errorPanel.Visible = true;
                this.lblError.Visible = true;
                this.lblError.Text = "Usted no está logueado en el sistema. Por favor, inicie sesión <a href=/Login.aspx>aquí</a> .";
            }
        }
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                ((Site)this.Master).HeaderText = "Docentes-Cursos";
                ValidateUser();
            }
        }
        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        //GridActionsPanel
        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formActionsPanel.Visible = true;
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.EnableForm(true);
                this.LoadForm(this.SelectedID);
            }
        }
        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.formActionsPanel.Visible = true;
                this.FormMode = FormModes.Baja;

                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }
        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formActionsPanel.Visible = true;
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        //FormActionsPanel
        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid == true)
            {
                switch (this.FormMode)
                {
                    case FormModes.Baja:
                        this.DeleteEntity(this.SelectedID);
                        this.LoadGrid();
                        break;
                    case FormModes.Modificacion:
                        this.Entity = new DocenteCurso();
                        this.Entity.ID = this.SelectedID;
                        this.Entity.State = BusinessEntity.States.Modified;

                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();

                        break;
                    case FormModes.Alta:
                        this.Entity = new DocenteCurso();
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        break;
                    default:
                        break;
                }
                this.formPanel.Visible = false;
                this.formActionsPanel.Visible = false;
            }
        }
        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.EnableForm(false);
            this.formPanel.Visible = false;
            this.formActionsPanel.Visible = false;
        }
        #endregion
    }
}