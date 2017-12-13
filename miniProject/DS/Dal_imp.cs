using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    public class Dal_imp: DAL.Idal
    {
        public void addNanny(BE.Nanny nanny)
        {
            DataSource.nanniesList.Add(nanny);
        }
        public void removeNanny(BE.Nanny nanny)
        {
           BE.Contract temp = DataSource.contractsList.Find(x => x.nannyId == nanny.id);
            if (temp ==null)
                DataSource.nanniesList.Remove(nanny);//removing if only if she have no contruct
            else
                throw new System.InvalidOperationException("You can't delete nanny with active contract");


        }
        public void updateNanny(BE.Nanny nanny)
        {
            
            int idNanny = nanny.id;
            BE.Nanny temp = DataSource.nanniesList.Find(x => x.id == idNanny);
            if (temp == null)
                throw new System.InvalidOperationException("The is no nanny to update");
            DataSource.nanniesList.Remove(temp);
            DataSource.nanniesList.Add(nanny);
        }










        public void addMother(BE.Mother mother)
        {
            DataSource.mothersList.Add(mother);
        }

        public void removeMother(BE.Mother mother)
        {
            DataSource.mothersList.Remove(mother);
            DataSource.childrenList.RemoveAll(x => x.motherId == mother.id);
            DataSource.contractsList.RemoveAll(x => x.motherId == mother.id);
        }


        public void updateMother(BE.Mother mother) { }

        public void addChild(BE.Child child) { }
        public void removeChild(BE.Child child) { }
        public void updateChild(BE.Child child) { }

        public void addContract(BE.Contract nanny) { }
        public void removeContract(BE.Contract nanny) { }
        public void updateContract(BE.Contract nanny) { }

        public List<BE.Nanny> nanniesList() { }
        public List<BE.Mother> mothersList() { }
        public List<BE.Child> childrenByMother(BE.Mother mother) { }
        public List<BE.Contract> contractsList() { }

        BE.Mother motherOfTheChild(BE.Child child)
        {
            return DataSource.mothersList.Find(x => x.id == child.motherId);
        }
    }
}
