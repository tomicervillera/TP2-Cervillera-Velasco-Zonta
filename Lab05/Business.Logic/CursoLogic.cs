using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Business.Logic
{
    public class CursoLogic : BusinessLogic
    {
        //Miembros
        private Data.Database.CursoAdapter _CursoData;
        public Data.Database.CursoAdapter CursoData { get => _CursoData; set => _CursoData = value; }

        //Constructor
        public CursoLogic()
        {
            CursoData = new Data.Database.CursoAdapter();
        }

        //Métodos
        public Business.Entities.Curso GetOne(int ID)
        {
            return (CursoData.GetOne(ID));
        }
        public List<Curso> GetAll()
        {
            try
            {
                return (CursoData.GetAll());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos. ", Ex);
                throw ExcepcionManejada;
            }

        }
        public void Save(Business.Entities.Curso modUs)
        {
            CursoData.Save(modUs);
        }
        public void Delete(int ID)
        {
            CursoData.Delete(ID);
        }
    }
}
