using System;
using System.Collections.Generic;
using System.Linq;
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
            return (EspecialidadData.GetAll());
        }
        public void Save(Business.Entities.Especialidad esp)
        {
            EspecialidadData.Save(esp);
        }
        public void Delete(int ID)
        {
            EspecialidadData.Delete(ID);
        }



    }
}
