using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Business.Logic
{
    public class EspecialidadLogic : BusinessLogic
    {
        //Miembros
        private Data.Database.EspecialidadAdapter _EspecialidadData;
        public Data.Database.EspecialidadAdapter EspecialidadData { get => _EspecialidadData; set => _EspecialidadData = value; }

        //Constructor
        public EspecialidadLogic()
        {
            EspecialidadData = new Data.Database.EspecialidadAdapter();
        }

        //Métodos
        public Business.Entities.Especialidad GetOne(int ID)
        {
            return (EspecialidadData.GetOne(ID));
        }
        public List<Especialidad> GetAll()
        {
            try
            {
                return (EspecialidadData.GetAll());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de especialidades.", Ex);
                throw ExcepcionManejada;
            }
        }
        public void Save(Business.Entities.Especialidad esp)
        {
            EspecialidadData.Save(esp);
        }
        public void Delete(int ID)
        {
            try
            {
                EspecialidadData.Delete(ID);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar especialidad.", Ex);
                throw ExcepcionManejada;
            }

        }



    }
}
