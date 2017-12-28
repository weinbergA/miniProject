using System;

namespace BE
{
    public class Nanny
    {
        public int id;
        string lastName;
        string firstName;
        public DateTime dateOfBirth;
        int phoneNumber;
        public string address;
        bool isElevator;
        int floor;
        double experienceYears;
        int maxChildren;
        public int minAgeChildren;
        public int maxAgeChildren;
        public bool hourlyRateAccepting;
        double hourlyRate;
        double monthlyRate;
        public bool[] isWorkingToday = new bool[6];
        public DateTime[,] workingHours = new DateTime[2,6];
        public bool tamatHolidays;
        string reviews;
        

        public double HourlyRate { get => hourlyRate; set => hourlyRate = value; }
        public double MonthlyRate { get => monthlyRate; set => monthlyRate = value; }
        public int MaxChildren { get => maxChildren; set => maxChildren = value; }

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
                    str += (workingHours[1, i]).Hour + "\n";
                }
            }
            return str;
        }
        public Nanny(int nannyId,string firstN,string lastN,DateTime birth,int phone,string nannyAddress,bool elevator,int nannyFloor,double experience,int maxOfChildren,int minAge,int maxAge,bool isHourlyRate,double rateHourly,double rateMothly,bool[]workDays,DateTime[,] hours,bool holidays,string nannyReviews)
        {
            id = nannyId;
            firstName = firstN;
            lastName = lastN;
            dateOfBirth = birth;
            phoneNumber = phone;
            address = nannyAddress;
            isElevator = elevator;
            floor = nannyFloor;
            experienceYears = experience;
            maxChildren = maxOfChildren;
            maxAgeChildren = maxAge;
            minAgeChildren = minAge;
            hourlyRateAccepting = isHourlyRate;
            hourlyRate = rateHourly;
            monthlyRate = rateMothly;

            for (int i = 0; i < 6; i++)
                isWorkingToday[i] = workDays[i];

            for (int i = 0; i < 6; i++)
            {
                workingHours[0, i] = hours[0, i];
                workingHours[1, i] = hours[1, i];
            }

            tamatHolidays = holidays;
            reviews = nannyReviews;
        }
    }
}
