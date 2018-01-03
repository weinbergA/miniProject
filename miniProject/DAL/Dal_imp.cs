using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL
{

    public class Dal_imp : Idal
    {
        static int contractNumberStrat = 12345678;
        public void addNanny(BE.Nanny nanny)
        {
            
            BE.Nanny temp = DS.DataSource.nanniesList.Find(x => x.id == nanny.id);
            if (temp == null)
                DS.DataSource.nanniesList.Add(nanny);
            else
                throw new Exception("This nanny already exist");
        }
        public void removeNanny(BE.Nanny nanny)
        {
            BE.Contract temp = DS.DataSource.contractsList.Find(x => x.nannyId == nanny.id);
            if (temp == null)
                DS.DataSource.nanniesList.Remove(nanny);//removing if only if she have no contruct
            else
                throw new Exception("You can't delete nanny with active contract");
        }
        public void updateNanny(BE.Nanny nanny)
        {
            BE.Nanny temp = DS.DataSource.nanniesList.Find(x => x.id == nanny.id);
            if (temp == null)
                throw new Exception("The is no nanny to update");
            DS.DataSource.nanniesList.Remove(temp);
            DS.DataSource.nanniesList.Add(nanny);
        }

        public void addMother(BE.Mother mother)
        {
            BE.Mother temp = DS.DataSource.mothersList.Find(x => x.id == mother.id);
            if (temp == null)
                DS.DataSource.mothersList.Add(mother);
            else
                throw new Exception("This mother already exist");
        }

        public void removeMother(BE.Mother mother)
        {
            DS.DataSource.mothersList.Remove(mother);
            DS.DataSource.childrenList.RemoveAll(x => x.motherId == mother.id);
            DS.DataSource.contractsList.RemoveAll(x => x.motherId == mother.id);
        }


        public void updateMother(BE.Mother mother)
        {
            BE.Mother temp = DS.DataSource.mothersList.Find(x => x.id == mother.id);
            if (temp == null)
                throw new Exception("The is no mother to update");
            DS.DataSource.mothersList.Remove(temp);
            DS.DataSource.mothersList.Add(mother);
        }

        public void addChild(BE.Child child)
        {
            BE.Child temp = DS.DataSource.childrenList.Find(x => x.Id == child.Id);
            if (temp == null)
                DS.DataSource.childrenList.Add(child);
            else
                throw new Exception("This child already exist");
        }
        public void removeChild(BE.Child child)
        {
            DS.DataSource.contractsList.RemoveAll(x => x.childId == child.Id);
            DS.DataSource.childrenList.Remove(child);
        }
        public void updateChild(BE.Child child)
        {
            BE.Child temp = DS.DataSource.childrenList.Find(x => x.Id == child.Id);
            if (temp == null)
                throw new Exception("The is no child to update");
            DS.DataSource.childrenList.Remove(temp);
            DS.DataSource.childrenList.Add(child);
        }

        public void addContract(BE.Contract contract)
        {
            BE.Nanny temp1 = DS.DataSource.nanniesList.Find(x => x.id == contract.nannyId);
            if (temp1 == null)
                throw new Exception("wrong data, no nanny with this details");
            BE.Mother temp2 = DS.DataSource.mothersList.Find(x => x.id == contract.motherId);
            if (temp2 == null)
                throw new Exception("wrong data, no mother with this details");
            contract.contractNumber = contractNumberStrat++;
            DS.DataSource.contractsList.Add(contract);
        }
        public void removeContract(BE.Contract contract)
        {
            DS.DataSource.contractsList.Remove(contract);
        }
        public void updateContract(BE.Contract contract)
        {
            BE.Contract temp = DS.DataSource.contractsList.Find(x => x.contractNumber == contract.contractNumber);
            if (temp == null)
                throw new Exception("The is no contract to update");
            DS.DataSource.contractsList.Remove(temp);
            DS.DataSource.contractsList.Add(contract);
        }

        public List<BE.Nanny> nanniesList()
        {
            return DS.DataSource.nanniesList;
        }
        public List<BE.Mother> mothersList()
        {
            return DS.DataSource.mothersList;
        }
        public List<BE.Contract> contractsList()
        {
            return DS.DataSource.contractsList;
        }
        public List<BE.Child> childrenList()
        {
            return DS.DataSource.childrenList;
        }

        public List<BE.Child> childrenByMother(BE.Mother mother)
        {
            List<BE.Child> temp = new List<BE.Child>();
            temp = DS.DataSource.childrenList.FindAll(x => x.motherId == mother.id);
            return temp;
        }


        public BE.Mother motherOfTheChild(int childMotherId)
        {
            return DS.DataSource.mothersList.Find(x => x.id == childMotherId);
        }
        public BE.Mother getMotherById(int motherId)
        {
            return DS.DataSource.mothersList.Find(x => x.id == motherId);
        }
        public BE.Nanny GetNannyById(int nannyId)
        {
            return DS.DataSource.nanniesList.Find(x => x.id == nannyId);
        }

        public BE.Child getChildByID(int childId)
        {
            return DS.DataSource.childrenList.Find(x => x.Id == childId);
        }

        public IEnumerable<BE.Contract> contrantsByCondition(Func<BE.Contract, bool> predicate = null)
        {
            if (predicate == null)
                return DS.DataSource.contractsList.AsEnumerable();
            return DS.DataSource.contractsList.Where(predicate);
        }
    }
}