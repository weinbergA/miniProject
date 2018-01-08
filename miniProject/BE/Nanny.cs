using System;

namespace BE
{
    public class Nanny
    {
        public int id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public int phoneNumber { get; set; }
        public string address { get; set; }
        public bool isElevator { get; set; }
        public int floor { get; set; }
        public double experienceYears { get; set; }
        public int maxChildren { get; set; }
        public int minAgeChildren { get; set; }
        public int maxAgeChildren { get; set; }
        public bool hourlyRateAccepting { get; set; }
        public double hourlyRate { get; set; }
        public double monthlyRate { get; set; }
        public bool[] isWorkingToday = new bool[] { false, false, false, false, false, false};


        public TimeSpan[,] workingHours = new TimeSpan[2, 6];
        public bool tamatHolidays { get; set; }
        public string reviews { get; set; }


       
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
