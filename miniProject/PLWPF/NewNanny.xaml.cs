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
    public partial class NewNanny : Window
    {
        private List<string> errorMessages = new List<string>();
        BE.Nanny nanny;
        BL.IBL bl;
        public NewNanny()
        {
            InitializeComponent();
            nanny = new BE.Nanny();
            nanny.dateOfBirth = DateTime.Now.AddYears(-18);
            bl = BL.FactoryBL.GetBL();
            this.DataContext = nanny;
            
        }

        
        private void nanny_join_Click(object sender, RoutedEventArgs e)
        {
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
            if(errorMessages.Any())
            {
                string arr = "Exeption: ";
                foreach (var error in errorMessages)
                    arr += "\n" + error;
                MessageBox.Show(arr);
                return;
            }
            try
            {
                bl.addNanny(nanny);
                this.Close();
            }
            catch(Exception x)
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
