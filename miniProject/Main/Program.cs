using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    public class Distance
    {
        static public double Getdistance(string source, string dest)
        {
            TravelType travelType = TravelType.Walking;
            return GoogleApiFunc.CalcDistance(source,  dest, travelType );
        }

    }
}
