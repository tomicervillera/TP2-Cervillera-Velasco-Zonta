using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic 
    {
        //Miembros 
        private Data.Database.MateriaAdapter _MateriaData;
        public Data.Database.MateriaAdapter MateriaData { get => _MateriaData; set => _MateriaData = value; }

        //Constructor
        public MateriaLogic()
        {
            MateriaData = new Data.Database.MateriaAdapter();
        }

        //Métodos
        public Business.Entities.Materia GetOne(int ID)
        {
            return (MateriaData.GetOne(ID));
        }
        public List<Materia> GetAll()
        {
            try
            {
                return (MateriaData.GetAll());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de materias.", Ex);
                throw ExcepcionManejada;
            }
        }
        public void Save(Business.Entities.Materia per)
        {
            MateriaData.Save(per);
        }
        public void Delete(int ID)
        {
            MateriaData.Delete(ID);
        }






    }
}
