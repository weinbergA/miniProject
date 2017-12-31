using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    
    public enum hourlyOrMonthly { hourly,monthly}
     public class Contract
    {
        public int contractNumber;
        public int nannyId;
        public int motherId;
        public int childId;
        public bool firstMeeting;
        public bool isContractSighed;
        public double hourlyRate;
        public double monthlyRate;
        public hourlyOrMonthly monthlyOrHourly;
        public DateTime contrcatBeggining;
        public DateTime contractFinshing;

        public double HourlyRate { get => hourlyRate; set => hourlyRate = value; }
        public double MonthlyRate { get => monthlyRate; set => monthlyRate = value; }

        public override string ToString()
        {
            string str = "";
            str += "Contract number: " + contractNumber + " " + "/n";
            //add nanny name && child name
            if (isContractSighed)
                str += "Contract sighed /n";
            else
                str+= "Contract not sighed /n";
            str += "Strat date: " + contrcatBeggining.Date;
            str += "\nEnd date: " + contractFinshing + "/n";
            if (monthlyOrHourly == 0)

                str += "Hourly rate: " + hourlyRate + " per hour\n";
            else
                str += "Monthly rate: " + monthlyRate + "per month/n";
            return str;
        }
        public Contract(int nanny,int child,bool meeting,bool sighed,hourlyOrMonthly mOrh,int hourly, int monthly,DateTime strat,DateTime end)
        {
            childId = child;
             nannyId = nanny;
            firstMeeting = meeting;
            isContractSighed = sighed;
            monthlyOrHourly = mOrh;

            if (monthlyOrHourly == 0)
                hourlyRate = hourly;
            else
                monthlyRate = monthly;

            contrcatBeggining = strat;
            contractFinshing = end;
           
        }

        public Contract() { }
        
    }
}
