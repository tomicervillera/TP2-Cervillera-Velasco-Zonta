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
        //Miembros
        private Data.Database.AlumnoInscripcionAdapter _AlumnoInscripcionData;
        public Data.Database.AlumnoInscripcionAdapter AlumnoInscripcionData { get => _AlumnoInscripcionData; set => _AlumnoInscripcionData = value; }

        //Constructor
        public AlumnoInscripcionLogic()
        {
            AlumnoInscripcionData = new Data.Database.AlumnoInscripcionAdapter();
        }

        //Métodos
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
        public void Save(Business.Entities.AlumnoInscripcion alIns)
        {
            AlumnoInscripcionData.Save(alIns);
        }
        public void Delete(int ID)
        {
            AlumnoInscripcionData.Delete(ID);
        }
    }
}
