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
        public void Menu()
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
                        Consultar();
                        break;
                    }
                case '3':
                    {
                        Agregar();
                        Consultar();
                        break;
                    }
                case '4':
                    {
                        Modificar();

                        break;
                    }
                case '5':
                    {
                        Eliminar();
                      
                        break;
                    }
                case '6':
                    {
                        break;
                    }
            }

        }
        public void ListadoGeneral()
        {
            Console.Clear();
            foreach (Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
        }
        public void MostrarDatos(Usuario usr)
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
        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese ID del usuario a modificar: ");
                int ID = Convert.ToInt32(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(ID);
                Console.Write("Ingrese Nombre: ");
                usuario.Nombre = Console.ReadLine();
                Console.Write("Ingrese Apellido: ");
                usuario.Apellido = Console.ReadLine();
                Console.WriteLine("Ingrese Nombre de Usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.Write("Ingrese Clave: ");
                usuario.Clave = Console.ReadLine();
                Console.Write("Ingrese Email: ");
                usuario.Email = Console.ReadLine();
                Console.Write("Ingrese Habilitación de Usuario (1-Sí/otro-No): ");
                usuario.Habilitado = (Console.ReadLine() == "1");
                usuario.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(usuario);

            }
            catch (FormatException e)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un nnúmero entero. ");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar. ");
                Console.ReadKey();
            }

        }
        public void Consultar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese ID del usuario a consultar a consultar: ");
                int ID = Convert.ToInt32(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
            }
            catch (FormatException e)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un número entero. ");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar. ");
                Console.ReadKey();
            }

        }
        public void Agregar()
        {
            Usuario usuario = new Usuario();
            Console.Clear();
            Console.Write("Ingrese Nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.Write("Ingrese Apellido: ");
            usuario.Apellido = Console.ReadLine();
            Console.Write("Ingrese Nombre de Usuario: ");
            usuario.NombreUsuario = Console.ReadLine();
            Console.Write("Ingrese Clave: ");
            usuario.Clave = Console.ReadLine();
            Console.Write("Ingrese Email: ");
            usuario.Email = Console.ReadLine();
            Console.Write("Ingrese Habilitación de Usuario (1-Sí/otro-No): ");
            usuario.Habilitado = (Console.ReadLine() == "1");
            usuario.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(usuario);
            Console.WriteLine();
            Console.WriteLine("ID: (0)", usuario.ID);
        }
        public void Eliminar()
        {
            try
            { 
                Console.Clear();
                Console.Write("Ingrese ID del usuario a eliminar: ");
                int ID = Convert.ToInt32(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
            }
            catch(FormatException e)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un número entero. ");
            }
            catch(Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar. ");
                Console.ReadKey();

            }
        }
    }
    
}
