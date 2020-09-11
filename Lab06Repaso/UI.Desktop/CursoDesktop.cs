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
    public partial class CursoDesktop : ApplicationForm
    {
        //Propiedades
        private Business.Entities.Curso _CursoActual;
        public Business.Entities.Curso CursoActual { get => _CursoActual; set => _CursoActual = value; }

        //Constructores
        public CursoDesktop()
        {
            InitializeComponent();
        }
        public CursoDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            ComisionLogic cl = new ComisionLogic();
            cboxComision.DataSource = cl.GetAll();
            cboxComision.ValueMember = "ID";
            cboxComision.DisplayMember = "Descripcion";

            MateriaLogic ml = new MateriaLogic();
            cboxMateria.DataSource = ml.GetAll();
            cboxMateria.ValueMember = "ID";
            cboxMateria.DisplayMember = "Descripcion";
        }
        public CursoDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            CursoActual = new CursoLogic().GetOne(ID);
            MapearDeDatos();
        }

        //Métodos
        public override void MapearDeDatos()
        {
            txtID.Text = this.CursoActual.ID.ToString();
            txtAnioCalendario.Text = CursoActual.AnioCalendario.ToString();
            txtCupo.Text= CursoActual.Cupo.ToString();

            ComisionLogic cl = new ComisionLogic();
            cboxComision.DataSource = cl.GetAll();
            cboxComision.ValueMember = "ID";
            cboxComision.DisplayMember = "Descripcion";
            cboxComision.SelectedValue = cl.GetOne(CursoActual.IDComision).ID;

            MateriaLogic ml = new MateriaLogic();
            cboxMateria.DataSource = ml.GetAll();
            cboxMateria.ValueMember = "ID";
            cboxMateria.DisplayMember = "Descripcion";
            cboxMateria.SelectedValue = ml.GetOne(CursoActual.IDMateria).ID;

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
                CursoActual = new Business.Entities.Curso();
            }
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                CursoActual.AnioCalendario = Convert.ToInt32(txtAnioCalendario.Text);
                CursoActual.Cupo = Convert.ToInt32(txtCupo.Text);

                CursoActual.IDComision = Convert.ToInt32(((Comision)cboxComision.SelectedItem).ID);
                CursoActual.IDMateria = Convert.ToInt32(((Materia)cboxMateria.SelectedItem).ID);


                switch (Modo)
                {
                    case ModoForm.Alta:
                        {
                            CursoActual.State = BusinessEntity.States.New;
                            break;
                        }
                    case ModoForm.Modificacion:
                        {
                            CursoActual.State = BusinessEntity.States.Modified;
                            break;
                        }
                    case ModoForm.Consulta:
                        {
                            CursoActual.State = BusinessEntity.States.Unmodified;
                            break;
                        }
                    case ModoForm.Baja:
                        {
                            CursoActual.State = BusinessEntity.States.Deleted;
                            break;
                        }
                }
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            new CursoLogic().Save(CursoActual);
        }
        public override bool Validar()
        {
            foreach (Control oControls in this.tableLayoutPanel1.Controls) // Buscamos en cada TextBox de nuestro Formulario.
            {
                if (oControls is TextBox & oControls.Text == String.Empty & oControls.Name != "txtID") // Verificamos que no este vacio exceptuando al txtID porque se asigna automáticamente.
                {
                    Notificar("Hay al menos un campo vacío. Por favor, completelo/s. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return (false);
                }
            }
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
