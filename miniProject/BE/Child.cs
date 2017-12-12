using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    class Child
    {
        int id;
        int motherId;
        string firstName;
        string lastName;
        DateTime dateOfBirth;
        bool sepcialNeeds;
        string sepcialNeedsDescrition;
        public override string ToString()
        {
            string str = "";
            str += "Name; " + firstName + " " + lastName + "\n";
            //add mother name;
            if (sepcialNeeds)
                str += "Has sepcial needs: " + sepcialNeedsDescrition + "\n";

            return str;
        }
    }
}
