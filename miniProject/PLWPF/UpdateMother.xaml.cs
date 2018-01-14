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
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for UpdateMother.xaml
    /// </summary>
    public partial class UpdateMother : Window
    {
        IBL bl;
        Mother mother;
        private List<string> errorMessages = new List<string>();
        public UpdateMother()
        {
            InitializeComponent();
        }
        public UpdateMother(Mother motherDetails)
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
            mother = motherDetails;
            this.DataContext = mother;
            if (mother.isNeedNannyToday[0])
            {
                Sun.IsEnabled = true;
                Sun.IsChecked = true;
                enterHours0.IsEnabled = true;
                leaveHours0.IsEnabled = true;
                enterHours0.Text =mother.neededHours[0, 0].ToString(@"hh\:mm");
                leaveHours0.Text = mother.neededHours[0, 1].ToString(@"hh\:mm");
            }
            if (mother.isNeedNannyToday[1])
            {
                Mon.IsEnabled = true;
                Mon.IsChecked = true;
                enterHours1.IsEnabled = true;
                leaveHours1.IsEnabled = true;
                enterHours1.Text = mother.neededHours[1, 0].ToString(@"hh\:mm");
                leaveHours1.Text = mother.neededHours[1, 1].ToString(@"hh\:mm");
            }
            if (mother.isNeedNannyToday[2])
            {
                Tue.IsEnabled = true;
                Tue.IsChecked = true;
                enterHours2.IsEnabled = true;
                leaveHours2.IsEnabled = true;
                enterHours2.Text = mother.neededHours[2, 0].ToString(@"hh\:mm");
                leaveHours2.Text = mother.neededHours[2, 1].ToString(@"hh\:mm");
            }
            if (mother.isNeedNannyToday[3])
            {
                Wed.IsEnabled = true;
                Wed.IsChecked = true;
                enterHours3.IsEnabled = true;
                leaveHours3.IsEnabled = true;
                enterHours3.Text = mother.neededHours[3, 0].ToString(@"hh\:mm");
                leaveHours3.Text = mother.neededHours[3, 1].ToString(@"hh\:mm");
            }
            if (mother.isNeedNannyToday[4])
            {
                Thu.IsEnabled = true;
                Thu.IsChecked = true;
                enterHours4.IsEnabled = true;
                leaveHours4.IsEnabled = true;
                enterHours4.Text = mother.neededHours[4, 0].ToString(@"hh\:mm");
                leaveHours4.Text = mother.neededHours[4, 1].ToString(@"hh\:mm");
            }
            if (mother.isNeedNannyToday[5])
            {
                Fri.IsEnabled = true;
                Fri.IsChecked = true;
                enterHours5.IsEnabled = true;
                leaveHours5.IsEnabled = true;
                enterHours5.Text = mother.neededHours[5, 0].ToString(@"hh\:mm");
                leaveHours5.Text = mother.neededHours[5, 1].ToString(@"hh\:mm");
            }
        }
        private void JoinButton_Click(object sender, RoutedEventArgs e)
        {
            if (mother.isNeedNannyToday[0])
            {
                mother.neededHours[0, 0] = enterHours0.Value.Value.TimeOfDay;
                mother.neededHours[0, 1] = leaveHours0.Value.Value.TimeOfDay;
            }
            if (mother.isNeedNannyToday[1])
            {
                mother.neededHours[1, 0] = enterHours0.Value.Value.TimeOfDay;
                mother.neededHours[1, 1] = leaveHours0.Value.Value.TimeOfDay;
            }
            if (mother.isNeedNannyToday[2])
            {
                mother.neededHours[2, 0] = enterHours0.Value.Value.TimeOfDay;
                mother.neededHours[2, 1] = leaveHours0.Value.Value.TimeOfDay;
            }
            if (mother.isNeedNannyToday[3])
            {
                mother.neededHours[3, 0] = enterHours0.Value.Value.TimeOfDay;
                mother.neededHours[3, 1] = leaveHours0.Value.Value.TimeOfDay;
            }
            if (mother.isNeedNannyToday[4])
            {
                mother.neededHours[4, 0] = enterHours0.Value.Value.TimeOfDay;
                mother.neededHours[4, 1] = leaveHours0.Value.Value.TimeOfDay;
            }
            if (mother.isNeedNannyToday[5])
            {
                mother.neededHours[5, 0] = enterHours0.Value.Value.TimeOfDay;
                mother.neededHours[5, 1] = leaveHours0.Value.Value.TimeOfDay;
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
                bl.updateMother(mother);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Sun_Checked(object sender, RoutedEventArgs e)
        {
            enterHours0.IsEnabled = true;
            leaveHours0.IsEnabled = true;
            mother.isNeedNannyToday[0] = true;
        }

        private void Sun_Unchecked(object sender, RoutedEventArgs e)
        {
            enterHours0.IsEnabled = false;
            leaveHours0.IsEnabled = false;
            mother.isNeedNannyToday[0] = false;
        }

        private void Mon_Checked(object sender, RoutedEventArgs e)
        {
            enterHours1.IsEnabled = true;
            leaveHours1.IsEnabled = true;
            mother.isNeedNannyToday[1] = true;
        }

        private void Mon_Unchecked(object sender, RoutedEventArgs e)
        {
            enterHours1.IsEnabled = false;
            leaveHours1.IsEnabled = false;
            mother.isNeedNannyToday[1] = false;
        }

        private void Tue_Checked(object sender, RoutedEventArgs e)
        {
            enterHours2.IsEnabled = true;
            leaveHours2.IsEnabled = true;
            mother.isNeedNannyToday[2] = true;
        }

        private void Tue_Unchecked(object sender, RoutedEventArgs e)
        {
            enterHours2.IsEnabled = false;
            leaveHours2.IsEnabled = false;
            mother.isNeedNannyToday[2] = false;
        }

        private void Wed_Checked(object sender, RoutedEventArgs e)
        {
            enterHours3.IsEnabled = true;
            leaveHours3.IsEnabled = true;
            mother.isNeedNannyToday[3] = true;
        }

        private void Wed_Unchecked(object sender, RoutedEventArgs e)
        {
            enterHours3.IsEnabled = false;
            leaveHours3.IsEnabled = false;
            mother.isNeedNannyToday[3] = false;
        }

        private void Thu_Checked(object sender, RoutedEventArgs e)
        {
            enterHours4.IsEnabled = true;
            leaveHours4.IsEnabled = true;
            mother.isNeedNannyToday[4] = true;
        }

        private void Thu_Unchecked(object sender, RoutedEventArgs e)
        {
            enterHours4.IsEnabled = false;
            leaveHours4.IsEnabled = false;
            mother.isNeedNannyToday[4] = false;
        }

        private void Fri_Checked(object sender, RoutedEventArgs e)
        {
            enterHours5.IsEnabled = true;
            leaveHours5.IsEnabled = true;
            mother.isNeedNannyToday[5] = true;
        }

        private void Fri_Unchecked(object sender, RoutedEventArgs e)
        {
            enterHours5.IsEnabled = false;
            leaveHours5.IsEnabled = false;
            mother.isNeedNannyToday[5] = false;
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
