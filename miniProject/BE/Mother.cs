using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Mother
    {
        public int id;
        string lastName;
        string firstName;
        int phoneNumber;
        string address;
        string nannyRequestedAddress;
        public bool[] isNeedNannyToday = new bool[6];
        public DateTime[,] neededHours = new DateTime[2, 6];
        string notes;
        public override string ToString()
        {
            string str = "";
            str += "\nName: " + firstName + lastName;
            str += "\nneeded address for nanny in the area of " + nannyRequestedAddress;
            str += "\nneeded houres:";
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
        public Mother(int motherId,string firstN,string lastN,int phone,string motherAddress,string requestedAddress,bool[] needNannyDays,DateTime[,] houresNeeds,string note)
        {
            id = motherId;
            firstName = firstN;
            lastName = lastN;
            phoneNumber = phone;
            address = motherAddress;
            nannyRequestedAddress = requestedAddress;

            for (int i = 0; i < 6; i++)
                isNeedNannyToday[i] = needNannyDays[i];

            for (int i = 0; i < 6; i++)
            {
                neededHours[0, i] = houresNeeds[0, i];
                neededHours[1, i] = houresNeeds[1, i];
            }
            notes = note;
            {

            }
           
        }
    }
}
