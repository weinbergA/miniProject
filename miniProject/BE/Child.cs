using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Child
    {
        public int id;
        public int motherId;
        string firstName;
        string lastName;
        DateTime dateOfBirth;
        bool specialNeeds;
        string specialNeedsDescrition;
        public override string ToString()
        {
            string str = "";
            str += "Name; " + firstName + " " + lastName + "\n";
            //add mother name;
            if (specialNeeds)
                str += "Has sepcial needs: " + specialNeedsDescrition + "\n";

            return str;
        }

        public Child(int childId,int idMother, string firstN,string lastN,DateTime birth, bool sNeeds,string sNeedsD)
        {
            id = childId;
            motherId = idMother;
            firstName = firstN;
            lastName = lastN;
            dateOfBirth = birth;
            if (specialNeeds)
                sNeedsD = specialNeedsDescrition;
        }
    }
}
