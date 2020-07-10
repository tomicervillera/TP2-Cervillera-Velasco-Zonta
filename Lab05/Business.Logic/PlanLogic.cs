using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
        //Miembros
        private Data.Database.PlanAdapter _PlanData;
        public Data.Database.PlanAdapter PlanData { get => _PlanData; set => _PlanData = value; }

        //Constructor
        public PlanLogic()
        {
            PlanData = new Data.Database.PlanAdapter();
        }

        //Métodos
        public Business.Entities.Plan GetOne(int ID)
        {
            return (PlanData.GetOne(ID));
        }
        public List<Plan> GetAll()
        {
            return (PlanData.GetAll());
        }
        public void Save(Business.Entities.Plan pla)
        {
            PlanData.Save(pla);
        }
        public void Delete(int ID)
        {
            PlanData.Delete(ID);
        }
    }
}
