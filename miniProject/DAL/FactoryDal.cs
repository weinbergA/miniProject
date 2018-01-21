using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class FactoryDal
    {
        public static Idal GetDal()
        {
            return DalXml.dal();
        }
    }
}
