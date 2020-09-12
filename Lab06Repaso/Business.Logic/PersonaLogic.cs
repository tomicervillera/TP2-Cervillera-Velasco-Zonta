using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Business.Logic
{
    public class PersonaLogic : BusinessLogic
    {
        //Miembros
        private Data.Database.PersonaAdapter _PersonaData;
        public Data.Database.PersonaAdapter PersonaData { get => _PersonaData; set => _PersonaData = value; }

        //Constructor
        public PersonaLogic()
        {
            PersonaData = new Data.Database.PersonaAdapter();
        }

        //Métodos
        public Business.Entities.Persona GetOne(int ID)
        {
            return(PersonaData.GetOne(ID));
        }
        public List<Persona> GetAll()
        {
            try 
            { 
                return (PersonaData.GetAll());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de personas.", Ex);
                throw ExcepcionManejada;
            }
        }
        public void Save(Business.Entities.Persona per)
        {
            PersonaData.Save(per);
        }
        public void Delete(int ID)
        {
            PersonaData.Delete(ID);
        }
        


    }
}
