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
    public partial class AlumnosInscripciones : System.Web.UI.Page
    {
        #region Miembros
        private AlumnoInscripcionLogic _logic;
        private AlumnoInscripcionLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new AlumnoInscripcionLogic();
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
                return (FormModes)ViewState["FormMode"];
            }
            set
            {
                ViewState["FormMode"] = value;
            }
        }
        private AlumnoInscripcion Entity
        {
            get;
            set;
        }
        private int SelectedID
        {
            get
            {
                if (ViewState["SelectedID"] != null)
                {
                    return (int)ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["SelectedID"] = value;
            }
        }
        private bool IsEntitySelected
        {
            get
            {
                return (SelectedID != 0);
            }
        }
        #endregion

        #region Metodos
        private void LoadGrid()
        {
            if (Session["tipoPersona"].ToString() == Persona.TipoPersonas.Admin.ToString())
            {
                gridView.DataSource = Logic.GetAll();
                gridView.DataBind();
            }
            else if (Session["tipoPersona"].ToString() == Persona.TipoPersonas.Docente.ToString())
            {
                gridView.DataSource = Logic.GetFromDocente(Convert.ToInt32(Session["idPersona"]));
                gridView.DataBind();
            }
            else if (Session["tipoPersona"].ToString() == Persona.TipoPersonas.Alumno.ToString())
            {
                gridView.DataSource = Logic.GetFromAlumno(Convert.ToInt32(Session["idPersona"]));
                gridView.DataBind();
            }
            
        }
        private void LoadForm(int id)
        {
            Entity = Logic.GetOne(id);
            ddlCondicion.SelectedValue = Entity.Condicion;
            notaTextBox.Text = Entity.Nota.ToString();

            PersonaLogic pl = new PersonaLogic();
            List<Persona> alumnos = new List<Persona>();
            foreach (Persona per in pl.GetAll())
            {
                if (per.TipoPersona == Persona.TipoPersonas.Alumno)
                {
                    alumnos.Add(per);
                }
            }
            ddlAlumno.DataSource = alumnos;
            ddlAlumno.DataTextField = "Legajo";
            ddlAlumno.DataValueField = "ID";
            ddlAlumno.DataBind();
            ddlAlumno.SelectedValue = pl.GetOne(Entity.IDAlumno).ID.ToString();

            CursoLogic cl = new CursoLogic();
            ddlCurso.DataSource = cl.GetAll();
            ddlCurso.DataTextField = "ID";
            ddlCurso.DataValueField = "ID";
            ddlCurso.DataBind();
            ddlCurso.SelectedValue = cl.GetOne(Entity.IDCurso).ID.ToString();
        }
        private void LoadEntity(AlumnoInscripcion alumnoInscripcion)
        {
            alumnoInscripcion.IDAlumno = Convert.ToInt32(ddlAlumno.SelectedValue);
            alumnoInscripcion.IDCurso = Convert.ToInt32(ddlCurso.SelectedValue);

            if (string.IsNullOrEmpty(notaTextBox.Text))
            {
                alumnoInscripcion.Nota = 0;
            }
            else
            {
                alumnoInscripcion.Nota = Convert.ToInt32(notaTextBox.Text);
            }
            
            alumnoInscripcion.Condicion = ddlCondicion.SelectedValue;
        }
        private void SaveEntity(AlumnoInscripcion alumnoInscripcion)
        {
            Logic.Save(alumnoInscripcion);
        }
        private void DeleteEntity(int id)
        {
            Logic.Delete(id);
        }
        private void EnableForm(bool enable)
        {
            ddlCondicion.Enabled = enable;
            notaTextBox.Enabled = enable;
            notaCustomValidator.Enabled = enable;

            PersonaLogic pl = new PersonaLogic();
            List<Persona> alumnos = new List<Persona>();
            foreach (Persona per in pl.GetAll())
            {
                if (per.TipoPersona == Persona.TipoPersonas.Alumno)
                {
                    alumnos.Add(per);
                }
            }
            ddlAlumno.DataSource = alumnos;
            ddlAlumno.DataTextField = "Legajo";
            ddlAlumno.DataValueField = "ID";
            ddlAlumno.DataBind();
            ddlAlumno.Enabled = enable;

            CursoLogic cl = new CursoLogic();
            ddlCurso.DataSource = cl.GetAll();
            ddlCurso.DataTextField = "ID";
            ddlCurso.DataValueField = "ID";
            ddlCurso.DataBind();
            ddlCurso.Enabled = enable;
        }
        private void ClearForm()
        {
            ddlCondicion.SelectedIndex = 0;
            notaTextBox.Text = string.Empty;
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
                    nuevoLinkButton.Visible = false;
                    eliminarLinkButton.Visible = false;
                    LoadGrid();
                }
                else if (Session["tipoPersona"].ToString() == Persona.TipoPersonas.Alumno.ToString())
                {
                    editarLinkButton.Visible = false;
                    LoadGrid();
                }
            }
            else
            {
                gridActionsPanel.Visible = false;
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
                ((Site)Master).HeaderText = "Inscripciones de Alumnos";
                ValidateUser();
            }
        }
        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridView.SelectedValue;
        }
        protected void notaCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlCondicion.SelectedIndex == 0 && string.IsNullOrEmpty(notaTextBox.Text) == false)
            {
                notaCustomValidator.ErrorMessage = "Los alumnos libres no deben llevar nota.";
                args.IsValid = false;
            }
            else if (ddlCondicion.SelectedIndex != 0 && string.IsNullOrEmpty(notaTextBox.Text) == true)
            {
                notaCustomValidator.ErrorMessage = "Los alumnos regulares o aprobados deben llevar nota.";
                args.IsValid = false;
            }
            else if (ddlCondicion.SelectedIndex != 0 && int.TryParse(notaTextBox.Text, out int result) == false)
            {
                notaCustomValidator.ErrorMessage = "Sólo se permiten notas numéricas.";
                args.IsValid = false;
            }
            else if (ddlCondicion.SelectedIndex != 0 && !(Convert.ToInt32(notaTextBox.Text) >= 5 && Convert.ToInt32(notaTextBox.Text) <= 10))
            {
                notaCustomValidator.ErrorMessage = "Los alumnos regulares/aprobados deben tener nota igual o superior a 5.";
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
            if (IsEntitySelected)
            {
                if (Session["tipoPersona"].ToString() == Persona.TipoPersonas.Admin.ToString())
                {
                    formActionsPanel.Visible = true;
                    formPanel.Visible = true;
                    FormMode = FormModes.Modificacion;
                    EnableForm(true);
                    LoadForm(SelectedID);
                }
                else if (Session["tipoPersona"].ToString() == Persona.TipoPersonas.Docente.ToString())
                {
                    formActionsPanel.Visible = true;
                    formPanel.Visible = true;
                    FormMode = FormModes.Modificacion;
                    EnableForm(true);
                    LoadForm(SelectedID);
                    ddlAlumno.Enabled = false;
                    ddlCurso.Enabled = false;
                }
            }
        }
        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                formPanel.Visible = true;
                formActionsPanel.Visible = true;
                FormMode = FormModes.Baja;

                EnableForm(false);
                LoadForm(SelectedID);
            }
        }
        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            if (Session["tipoPersona"].ToString() == Persona.TipoPersonas.Admin.ToString())
            {
                formActionsPanel.Visible = true;
                formPanel.Visible = true;
                FormMode = FormModes.Alta;
                ClearForm();
                EnableForm(true);
            }
            else if (Session["tipoPersona"].ToString() == Persona.TipoPersonas.Alumno.ToString())
            {
                formActionsPanel.Visible = true;
                formPanel.Visible = true;
                FormMode = FormModes.Alta;
                ClearForm();
                EnableForm(true);
                notaTextBox.Enabled = false;
                ddlCondicion.Enabled = false;
            }
        }

        //FormActionsPanel
        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid == true)
            {
                switch (FormMode)
                {
                    case FormModes.Baja:
                        DeleteEntity(SelectedID);
                        LoadGrid();
                        break;
                    case FormModes.Modificacion:
                        Entity = new AlumnoInscripcion();
                        Entity.ID = SelectedID;
                        Entity.State = BusinessEntity.States.Modified;

                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();

                        break;
                    case FormModes.Alta:
                        Entity = new AlumnoInscripcion();
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        break;
                    default:
                        break;
                }
                formPanel.Visible = false;
                formActionsPanel.Visible = false;
            }
        }
        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            ClearForm();
            EnableForm(false);
            formPanel.Visible = false;
            formActionsPanel.Visible = false;
        }
        #endregion

    }
}