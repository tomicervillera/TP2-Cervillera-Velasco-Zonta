using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic
    {
        //Miembros
        private Data.Database.ComisionAdapter _ComisionData;
        public Data.Database.ComisionAdapter ComisionData { get => _ComisionData; set => _ComisionData = value; }

        //Constructor
        public ComisionLogic()
        {
            ComisionData = new Data.Database.ComisionAdapter();
        }

        //Métodos
        public Business.Entities.Comision GetOne(int ID)
        {
            return (ComisionData.GetOne(ID));
        }
        public List<Comision> GetAll()
        {
            try
            {
                return (ComisionData.GetAll());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de especialidades.", Ex);
                throw ExcepcionManejada;
            }
        }
        public void Save(Business.Entities.Comision esp)
        {
            ComisionData.Save(esp);
        }
        public void Delete(int ID)
        {
            try
            {
                ComisionData.Delete(ID);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar especialidad.", Ex);
                throw ExcepcionManejada;
            }

        }



    }
}
