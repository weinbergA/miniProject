using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    class Bl_base : IBL
    {
        DS.Dal_imp dal = new DS.Dal_imp();

        void addNanny(BE.Nanny nanny)
        {
            DateTime now = DateTime.Now;
            if (!(now.Year - nanny.dateOfBirth.Year >= 18))
                throw new Exception("Nanny can't be under 18 years old");
            dal.addNanny(nanny);
        }
        void removeNanny(BE.Nanny nanny)
        {
            dal.removeNanny(nanny);
        }


        void updateNanny(BE.Nanny nanny)
        {
            dal.updateNanny(nanny);
        }

        void addMother(BE.Mother mother)
        {
            dal.updateMother(mother);
        }
        void removeMother(BE.Mother mother)
        {
            dal.removeMother(mother);
        }

        void updateMother(BE.Mother mother)
        {
            dal.updateMother(mother);
        }

        void addChild(BE.Child child)
        {
            DateTime now = DateTime.Now;
            if (now.Month - child.dateOfBirth.Month < 3)
                throw new Exception("The child can't under 3 months");
            dal.addChild(child);
        }
        void removeChild(BE.Child child)
        {
            dal.removeChild(child);
        }
        void updateChild(BE.Child child)
        {
            dal.updateChild(child);
        }


        void addContract(BE.Contract contract)
        {
            BE.Mother mother = dal.getMotherById(contract.motherId);
            BE.Nanny nanny = dal.GetNannyById(contract.nannyId);

            if (nanny.hourlyRateAccepting && contract.monthlyOrHourly == BE.hourlyOrMonthly.hourly)
            {
                double sumHours = 0;
                for (int i = 0; i < 6; i++)
                    sumHours += mother.neededHours[1, i].Hour - mother.neededHours[0, i].Hour;
                contract.HourlyRate = nanny.HourlyRate;
                contract.MonthlyRate = (sumHours * 52) / 12;
            }
            else
                contract.MonthlyRate = nanny.MonthlyRate;
            int sumChild = (dal.contractsList()).FindAll(x => x.motherId == mother.id && x.nannyId == nanny.id).Count;
            contract.motherId


        }
        void removeContract(BE.Contract contract);
        void updateContract(BE.Contract contract);

        List<BE.Nanny> nanniesList();
        List<BE.Mother> mothersList();
        List<BE.Child> childrenByMother(BE.Mother mother);
        List<BE.Contract> contractsList();

        //BY given  id of child return his mother 
        BE.Mother motherOfTheChild(int childId);
    }
}
