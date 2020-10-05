using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class DocenteCursoDesktop : ApplicationForm
    {
        //Propiedades
        private Business.Entities.DocenteCurso _DocenteCursoActual;
        public Business.Entities.DocenteCurso DocenteCursoActual { get => _DocenteCursoActual; set => _DocenteCursoActual = value; }

        //Constructores
        public DocenteCursoDesktop()
        {
            InitializeComponent();
        }
        public DocenteCursoDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            cboxCargo.DataSource = Enum.GetNames(typeof(DocenteCurso.TiposCargos));
            
            CursoLogic cl = new CursoLogic();
            cboxCurso.DataSource = cl.GetAll();
            cboxCurso.ValueMember = "ID";
            cboxCurso.DisplayMember = "ID";

            PersonaLogic pl = new PersonaLogic();
            List<Persona> docentes = new List<Persona>();
            foreach (Persona per in pl.GetAll())
            {
                if (per.TipoPersona == Persona.TipoPersonas.Docente)
                {
                    docentes.Add(per);
                }
            }
            cboxDocente.DataSource = docentes;
            cboxDocente.ValueMember = "ID";
            cboxDocente.DisplayMember = "Legajo";
        }
        public DocenteCursoDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            DocenteCursoActual = new DocenteCursoLogic().GetOne(ID);
            MapearDeDatos();
        }

        //Métodos
        public override void MapearDeDatos()
        {
            txtID.Text = this.DocenteCursoActual.ID.ToString();
            cboxCargo.DataSource = Enum.GetNames(typeof(DocenteCurso.TiposCargos));
            cboxCargo.SelectedIndex = (int)DocenteCursoActual.Cargo;

            CursoLogic cl = new CursoLogic();
            cboxCurso.DataSource = cl.GetAll();
            cboxCurso.ValueMember = "ID";
            cboxCurso.DisplayMember = "ID";
            cboxCurso.SelectedValue = cl.GetOne(DocenteCursoActual.IDCurso).ID;

            PersonaLogic dl = new PersonaLogic();
            cboxDocente.DataSource = dl.GetAll();
            cboxDocente.ValueMember = "ID";
            cboxDocente.DisplayMember = "Legajo";
            cboxDocente.SelectedValue = dl.GetOne(DocenteCursoActual.IDDocente).ID;
            
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }
            else if (Modo == ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }

        }
        public override void MapearADatos()
        {

            if (Modo == ModoForm.Alta)
            {
                DocenteCursoActual = new Business.Entities.DocenteCurso();
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                DocenteCursoActual.Cargo = (DocenteCurso.TiposCargos)cboxCargo.SelectedIndex;
                DocenteCursoActual.IDCurso = Convert.ToInt32(((Curso)cboxCurso.SelectedItem).ID);
                DocenteCursoActual.IDDocente = Convert.ToInt32(((Persona)cboxDocente.SelectedItem).ID);

                switch (Modo)
                {
                    case ModoForm.Alta:
                        {
                            DocenteCursoActual.State = BusinessEntity.States.New;
                            break;
                        }
                    case ModoForm.Modificacion:
                        {
                            DocenteCursoActual.State = BusinessEntity.States.Modified;
                            break;
                        }
                    case ModoForm.Consulta:
                        {
                            DocenteCursoActual.State = BusinessEntity.States.Unmodified;
                            break;
                        }
                    case ModoForm.Baja:
                        {
                            DocenteCursoActual.State = BusinessEntity.States.Deleted;
                            break;
                        }
                }
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            new DocenteCursoLogic().Save(DocenteCursoActual);
        }
        public override bool Validar()
        {
            return (true);
        }

        //Eventos
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
