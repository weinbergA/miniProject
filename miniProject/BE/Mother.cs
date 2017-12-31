using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Mother
    {
        public int id;
        public string lastName;
        public string firstName;
        public int phoneNumber;
        public string address;
        public string nannyRequestedAddress;
        public bool[] isNeedNannyToday = new bool[6];
        public TimeSpan[,] neededHours = new TimeSpan[2, 6];
        public string notes;
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
                    str += (neededHours[0, i]).ToString() + "\n";
                    str += (neededHours[1, i]).ToString() + "\n";
                }
            }
            return str;
        }
        public Mother(int motherId,string firstN,string lastN,int phone,string motherAddress,string requestedAddress,bool[] needNannyDays, TimeSpan[,] houresNeeds,string note)
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
        public Mother() { }
    }
}
