using System;
using System.Collections.Generic;
using System.Text;

namespace DS
{
    public class Dal_imp: DAL.Idal
    {
        public void addNanny(BE.Nanny nanny) { }
        public void removeNanny(BE.Nanny nanny) { }
        public void updateNanny(BE.Nanny nanny) { }

        public void addMother(BE.Mother nanny) { }
        public void removeMother(BE.Mother nanny) { }
        public void updateMother(BE.Mother nanny) { }

        public void addChild(BE.Child nanny) { }
        public void removeChild(BE.Child nanny) { }
        public void updateChild(BE.Child nanny) { }

        public void addContract(BE.Contract nanny) { }
        public void removeContract(BE.Contract nanny) { }
        public void updateContract(BE.Contract nanny) { }

        public List<BE.Nanny> nanniesList() { }
        public List<BE.Mother> mothersList() { }
        public List<BE.Child> childrenByMother(BE.Mother mother) { }
        public List<BE.Contract> contractsList() { }
    }
}
