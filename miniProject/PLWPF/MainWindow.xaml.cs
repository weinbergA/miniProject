using System;

using System.Windows;

using BL;

namespace PLWPF
{
     
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        IBL bl;
        public MainWindow()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
            Init();
        }
        private void Init()
        {
            
            BE.Child mosheCohen = new BE.Child
            {
                Id = 1234,
                motherId = 0987,
                firstName = "Moshe",
                lastName = "Cohen",
                dateOfBirth = new DateTime(2016, 12, 01),
                specialNeeds = false,
                specialNeedsDescrition = "",

            };

            BE.Child nachmanGoldshtein = new BE.Child
            {
                Id = 4567,
                motherId = 5532,
                firstName = "Nachman",
                lastName = "Goldshtein",
                dateOfBirth = new DateTime(2017, 08, 01),
                specialNeeds = false,
                specialNeedsDescrition = "",
            };

            BE.Child natanGoldshtein = new BE.Child
            {
                Id = 2345,
                motherId = 5532,
                firstName = "Natan",
                lastName = "Goldshtein",
                dateOfBirth = new DateTime(2016, 04, 24),
                specialNeeds = false,
                specialNeedsDescrition = "",
            };

            BE.Child sasonZaguri = new BE.Child
            {
                Id = 4568,
                motherId = 4321,
                firstName = "Sason",
                lastName = "Zaguri",
                dateOfBirth = new DateTime(2016, 10, 15),
                specialNeeds = false,
                specialNeedsDescrition = "",
            };
            BE.Mother saraCohen = new BE.Mother
            {
                id = 0987,
                lastName = "Cohen",
                firstName = "Sara",
                phoneNumber = 0583227800,
                address = "הפסגה 16 ירושלים",
                nannyRequestedAddress = "בית הכרם ירושלים",
                isNeedNannyToday = new[] { true, true, false, false, true, true },
                neededHours = new[,]
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

            BE.Mother odelGoldshtein = new BE.Mother
            {
                id = 5532,
                lastName = "Odel",
                firstName = "Goldshtein",
                phoneNumber = 0583223400,
                address = "החומה השלישית 12 ירושלים",
                nannyRequestedAddress = "הרובע הארמני ירושלים",
                isNeedNannyToday = new[] { true, true, false, false, true, true },
                neededHours = new[,]
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

            BE.Mother masudaZaguri = new BE.Mother
            {
                id = 5432,
                lastName = "Masuda",
                firstName = "Zaguri",
                phoneNumber = 0586789400,
                address = "מגרש הרוסים ירושלים",
                nannyRequestedAddress = "מגרש הרוסים ירושלים",
                isNeedNannyToday = new[] { true, true, false, false, true, true },
                neededHours = new[,]
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

            BE.Nanny agiMishol = new BE.Nanny
            {
                id = 3456,
                lastName = "Mishol",
                firstName = "Agi",
                dateOfBirth = new DateTime(1985, 12, 25),
                phoneNumber = 0504158695,
                address = "שחל 14 ירושלים",
                isElevator = true,
                floor = 3,
                experienceYears = 7,
                maxChildren = 8,
                minAgeChildren = 3,
                maxAgeChildren = 36,
                hourlyRateAccepting = true,
                hourlyRate = 12,
                monthlyRate = 4500,
                isWorkingToday = new[] { true, true, true, true, true, true },
                workingHours = new[,]
            {
            { new TimeSpan(8,0,0), new TimeSpan(14,30,0)},
            { new TimeSpan(8,0,0), new TimeSpan(15,30,0)},
            { new TimeSpan(9,0,0), new TimeSpan(16,0,0)},
            { new TimeSpan(8,0,0), new TimeSpan(16,0,0)},
            { new TimeSpan(7,45,0), new TimeSpan(15,30,0)},
            { new TimeSpan(8,0,0), new TimeSpan(11,30,0)}
            },
                tamatHolidays = true,
                reviews = ""
            };

            BE.Nanny farchaMazali = new BE.Nanny
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
                isWorkingToday = new[] { true, true, true, true, true, true },
                workingHours = new[,]
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
            bl.addChild(mosheCohen);
            bl.addChild(sasonZaguri);
            bl.addChild(nachmanGoldshtein);
            bl.addChild(natanGoldshtein);

            bl.addNanny(agiMishol);
            bl.addNanny(farchaMazali);


            bl.addMother(saraCohen);
            bl.addMother(odelGoldshtein);
            bl.addMother(masudaZaguri);
        }

        private void Mother_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Nanny_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MotherSignIn_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MotherRegister_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
