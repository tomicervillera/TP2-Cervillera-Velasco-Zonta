using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Plan: BusinessEntity
    {
        private string _Descripcion;
        private int _IdEspecialidad;

        public string Descripcion
        {
            get
            {
                return (_Descripcion);
            }
            set
            {
                _Descripcion = value;
            }
        }

        public int IdEspecialidad
        {
            get => default;
            set
            {
            }
        }
    }
}