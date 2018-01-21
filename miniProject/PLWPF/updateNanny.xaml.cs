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
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for NewNanny.xaml
    /// </summary>
    public partial class updateNanny : Window
    {
        private List<string> errorMessages = new List<string>();
        BE.Nanny nanny;
        BL.IBL bl;
        public updateNanny()
        {
            
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            nanny = this.DataContext as BE.Nanny;
            
            if (nanny.isWorkingToday[0])
                Sun.IsEnabled = true;
            if (nanny.isWorkingToday[1])
                Mon.IsEnabled = true;
            if (nanny.isWorkingToday[2])
                Tue.IsEnabled = true;
            if (nanny.isWorkingToday[3])
                Wed.IsEnabled = true;
            if (nanny.isWorkingToday[4])
                Thu.IsEnabled = true;
            if (nanny.isWorkingToday[5])
                Fri.IsEnabled = true;
        }
        public updateNanny(BE.Nanny nannyCopy)
        {
            
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            nanny = nannyCopy;
            this.DataContext = nanny;
            phoneNumberTextBox.Text = nanny.phoneNumber.ToString().Insert(0, "0");

            if (nanny.isWorkingToday[0])
            {
                Sun.IsEnabled = true;
                Sun.IsChecked = true;
                enterHoures_1.IsEnabled = true;
                leaveHoures_1.IsEnabled = true;
                enterHoures_1.Text = nanny.workingHours[0, 0].ToString(@"hh\:mm");
                leaveHoures_1.Text = nanny.workingHours[0, 1].ToString(@"hh\:mm");
            }
            if (nanny.isWorkingToday[1])
            {
                Mon.IsEnabled = true;
                Mon.IsChecked = true;
                enterHoures_2.IsEnabled = true;
                leaveHoures_2.IsEnabled = true;
                enterHoures_2.Text = nanny.workingHours[1, 0].ToString(@"hh\:mm");
                leaveHoures_2.Text = nanny.workingHours[1, 1].ToString(@"hh\:mm");
            }
            if (nanny.isWorkingToday[2])
            {
                Tue.IsEnabled = true;
                Tue.IsChecked = true;
                enterHoures_3.IsEnabled = true;
                leaveHoures_3.IsEnabled = true;
                enterHoures_3.Text = nanny.workingHours[2, 0].ToString(@"hh\:mm");
                leaveHoures_3.Text = nanny.workingHours[2, 1].ToString(@"hh\:mm");
            }
            if (nanny.isWorkingToday[3])
            {
                Wed.IsEnabled = true;
                Wed.IsChecked = true;
                enterHoures_4.IsEnabled = true;
                leaveHoures_4.IsEnabled = true;
                enterHoures_4.Text = nanny.workingHours[3, 0].ToString(@"hh\:mm");
                leaveHoures_4.Text = nanny.workingHours[3, 1].ToString(@"hh\:mm");
            }
            if (nanny.isWorkingToday[4])
            {
                Thu.IsEnabled = true;
                Thu.IsChecked = true;
                enterHoures_5.IsEnabled = true;
                leaveHoures_5.IsEnabled = true;
                enterHoures_5.Text = nanny.workingHours[4, 0].ToString(@"hh\:mm");
                leaveHoures_5.Text = nanny.workingHours[4, 1].ToString(@"hh\:mm");
            }
            if (nanny.isWorkingToday[5])
            {
                Fri.IsEnabled = true;
                Fri.IsChecked = true;
                enterHoures_6.IsEnabled = true;
                leaveHoures_6.IsEnabled = true;
                enterHoures_6.Text = nanny.workingHours[5, 0].ToString(@"hh\:mm");
                leaveHoures_6.Text = nanny.workingHours[5, 1].ToString(@"hh\:mm");
            }
        }
        private void nanny_update_Click(object sender, RoutedEventArgs e)
        {
            nanny.phoneNumber = int.Parse(phoneNumberTextBox.ToString());
            if (nanny.isWorkingToday[0])
            {
                nanny.workingHours[0, 0] = enterHoures_1.Value.Value.TimeOfDay;
                nanny.workingHours[0, 1] = leaveHoures_1.Value.Value.TimeOfDay;
            }
            if (nanny.isWorkingToday[1])
            {
                nanny.workingHours[1, 0] = enterHoures_2.Value.Value.TimeOfDay;
                nanny.workingHours[1, 1] = leaveHoures_2.Value.Value.TimeOfDay;
            }
            if (nanny.isWorkingToday[2])
            {
                nanny.workingHours[2, 0] = enterHoures_3.Value.Value.TimeOfDay;
                nanny.workingHours[2, 1] = leaveHoures_3.Value.Value.TimeOfDay;
            }
            if (nanny.isWorkingToday[3])
            {
                nanny.workingHours[3, 0] = enterHoures_4.Value.Value.TimeOfDay;
                nanny.workingHours[3, 1] = leaveHoures_4.Value.Value.TimeOfDay;
            }
            if (nanny.isWorkingToday[4])
            {
                nanny.workingHours[4, 0] = enterHoures_5.Value.Value.TimeOfDay;
                nanny.workingHours[4, 1] = leaveHoures_5.Value.Value.TimeOfDay;
            }
            if (nanny.isWorkingToday[5])
            {
                nanny.workingHours[5, 0] = enterHoures_6.Value.Value.TimeOfDay;
                nanny.workingHours[5, 1] = leaveHoures_6.Value.Value.TimeOfDay;
            }
            if (errorMessages.Any())
            {
                string arr = "Exeption: ";
                foreach (var error in errorMessages)
                    arr += "\n" + error;
                MessageBox.Show(arr);
                return;
            }
            try
            {
                bl.updateNanny(nanny);
                MessageBox.Show("update succeeded");
                this.Close();
            }

            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void Sun_Checked(object sender, RoutedEventArgs e)
        {
            enterHoures_1.IsEnabled = true;
            leaveHoures_1.IsEnabled = true;
            nanny.isWorkingToday[0] = true;
        }

        private void Sun_Unchecked(object sender, RoutedEventArgs e)
        {
            enterHoures_1.IsEnabled = false;
            leaveHoures_1.IsEnabled = false;
            nanny.isWorkingToday[0] = false;
        }

        private void Mon_Checked(object sender, RoutedEventArgs e)
        {
            enterHoures_2.IsEnabled = true;
            leaveHoures_2.IsEnabled = true;
            nanny.isWorkingToday[1] = true;
        }

        private void Mon_Unchecked(object sender, RoutedEventArgs e)
        {
            enterHoures_2.IsEnabled = false;
            leaveHoures_2.IsEnabled = false;
            nanny.isWorkingToday[1] = false;
        }

        private void Tue_Checked(object sender, RoutedEventArgs e)
        {
            enterHoures_3.IsEnabled = true;
            leaveHoures_3.IsEnabled = true;
            nanny.isWorkingToday[2] = true;
        }

        private void Tue_Unchecked(object sender, RoutedEventArgs e)
        {
            enterHoures_3.IsEnabled = false;
            leaveHoures_3.IsEnabled = false;
            nanny.isWorkingToday[2] = false;
        }

        private void Wed_Checked(object sender, RoutedEventArgs e)
        {
            enterHoures_4.IsEnabled = true;
            leaveHoures_4.IsEnabled = true;
            nanny.isWorkingToday[3] = true;
        }

        private void Wed_Unchecked(object sender, RoutedEventArgs e)
        {
            enterHoures_4.IsEnabled = false;
            leaveHoures_4.IsEnabled = false;
            nanny.isWorkingToday[3] = false;
        }

        private void Thu_Checked(object sender, RoutedEventArgs e)
        {
            enterHoures_5.IsEnabled = true;
            leaveHoures_5.IsEnabled = true;
            nanny.isWorkingToday[4] = true;
        }

        private void Thu_Unchecked(object sender, RoutedEventArgs e)
        {
            enterHoures_5.IsEnabled = false;
            leaveHoures_5.IsEnabled = false;
            nanny.isWorkingToday[4] = false;
        }

        private void Fri_Checked(object sender, RoutedEventArgs e)
        {
            enterHoures_6.IsEnabled = true;
            leaveHoures_6.IsEnabled = true;
            nanny.isWorkingToday[5] = true;
        }

        private void Fri_Unchecked(object sender, RoutedEventArgs e)
        {
            enterHoures_6.IsEnabled = false;
            leaveHoures_6.IsEnabled = false;
            nanny.isWorkingToday[5] = false;
        }

        private void Window_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Error.Exception != null)
            {
                if (e.Action == ValidationErrorEventAction.Added)
                    errorMessages.Add(e.Error.Exception.Message);
                else
                    errorMessages.Remove(e.Error.Exception.Message);
            }
        }
    }
}
