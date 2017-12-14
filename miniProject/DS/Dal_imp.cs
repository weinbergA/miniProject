using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    
    public class Dal_imp : DAL.Idal
    {
        static int contractNumberStrat = 12345678;
        public void addNanny(BE.Nanny nanny)
        {
            BE.Nanny temp = DataSource.nanniesList.Find(x => x.id == nanny.id);
            if (temp == null)
                DataSource.nanniesList.Add(nanny);
            else
                throw new System.InvalidOperationException("This nanny already exist");
        }
        public void removeNanny(BE.Nanny nanny)
        {
            BE.Contract temp = DataSource.contractsList.Find(x => x.nannyId == nanny.id);
            if (temp == null)
                DataSource.nanniesList.Remove(nanny);//removing if only if she have no contruct
            else
                throw new System.InvalidOperationException("You can't delete nanny with active contract");
        }
        public void updateNanny(BE.Nanny nanny)
        {
            BE.Nanny temp = DataSource.nanniesList.Find(x => x.id == nanny.id);
            if (temp == null)
                throw new System.InvalidOperationException("The is no nanny to update");
            DataSource.nanniesList.Remove(temp);
            DataSource.nanniesList.Add(nanny);
        }
        
        public void addMother(BE.Mother mother)
        {
            BE.Mother temp = DataSource.mothersList.Find(x => x.id == mother.id);
            if (temp == null)
                DataSource.mothersList.Add(mother);
            else
                throw new System.InvalidOperationException("This mother already exist");
        }

        public void removeMother(BE.Mother mother)
        {
            DataSource.mothersList.Remove(mother);
            DataSource.childrenList.RemoveAll(x => x.motherId == mother.id);
            DataSource.contractsList.RemoveAll(x => x.motherId == mother.id);
        }


        public void updateMother(BE.Mother mother)
        {
            BE.Mother temp = DataSource.mothersList.Find(x => x.id == mother.id);
            if (temp == null)
                throw new System.InvalidOperationException("The is no mother to update");
            DataSource.mothersList.Remove(temp);
            DataSource.mothersList.Add(mother);
        }

        public void addChild(BE.Child child)
        {
            BE.Child temp = DataSource.childrenList.Find(x => x.id == child.id);
            if (temp == null)
                DataSource.childrenList.Add(child);
            else
                throw new System.InvalidOperationException("This child already exist");
        }
        public void removeChild(BE.Child child)
        {
            DataSource.contractsList.RemoveAll(x => x.childId == child.id);
            DataSource.childrenList.Remove(child);
        }
        public void updateChild(BE.Child child)
        {
            BE.Child temp = DataSource.childrenList.Find(x => x.id == child.id);
            if (temp == null)
                throw new System.InvalidOperationException("The is no child to update");
            DataSource.childrenList.Remove(temp);
            DataSource.childrenList.Add(child);
        }

        public void addContract(BE.Contract contract)
        {
            BE.Nanny temp1 = DataSource.nanniesList.Find(x => x.id == contract.nannyId);
            if (temp1 == null)
                throw new System.InvalidOperationException("wrong data, no nanny with this details");
            BE.Mother temp2 = DataSource.mothersList.Find(x => x.id == contract.motherId);
            if (temp2 == null)
                throw new System.InvalidOperationException("wrong data, no mother with this details");
            contract.contractNumber = contractNumberStrat++;
            DataSource.contractsList.Add(contract);
        }
        public void removeContract(BE.Contract contract)
        {
            DataSource.contractsList.Remove(contract);
        }
        public void updateContract(BE.Contract contract)
        {
            BE.Contract temp = DataSource.contractsList.Find(x => x.contractNumber == contract.contractNumber);
            if (temp == null)
                throw new System.InvalidOperationException("The is no contract to update");
            DataSource.contractsList.Remove(temp);
            DataSource.contractsList.Add(contract);
        }

        public List<BE.Nanny> nanniesList()
        {
            return DataSource.nanniesList;
        }
        public List<BE.Mother> mothersList()
        {
            return DataSource.mothersList;
        }
        public List<BE.Contract> contractsList()
        {
            return DataSource.contractsList;
        }

        public List<BE.Child> childrenByMother(BE.Mother mother)
        {
            List<BE.Child> temp = new List<BE.Child>();
            temp = DataSource.childrenList.FindAll(x => x.motherId == mother.id);
            return temp;
        }
        

        public BE.Mother motherOfTheChild(int childMotherId)
        {
            return DataSource.mothersList.Find(x => x.id == childMotherId);
        }
    }
}