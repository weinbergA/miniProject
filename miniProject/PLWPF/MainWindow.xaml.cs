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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            init();
        }
        private void init()
        {
            BL.IBL bl = BL.FactoryBL.GetBL();
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
            bl.addNanny(farcha_mazali);
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
            Window signedMotherWindow = new signedMother();
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
