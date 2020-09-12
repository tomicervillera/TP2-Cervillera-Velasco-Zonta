using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Business.Logic
{
    public class DocenteCursoLogic : BusinessLogic
    {
        //Miembros
        private Data.Database.DocenteCursoAdapter _DocenteCursoData;
        public Data.Database.DocenteCursoAdapter DocenteCursoData { get => _DocenteCursoData; set => _DocenteCursoData = value; }

        //Constructor
        public DocenteCursoLogic()
        {
            DocenteCursoData = new Data.Database.DocenteCursoAdapter();
        }

        //Métodos
        public Business.Entities.DocenteCurso GetOne(int ID)
        {
            return (DocenteCursoData.GetOne(ID));
        }
        public List<DocenteCurso> GetAll()
        {
            try
            {
                return (DocenteCursoData.GetAll());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de docentes por cursos. ", Ex);
                throw ExcepcionManejada;
            }

        }
        public void Save(Business.Entities.DocenteCurso docCur)
        {
            DocenteCursoData.Save(docCur);
        }
        public void Delete(int ID)
        {
            DocenteCursoData.Delete(ID);
        }
    }
}
