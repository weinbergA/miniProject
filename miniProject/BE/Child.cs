using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Child
    {
        public int Id { get; set; }
        public int motherId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public bool specialNeeds { get; set; }
        public string specialNeedsDescrition { get; set; }



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
            Id = childId;
            motherId = idMother;
            firstName = firstN;
            lastName = lastN;
            dateOfBirth = birth;
            if (specialNeeds)
                sNeedsD = specialNeedsDescrition;
        }
        public Child() { }
    }
}
