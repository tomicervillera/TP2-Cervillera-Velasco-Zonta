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
    public partial class Planes : System.Web.UI.Page
    {
        #region Miembros
        private PlanLogic _logic;
        private PlanLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PlanLogic();
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
        private Plan Entity
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
            this.descripcionTextBox.Text = this.Entity.Descripcion;

            EspecialidadLogic el = new EspecialidadLogic();
            ddlEspecialidad.DataSource = el.GetAll();
            ddlEspecialidad.DataTextField = "Descripcion";
            ddlEspecialidad.DataValueField = "ID";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.SelectedValue = el.GetOne(Entity.IdEspecialidad).ID.ToString();
        }
        private void LoadEntity(Plan plan)
        {
            plan.Descripcion = this.descripcionTextBox.Text;
            plan.IdEspecialidad = Convert.ToInt32(this.ddlEspecialidad.SelectedValue);
        }
        private void SaveEntity(Plan plan)
        {
            this.Logic.Save(plan);
        }
        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }
        private void EnableForm(bool enable)
        {
            this.descripcionTextBox.Enabled = enable;

            this.ddlEspecialidad.Enabled = enable;

            EspecialidadLogic el = new EspecialidadLogic();
            ddlEspecialidad.DataSource = el.GetAll();
            ddlEspecialidad.DataTextField = "Descripcion";
            ddlEspecialidad.DataValueField = "ID";
            ddlEspecialidad.DataBind();
        }
        private void ClearForm()
        {
            this.descripcionTextBox.Text = string.Empty;
            this.ddlEspecialidad.Items.Clear();
        }
        private void ValidateUser()
        {
            if (Session["tipoPersona"] != null)
            {
                if (Session["tipoPersona"].ToString() != Persona.TipoPersonas.Admin.ToString())
                {
                    this.gridPanel.Visible = false;
                    this.gridActionsPanel.Visible = false;
                    this.lblError.Visible = true;
                    this.lblError.Text = "Usted no tiene el permiso necesario para acceder aquí.";
                }
                else
                {
                    LoadGrid();
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
                ((Site1)this.Master).HeaderText = "Planes";
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
                
                EspecialidadLogic el = new EspecialidadLogic();
                ddlEspecialidad.DataSource = el.GetAll();
                ddlEspecialidad.DataTextField = "Descripcion";
                ddlEspecialidad.DataValueField = "ID";
                ddlEspecialidad.DataBind();
                ddlEspecialidad.SelectedValue = el.GetOne(Entity.IdEspecialidad).ID.ToString();
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
                        this.Entity = new Plan();
                        this.Entity.ID = this.SelectedID;
                        this.Entity.State = BusinessEntity.States.Modified;

                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();

                        break;
                    case FormModes.Alta:
                        this.Entity = new Plan();
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