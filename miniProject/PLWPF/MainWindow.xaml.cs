using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BL;

namespace PLWPF
{
     
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl;
        public MainWindow()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
            init();
        }
        private void init()
        {
            
            BE.Child moshe_cohen = new BE.Child
            {
                Id = 1234,
                motherId = 0987,
                firstName = "Moshe",
                lastName = "Cohen",
                dateOfBirth = new DateTime(2016, 12, 01),
                specialNeeds = false,
                specialNeedsDescrition = "",

            };

            BE.Child nachman_goldshtein = new BE.Child
            {
                Id = 4567,
                motherId = 5432,
                firstName = "Nachman",
                lastName = "Goldshtein",
                dateOfBirth = new DateTime(2017, 08, 01),
                specialNeeds = false,
                specialNeedsDescrition = "",
            };

            BE.Child natan_goldshtein = new BE.Child
            {
                Id = 2345,
                motherId = 5432,
                firstName = "Natan",
                lastName = "Goldshtein",
                dateOfBirth = new DateTime(2016, 04, 24),
                specialNeeds = false,
                specialNeedsDescrition = "",
            };

            BE.Child sason_zaguri = new BE.Child
            {
                Id = 4568,
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
                isWorkingToday = new bool[] { true, true, true, true, true, true },
                workingHours = new TimeSpan[,]
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
            bl.addChild(moshe_cohen);
            bl.addChild(sason_zaguri);
            bl.addChild(nachman_goldshtein);
            bl.addChild(natan_goldshtein);

            bl.addNanny(agi_mishol);
            bl.addNanny(farcha_mazali);


            bl.addMother(sara_cohen);
            bl.addMother(odel_goldshtein);
            bl.addMother(masuda_zaguri);
        }
        private void motherEnter_Click(object sender, RoutedEventArgs e)
        {
            motherEnter.Visibility = Visibility.Collapsed;
            nannyEnter.Visibility = Visibility.Hidden;
            newMother.Visibility = Visibility.Visible;
            signedMother.Visibility = Visibility.Visible;
            motherTextBlock.Visibility = Visibility.Visible;
            back.Visibility = Visibility.Visible;
        }

        private void nannyEnter_Click(object sender, RoutedEventArgs e)
        {
            nannyEnter.Visibility = Visibility.Hidden;
            motherEnter.Visibility = Visibility.Collapsed;
            signedNanny.Visibility = Visibility.Visible;
            newNanny.Visibility = Visibility.Visible;
            nannyTextBlock.Visibility = Visibility.Visible;
            back.Visibility = Visibility.Visible;
        }

        private void signedMother_Click(object sender, RoutedEventArgs e)
        {
            Window signedMotherWindow = new SignedMother();
            signedMotherWindow.Show();
        }

        private void newMother_Click(object sender, RoutedEventArgs e)
        {
            Window newMotherWindow = new NewMother();
            newMotherWindow.Show();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            motherEnter.Visibility = Visibility.Visible;
            nannyEnter.Visibility = Visibility.Visible;
            newMother.Visibility = Visibility.Hidden;
            newNanny.Visibility = Visibility.Hidden;
            signedNanny.Visibility = Visibility.Hidden;
            signedMother.Visibility = Visibility.Hidden;
            motherTextBlock.Visibility = Visibility.Hidden;
            nannyTextBlock.Visibility = Visibility.Hidden;
            back.Visibility = Visibility.Hidden;
        }

        private void signedNanny_Click(object sender, RoutedEventArgs e)
        {
            Window signedNannyWindow = new SignedNanny();
            signedNannyWindow.Show();
        }

        private void newNanny_Click(object sender, RoutedEventArgs e)
        {
            Window newNannyWindow = new NewNanny();
            newNannyWindow.Show();
        }
    }
}
