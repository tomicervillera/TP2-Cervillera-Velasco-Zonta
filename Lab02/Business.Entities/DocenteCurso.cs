﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class DocenteCurso: BusinessEntity
    {
        public enum TiposCargos
        {
            Docente,
            JefeCatedra,
            Auxiliar
        }
        
        private int _IDCurso;
        public int IDCurso
        {
            get
            {
                return (_IDCurso);
            }
            set
            {
                _IDCurso = value;
            }
        }
        
        private int _IDDocente;
        public int IDDocente
        {
            get
            {
                return (_IDDocente);
            }
            set
            {
                _IDDocente = value;
            }
        }

        private TiposCargos _Cargo;
        public TiposCargos Cargo
        {
            get
            {
                return _Cargo;
            }
            set
            {
                _Cargo = value;
            }
        }

    }
}