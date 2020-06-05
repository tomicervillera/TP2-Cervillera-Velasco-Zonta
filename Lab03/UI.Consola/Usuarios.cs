using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;


namespace UI.Consola
{
    public class Usuarios
    {
        private Business.Logic.UsuarioLogic _usuarioNegocio;
        public Business.Logic.UsuarioLogic UsuarioNegocio { get => _usuarioNegocio; set => _usuarioNegocio = value; }

        public Usuarios()
        {
            UsuarioNegocio = new Business.Logic.UsuarioLogic();
        }
        static public void Menu()
        {
            char opcion;
            Console.WriteLine("Ingrese opción: \n1– Listado General \n2– Consulta \n3– Agregar \n4- Modificar \n5- Eliminar \n6- Salir");
            opcion = Console.ReadKey().KeyChar;
            switch (opcion)
            {
                case '1':
                    {
                        ListadoGeneral();
                        break;
                    }
                case '2':
                    {
                        break;
                    }
                case '3':
                    {
                        break;
                    }
                case '4':
                    {
                        break;
                    }
                case '5':
                    {
                        break;
                    }
                case '6':
                    {
                        break;
                    }
            }
        }
        static public void ListadoGeneral()
        {
            Usuarios pepe = new Usuarios();
            Console.Clear();
            foreach (Usuario usr in pepe.UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
        }
        static public void MostrarDatos(Usuario usr)
        {
            Console.WriteLine("Usuario: {0}", usr.ID);
            Console.WriteLine("\t\tNombre: {0}", usr.Nombre);
            Console.WriteLine("\t\tApellido: {0}", usr.Apellido);
            Console.WriteLine("\t\tNombre de Usuario: {0}", usr.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}", usr.Clave);
            Console.WriteLine("\t\tEmail: {0}", usr.Email);
            Console.WriteLine("\t\tHabilitado: {0}", usr.Habilitado);
            Console.WriteLine();
        }

    }
    
}
