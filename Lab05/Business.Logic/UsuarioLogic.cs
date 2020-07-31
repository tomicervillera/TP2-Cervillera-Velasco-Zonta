using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        //Miembros
        private Data.Database.UsuarioAdapter _UsuarioData;
        public Data.Database.UsuarioAdapter UsuarioData { get => _UsuarioData; set => _UsuarioData = value; }

        //Constructor
        public UsuarioLogic()
        {
            UsuarioData = new Data.Database.UsuarioAdapter();
        }

        //Métodos
        public Business.Entities.Usuario GetOne(int ID)
        {
            return(UsuarioData.GetOne(ID));
        }
        public List<Usuario> GetAll()
        {
            try { 
                return (UsuarioData.GetAll());
                }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
        }
        public void Save(Business.Entities.Usuario user)
        {
            UsuarioData.Save(user);
        }
        public void Delete(int ID)
        {
            UsuarioData.Delete(ID);
        }
        


    }
}
