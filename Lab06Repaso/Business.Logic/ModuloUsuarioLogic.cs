using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Business.Logic
{
    public class ModuloUsuarioLogic : BusinessLogic
    {
        //Miembros
        private Data.Database.ModuloUsuarioAdapter _ModuloUsuarioData;
        public Data.Database.ModuloUsuarioAdapter ModuloUsuarioData { get => _ModuloUsuarioData; set => _ModuloUsuarioData = value; }

        //Constructor
        public ModuloUsuarioLogic()
        {
            ModuloUsuarioData = new Data.Database.ModuloUsuarioAdapter();
        }

        //Métodos
        public Business.Entities.ModuloUsuario GetOne(int ID)
        {
            return (ModuloUsuarioData.GetOne(ID));
        }
        public List<ModuloUsuario> GetAll()
        {
            try
            {
                return (ModuloUsuarioData.GetAll());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de módulos por usuarios. ", Ex);
                throw ExcepcionManejada;
            }

        }
        public void Save(Business.Entities.ModuloUsuario modUs)
        {
            ModuloUsuarioData.Save(modUs);
        }
        public void Delete(int ID)
        {
            ModuloUsuarioData.Delete(ID);
        }
    }
}
