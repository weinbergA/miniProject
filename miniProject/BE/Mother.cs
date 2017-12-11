using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    class Mother
    {
        int id;
        string lastName;
        string firstName;
        int phoneNumber;
        string address;
        string nannyRequestedAddress;
        bool[] isNeedNannyToday = new bool[6];
        DateTime[,] neededHours = new DateTime[2, 6];
        string notes;
        public override string ToString()
        {
            string str = "";
            str += "\nName: " + firstName + lastName;
            str += "\nneeded address for nanny in the area of " + nannyRequestedAddress;
            str += "/nneeded houres:";
            for (int i = 0; i < 6; i++)
            {
                if (isNeedNannyToday[i])
                {
                    str += (neededHours[0, i]).DayOfWeek + ": ";
                    str += (neededHours[0, i]).Hour + " - ";
                    str += (neededHours[1, i]).Hour + "\n";
                }
            }
            return str;
        }
    }
}
