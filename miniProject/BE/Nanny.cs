using System;

namespace BE
{
    public class Nanny
    {
        public int id;
        public string lastName;
        public string firstName;
        public DateTime dateOfBirth;
        public int phoneNumber;
        public string address;
        public bool isElevator;
        public int floor;
        public double experienceYears;
        public int maxChildren;
        public int minAgeChildren;
        public int maxAgeChildren;
        public bool hourlyRateAccepting;
        public double hourlyRate;
        public double monthlyRate;
        public bool[] isWorkingToday = new bool[6];
        public TimeSpan[,] workingHours = new TimeSpan[2,6];
        public bool tamatHolidays;
        public string reviews;
        

        public double HourlyRate { get => hourlyRate; set => hourlyRate = value; }
        public double MonthlyRate { get => monthlyRate; set => monthlyRate = value; }
        public int MaxChildren { get => maxChildren; set => maxChildren = value; }

        public override string ToString()
        {
            string str = "";
            str += "\nName: " + firstName + " " + lastName;
            str += "\nrate per month: " + monthlyRate;
            str += "\nworking days:\n";
            for (int i = 0; i < 6; i++)
            {
                if(isWorkingToday[i])
                {
                    str += Enum.Parse(typeof(DayOfWeek), i.ToString()) + ": ";
                    str += (workingHours[i, 0]).ToString() + "-";
                    str += (workingHours[i, 1]).ToString() + "\n";
                    
                }
            }
            
            return str;
        }
        public Nanny(int nannyId,string firstN,string lastN,DateTime birth,int phone,string nannyAddress,bool elevator,int nannyFloor,double experience,int maxOfChildren,int minAge,int maxAge,bool isHourlyRate,double rateHourly,double rateMothly,bool[]workDays, TimeSpan[,] hours,bool holidays,string nannyReviews)
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
        public Nanny() { }
    }
}
