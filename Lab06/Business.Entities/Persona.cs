using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Persona: BusinessEntity
    {
        private string _Apellido;
        public string Apellido
        {
            get
            {
                return (_Apellido);
            }
            set
            {
                _Apellido = value;
            }
        }

        private string _Direccion;
        public string Direccion
        {
            get
            {
                return (_Direccion);
            }
            set
            {
                _Direccion = value;
            }
        }

        private string _Email;
        public string Email
        {
            get
            {
                return (_Email);
            }
            set
            {
                _Email = value;
            }
        }

        private DateTime _FechaNacimiento;
        public DateTime FechaNacimiento
        {
            get
            {
                return (_FechaNacimiento);
            }
            set
            {
                _FechaNacimiento = value;
            }
        }

        private int _IDPlan;
        public int IDPlan
        {
            get
            {
                return (_IDPlan);
            }
            set
            {
                _IDPlan = value;
            }
        }

        private int _Legajo;
        public int Legajo
        {
            get
            {
                return (_Legajo);
            }
            set
            {
                _Legajo = value;
            }
        }

        private string _Nombre;
        public string Nombre
        {
            get
            {
                return (_Nombre);
            }
            set
            {
                _Nombre = value;
            }
        }

        private string _Telefono;
        public string Telefono
        {
            get
            {
                return (_Telefono);
            }
            set
            {
                _Telefono = value;
            }
        }

        public enum TipoPersonas
        {
            Alumno,
            Docente,
            Admin
        }

        private TipoPersonas _TipoPersona;
        public TipoPersonas TipoPersona
        {
            get
            {
                return (_TipoPersona);
            }
            set
            {
                _TipoPersona = value;
            }
        }

        private string _NombreUsuario;
        public string NombreUsuario
        {
            get
            {
                return (_NombreUsuario);
            }
            set
            {
                _NombreUsuario = value;
            }
        }

        private string _Clave;
        public string Clave
        {
            get
            {
                return (_Clave);
            }
            set
            {
                _Clave = value;
            }
        }

        private bool _Habilitado;
        public bool Habilitado
        {
            get
            {
                return (_Habilitado);
            }
            set
            {
                _Habilitado = value;
            }
        }




    }
}