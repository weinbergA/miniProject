using System;

namespace BE
{
    public class Nanny
    {
        int id;
        string lastName;
        string firstName;
        DateTime dateOfBirth;
        int phoneNumber;
        string address;
        bool elevator;
        int floor;
        double experienceYears;
        int maxChildren;
        double minAgeChildren;
        double maxAgeChildren;
        bool hourlyRateAccepting;
        double hourlyRate;
        double monthlyRate;
        bool[] isWorkingToday = new bool[6];
        DateTime[,] workingHours = new DateTime[2,6];
        bool tamatHolidays;
        string reviews;
        public override string ToString()
        {
            string str = "";
            str += "\nName: " + firstName + lastName;
            str += "\nrate per mounth: " + monthlyRate;
            str += "/nworking days:";
            for (int i = 0; i < 6; i++)
            {
                if(isWorkingToday[i])
                {
                    str += (workingHours[0, i]).DayOfWeek + ": ";
                    str += (workingHours[0, i]).Hour + " - ";
                    str += (workingHours[1, i]).Hour;
                }
            }
            return str;
        }
    }
}
