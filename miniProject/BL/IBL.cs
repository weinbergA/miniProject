using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    interface IBL
    {
        void addNanny(BE.Nanny nanny);
        void removeNanny(BE.Nanny nanny);
        void updateNanny(BE.Nanny nanny);

        void addMother(BE.Mother nanny);
        void removeMother(BE.Mother nanny);
        void updateMother(BE.Mother nanny);

        void addChild(BE.Child nanny);
        void removeChild(BE.Child nanny);
        void updateChild(BE.Child nanny);

        void addContract(BE.Contract nanny);
        void removeContract(BE.Contract nanny);
        void updateContract(BE.Contract nanny);

        List<BE.Nanny> nanniesList();
        List<BE.Mother> mothersList();
        List<BE.Child> childrenByMother(BE.Mother mother);
        List<BE.Contract> contractsList();

        //BY given  id of child return his mother 
        BE.Mother motherOfTheChild(int childId);
    }
}
