using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Business.Logic
{
    class UsuarioLogic:BusinessLogic
    {
        private Data.Database.UsuarioAdapter _UsuarioData;

        public Data.Database.UsuarioAdapter UsuarioData { get => _UsuarioData; set => _UsuarioData = value; }

        public Business.Entities.Usuario GetOne(int ID)
        {
            return(UsuarioData.GetOne(ID));
        }

        public List<Usuario> GetAll()
        {
            return(UsuarioData.GetAll());
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }

        public void Delete()
        {
            throw new System.NotImplementedException();
        }

        public UsuarioLogic()
        {
            UsuarioData = new Data.Database.UsuarioAdapter();
        }
    }
}
