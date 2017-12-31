using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Test
    {
        BL.Bl_base bl = new BL.Bl_base();
        
        BE.Child moshe_cohen = new BE.Child
        {
            id = 1234,
            motherId = 0987,
            firstName = "Moshe",
            lastName = "Cohen",
            dateOfBirth = new DateTime(2016, 12, 01),
            specialNeeds = false,
            specialNeedsDescrition = "",

        };
        
        BE.Child nachman_goldshtein = new BE.Child
        {
            id = 4567,
            motherId = 5432,
            firstName = "Nachman",
            lastName = "Goldshtein",
            dateOfBirth = new DateTime(2017, 08, 01),
            specialNeeds = false,
            specialNeedsDescrition = "",
        };

        BE.Child natan_goldshtein = new BE.Child
        {
            id = 2345,
            motherId = 5432,
            firstName = "Natan",
            lastName = "Goldshtein",
            dateOfBirth = new DateTime(2016, 04, 24),
            specialNeeds = false,
            specialNeedsDescrition = "",
        };

        BE.Child sason_zaguri = new BE.Child
        {
            id = 4568,
            motherId = 4321,
            firstName = "Sason",
            lastName = "Zaguri",
            dateOfBirth = new DateTime(2016, 10, 15),
            specialNeeds = false,
            specialNeedsDescrition = "",
        };
        BE.Mother sara_cohen = new BE.Mother
        {
            id = 0987,
            lastName = "Cohen",
            firstName = "Sara",
            phoneNumber = 0583227800,
            address = "הפסגה 16 ירושלים",
            nannyRequestedAddress = "בית הכרם ירושלים",
            isNeedNannyToday = new bool[] { true, true, false, false, true, true },
            neededHours = new TimeSpan[,]
       {
           { new TimeSpan(8,15,0), new TimeSpan(14,30,0)},
           { new TimeSpan(8,45,0), new TimeSpan(15,30,0)},
           { new TimeSpan(0,0,0), new TimeSpan(0,0,0)},
           { new TimeSpan(0,0,0), new TimeSpan(0,0,0)},
           { new TimeSpan(7,45,0), new TimeSpan(13,30,0)},
           { new TimeSpan(8,45,0), new TimeSpan(11,30,0)}
       },
            notes = ""
        };

        BE.Mother odel_goldshtein = new BE.Mother
        {
            id = 5532,
            lastName = "Odel",
            firstName = "Goldshtein",
            phoneNumber = 0583223400,
            address = "החומה השלישית 12 ירושלים",
            nannyRequestedAddress = "הרובע הארמני ירושלים",
            isNeedNannyToday = new bool[] { true, true, false, false, true, true },
            neededHours = new TimeSpan[,]
              {
                   { new TimeSpan(8,15,0), new TimeSpan(14,30,0)},
                   { new TimeSpan(8,45,0), new TimeSpan(15,30,0)},
                   { new TimeSpan(0,0,0), new TimeSpan(0,0,0)},
                   { new TimeSpan(0,0,0), new TimeSpan(0,0,0)},
                   { new TimeSpan(7,45,0), new TimeSpan(13,30,0)},
                   { new TimeSpan(8,45,0), new TimeSpan(11,30,0)}
             },
            notes = ""
        };

        BE.Mother masuda_zaguri = new BE.Mother
        {
            id = 5432,
            lastName = "Masuda",
            firstName = "Zaguri",
            phoneNumber = 0586789400,
            address = "מגרש הרוסים ירושלים",
            nannyRequestedAddress = "מגרש הרוסים ירושלים",
            isNeedNannyToday = new bool[] { true, true, false, false, true, true },
            neededHours = new TimeSpan[,]
              {
                   { new TimeSpan(8,15,0), new TimeSpan(14,30,0)},
                   { new TimeSpan(8,45,0), new TimeSpan(15,30,0)},
                   { new TimeSpan(0,0,0), new TimeSpan(0,0,0)},
                   { new TimeSpan(0,0,0), new TimeSpan(0,0,0)},
                   { new TimeSpan(7,45,0), new TimeSpan(13,30,0)},
                   { new TimeSpan(8,45,0), new TimeSpan(11,30,0)}
             },
            notes = ""
        };

        BE.Nanny agi_mishol = new BE.Nanny
        {
            id=3456,
        lastName="Mishol",
        firstName="Agi",
        dateOfBirth=new DateTime(1985,12,25),
        phoneNumber=0504158695,
        address="שחל 14 ירושלים",
        isElevator=true,
        floor=3,
        experienceYears=7,
        maxChildren=8,
        minAgeChildren=3,
        maxAgeChildren=36,
        hourlyRateAccepting=true,
        hourlyRate=12,
        monthlyRate=4500,
        isWorkingToday = new bool[] {true,true, true, true, true, true},
        workingHours = new TimeSpan[,]
        {
            { new TimeSpan(8,0,0), new TimeSpan(14,30,0)},
            { new TimeSpan(8,0,0), new TimeSpan(15,30,0)},
            { new TimeSpan(9,0,0), new TimeSpan(16,0,0)},
            { new TimeSpan(8,0,0), new TimeSpan(16,0,0)},
            { new TimeSpan(7,45,0), new TimeSpan(15,30,0)},
            { new TimeSpan(8,0,0), new TimeSpan(11,30,0)}
        },
        tamatHolidays=true,
        reviews=""
    };
       
        BE.Nanny farcha_mazali = new BE.Nanny
        {
            id = 3458,
            lastName = "Farcha",
            firstName = "Mazali",
            dateOfBirth = new DateTime(1989, 10, 25),
            phoneNumber = 0504157895,
            address = "סלנט 20 ירושלים",
            isElevator = false,
            floor = 3,
            experienceYears = 5,
            maxChildren = 3,
            minAgeChildren = 3,
            maxAgeChildren = 36,
            hourlyRateAccepting = true,
            hourlyRate = 12,
            monthlyRate = 4500,
            isWorkingToday = new bool[] { true, true, true, true, true, true },
            workingHours = new TimeSpan[,]
              {
                  { new TimeSpan(7,0,0), new TimeSpan(16,30,0)},
                  { new TimeSpan(7,0,0), new TimeSpan(16,30,0)},
                  { new TimeSpan(7,0,0), new TimeSpan(16,0,0)},
                  { new TimeSpan(7,0,0), new TimeSpan(16,0,0)},
                  { new TimeSpan(7,0,0), new TimeSpan(16,30,0)},
                  { new TimeSpan(7,0,0), new TimeSpan(13,30,0)}
             },
            tamatHolidays = true,
            reviews = ""
        };
       
        

        public void initialize()
        {
            bl.addChild(moshe_cohen);
            bl.addChild(sason_zaguri);
            bl.addChild(nachman_goldshtein);
            bl.addChild(natan_goldshtein);

            bl.addNanny(agi_mishol);
            bl.addNanny(farcha_mazali);
            

            bl.addMother(sara_cohen);
            bl.addMother(odel_goldshtein);
            bl.addMother(masuda_zaguri);

            bl.addContract(moshe_cohen, farcha_mazali,true);
            bl.addContract(natan_goldshtein, farcha_mazali, true);
            bl.addContract(nachman_goldshtein, farcha_mazali, false);
            List<BE.Nanny> bestNanniesSaraCohen = bl.listOfMatchingNannies(sara_cohen);
            if (bestNanniesSaraCohen.Count == 0)
                bestNanniesSaraCohen = bl.bestDefaultsNannies(sara_cohen);
            List<BE.Nanny> bestNanniesOdelGoldshtein = bl.listOfMatchingNannies(odel_goldshtein);

            foreach (var item in bl.contractsList())
                Console.WriteLine(item);

            foreach(var nanny in bestNanniesSaraCohen)
                Console.WriteLine(nanny);
            foreach (var nanny in bestNanniesOdelGoldshtein)
                Console.WriteLine(nanny);


        }








    }
}
