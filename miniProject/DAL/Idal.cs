using System;
using System.Collections.Generic;
using System.Text;


namespace DAL
{
    public interface Idal
    {
        void addNanny(BE.Nanny nanny);
        void removeNanny(BE.Nanny nanny);
        void updateNanny(BE.Nanny nanny);

        void addMother(BE.Mother mother);
        void removeMother(BE.Mother mother);
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
        BE.Mother getMotherById(int motherId);
       
    }
}
