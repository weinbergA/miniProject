﻿using System;
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

        List<BE.Nanny> nanniesList();
        List<BE.Mother> mothersList();
        List<BE.Child> childrenByMother(BE.Mother mother);
        List<BE.Contract> contractsList();

        //BY given  id of child return his mother 
        BE.Mother motherOfTheChild(int childId);

        List<BE.Nanny> listOfMatchingNannies(BE.Mother mother);
    }
    public class FactoryBL
    {
        static IBL bl = null;
        public static IBL GetBL()
        {
            bl = new Bl_base();
            return bl;
        }
    }
}
