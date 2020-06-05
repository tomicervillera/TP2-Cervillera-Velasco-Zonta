using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UI.Consola
{
    public class Usuarios
    {
        private Business.Logic.UsuarioLogic _usuarioNegocio;
        public UsuarioLogic UsuarioNegocio { get => _usuarioNegocio; set => _usuarioNegocio = value; }

        public Usuarios()
        {
            UsuarioNegocio = new Business.Logic.UsuarioLogic();
        }
    }
    
}
