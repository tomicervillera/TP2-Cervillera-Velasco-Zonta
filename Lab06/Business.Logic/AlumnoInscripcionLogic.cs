using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Business.Logic
{
    public class AlumnoInscripcionLogic : BusinessLogic
    {
        #region Miembros
        private Data.Database.AlumnoInscripcionAdapter _AlumnoInscripcionData;
        public Data.Database.AlumnoInscripcionAdapter AlumnoInscripcionData { get => _AlumnoInscripcionData; set => _AlumnoInscripcionData = value; }
        #endregion

        #region Métodos
        //Constructor
        public AlumnoInscripcionLogic()
        {
            AlumnoInscripcionData = new Data.Database.AlumnoInscripcionAdapter();
        }

        //Funciones
        public Business.Entities.AlumnoInscripcion GetOne(int ID)
        {
            return (AlumnoInscripcionData.GetOne(ID));
        }
        public List<AlumnoInscripcion> GetAll()
        {
            try
            {
                return (AlumnoInscripcionData.GetAll());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de inscripciones de alumnos. ", Ex);
                throw ExcepcionManejada;
            }
        }
        public List<AlumnoInscripcion> GetFromAlumno(int ID)
        {
            try
            {
                return (AlumnoInscripcionData.GetFromAlumno(ID));
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar inscripciones de alumno. ", Ex);
                throw ExcepcionManejada;
            }
        }
        public List<AlumnoInscripcion> GetFromDocente(int ID)
        {
            try
            {
                return (AlumnoInscripcionData.GetFromDocente(ID));
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar inscripciones de alumnos del docente. ", Ex);
                throw ExcepcionManejada;
            }
        }
        public void Save(Business.Entities.AlumnoInscripcion alIns)
        {
            AlumnoInscripcionData.Save(alIns);
        }
        public void Delete(int ID)
        {
            AlumnoInscripcionData.Delete(ID);
        }
        #endregion
    }
}
