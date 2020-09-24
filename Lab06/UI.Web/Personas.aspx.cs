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
    public partial class Personas: System.Web.UI.Page
    {
        #region Miembros
        private PersonaLogic _logic;
        private PersonaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PersonaLogic();
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
        private Persona Entity
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
            this.nombreTextBox.Text = this.Entity.Nombre;
            this.apellidoTextBox.Text = this.Entity.Apellido;
            this.emailTextBox.Text = this.Entity.Email;
            this.direccionTextBox.Text = this.Entity.Direccion;
            this.telefonoTextBox.Text = this.Entity.Telefono;
            this.ddlDiaFechaNac.SelectedIndex = this.Entity.FechaNacimiento.Day - 1;
            this.ddlMesFechaNac.SelectedIndex = this.Entity.FechaNacimiento.Month - 1;
            this.añoNacimientoTextBox.Text = this.Entity.FechaNacimiento.Year.ToString();
            this.legajoTextBox.Text = this.Entity.Legajo.ToString();
            this.habilitadoCheckBox.Checked = this.Entity.Habilitado;
            this.nombreUsuarioTextBox.Text = this.Entity.NombreUsuario;

            PlanLogic pl = new PlanLogic();
            ddlPlan.DataSource = pl.GetAll();
            ddlPlan.DataTextField = "Descripcion";
            ddlPlan.DataValueField = "ID";
            ddlPlan.DataBind();
            ddlPlan.SelectedValue = pl.GetOne(Entity.IDPlan).ID.ToString();
        }
        private void LoadEntity(Persona persona)
        {
            persona.Nombre = this.nombreTextBox.Text;
            persona.Apellido= this.apellidoTextBox.Text;
            persona.Email = this.emailTextBox.Text;
            persona.Direccion = this.direccionTextBox.Text;
            persona.Telefono = this.telefonoTextBox.Text;
            persona.FechaNacimiento = new DateTime(Convert.ToInt32(this.añoNacimientoTextBox.Text), Convert.ToInt32(this.ddlMesFechaNac.SelectedValue), Convert.ToInt32(this.ddlDiaFechaNac.SelectedValue));
            persona.Legajo = Convert.ToInt32(this.legajoTextBox.Text);
            persona.NombreUsuario = this.nombreUsuarioTextBox.Text;
            persona.Clave= this.claveTextBox.Text;
            persona.Habilitado = this.habilitadoCheckBox.Checked;

            persona.IDPlan= Convert.ToInt32(this.ddlPlan.SelectedValue);
        }
        private void SaveEntity(Persona persona)
        {
            this.Logic.Save(persona);
        }
        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }
        private void EnableForm(bool enable)
        {
            this.nombreTextBox.Enabled = enable;
            this.apellidoTextBox.Enabled = enable;
            this.telefonoTextBox.Enabled = enable;
            this.emailTextBox.Enabled = enable;
            this.direccionTextBox.Enabled = enable;
            this.legajoTextBox.Enabled = enable;
            this.ddlDiaFechaNac.Enabled = enable;
            this.ddlMesFechaNac.Enabled = enable;
            this.añoNacimientoTextBox.Enabled = enable;
            this.nombreUsuarioTextBox.Enabled = enable;
            this.habilitadoCheckBox.Enabled = enable;

            this.claveTextBox.Enabled= enable;
            this.claveRequiredFieldValidator.Enabled = enable;
            this.claveCompareValidator.Enabled = enable;
            
            this.repetirClaveTextBox.Enabled = enable;
            this.repetirClaveRequiredFieldValidator.Enabled = enable;

            PlanLogic pl = new PlanLogic();
            ddlPlan.DataSource = pl.GetAll();
            ddlPlan.DataTextField = "Descripcion";
            ddlPlan.DataValueField = "ID";
            ddlPlan.DataBind();
        }
        private void ClearForm()
        {
            this.nombreTextBox.Text = string.Empty;
            this.apellidoTextBox.Text = string.Empty;
            this.telefonoTextBox.Text = string.Empty;
            this.emailTextBox.Text = string.Empty;
            this.direccionTextBox.Text = string.Empty;
            this.legajoTextBox.Text = string.Empty;
            this.ddlDiaFechaNac.SelectedIndex = 0;
            this.ddlMesFechaNac.SelectedIndex = 0;
            this.añoNacimientoTextBox.Text = string.Empty;
            this.habilitadoCheckBox.Checked = false;
            this.nombreUsuarioTextBox.Text = string.Empty;
            this.claveTextBox.Text = string.Empty;
            this.repetirClaveTextBox.Text = string.Empty;
        }
        #endregion

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Site1)this.Master).HeaderText = "Personas";
            if (Page.IsPostBack == false)
            {
                LoadGrid();
            }
        }
        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }
        protected void fechaNacimientoCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Convert.ToInt32(args.Value) >= 29 && ddlMesFechaNac.SelectedValue == "02")
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
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
                        this.Entity = new Persona();
                        this.Entity.ID = this.SelectedID;
                        this.Entity.State = BusinessEntity.States.Modified;

                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();

                        break;
                    case FormModes.Alta:
                        this.Entity = new Persona();
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