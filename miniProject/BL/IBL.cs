using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public interface IBL
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

        void addContract(BE.Child child, BE.Nanny nanny, bool isSigned);
        void removeContract(BE.Contract contract);
        void updateContract(BE.Contract contract);
        List<BE.Nanny> bestNannies(BE.Child child);
        List<BE.Nanny> nanniesList();
        List<BE.Mother> mothersList();
        List<BE.Child> childrenByMother(BE.Mother mother);
        List<BE.Contract> contractsList();

        List<BE.Child> childrenList();
        IEnumerable<BE.Contract> contractsByCondition(Func<BE.Contract, bool> predicate = null);

        //BY given  id of child return his mother 
        BE.Mother motherOfTheChild(int childId);

        BE.Nanny getNannyById(int nannyId);

        List<BE.Child> childrenByNanny(BE.Nanny nanny)
    }
    
}
