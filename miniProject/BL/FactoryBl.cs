using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FactoryBL
    {
        static Bl_base bl = null;
        public static IBL GetBL()
        {
            bl = new Bl_base();
            return bl;
        }
    }
}
