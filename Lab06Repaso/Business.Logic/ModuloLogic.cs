using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;


namespace Business.Logic
{
    public class ModuloLogic : BusinessLogic
    {
        //Miembros
        private Data.Database.ModuloAdapter _ModuloData;
        public Data.Database.ModuloAdapter ModuloData { get => _ModuloData; set => _ModuloData = value; }

        //Constructor
        public ModuloLogic()
        {
            ModuloData = new Data.Database.ModuloAdapter();
        }

        //Métodos
        public Business.Entities.Modulo GetOne(int ID)
        {
            return (ModuloData.GetOne(ID));
        }
        public List<Modulo> GetAll()
        {
            try
            {
                return (ModuloData.GetAll());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de modulos.", Ex);
                throw ExcepcionManejada;
            }
        }
        public void Save(Business.Entities.Modulo esp)
        {
            ModuloData.Save(esp);
        }
        public void Delete(int ID)
        {
            try
            {
                ModuloData.Delete(ID);
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar modulo.", Ex);
                throw ExcepcionManejada;
            }

        }



    }
}
