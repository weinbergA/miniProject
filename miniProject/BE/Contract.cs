﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    
    enum hourlyOrMonthly { hourly,monthly}
    class Contract
    {
        static int contractNumberStrat = 12345678;
        int contractNumber;
        int nannyId;
        
        int childId;
        bool firstMeeting;
        bool isContractSighed;
        double hourlyRate;
        double monthlyRate;
        hourlyOrMonthly monthlyOrHourly;
        DateTime contrcatBeggining;
        DateTime contractFinshing;
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



    }
}