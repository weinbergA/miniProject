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

        }

        void updateMother(BE.Mother mother);

        void addChild(BE.Child child);
        void removeChild(BE.Child child);
        void updateChild(BE.Child child);

        void addContract(BE.Contract contract);
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
