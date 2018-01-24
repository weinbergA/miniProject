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
using System.Threading;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for NannyChoose.xaml
    /// </summary>
    public partial class NannyChoose : Window
    {
        IBL bl;
        Mother mother;
        Nanny nanny;
        Child child;
        List<Nanny> nannies;
        public NannyChoose()
        {
            InitializeComponent();
        }
        public NannyChoose(Mother motherDetails,Child childDetails)
        {
            InitializeComponent();
            mother = motherDetails;
            child = childDetails;
            bl = FactoryBL.GetBL();
            nannies = bl.bestNannies(mother);
            foreach(var nanny in nannies)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = nanny.firstName + " " + nanny.lastName;
                nanniesList.Items.Add(item);
            }
        }

        private void details_Click(object sender, RoutedEventArgs e)
        {
            double distance = 0;
            var thread = new Thread(() => distance = bl.distance(nanny.address, mother.address));
            thread.Start();
            thread.Join();
            string str = "";
            str += nanny.firstName + " " + nanny.lastName + "\n";
            str += "phone number: " + nanny.phoneNumber.ToString().Insert(0,"0") + "\n";
            str += "address: " + nanny.address + "\n";
            str += "distance from you: " + distance/1000 + "km\n";
            str += "floor:" + nanny.floor + "\n";
            if (nanny.isElevator)
                str += "building has elevator\n";
            if (nanny.hourlyRateAccepting)
                str += "hourly rate accepting " + nanny.hourlyRate + " per hour\n";
            str += "rate per month: " + nanny.monthlyRate + "\n";
            MessageBox.Show(str);
        }

        private void nannies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            details.IsEnabled = true;
            signContract.IsEnabled = true;
            string str = nanniesList.SelectedItem.ToString();
            string[] name = str.Split(' ');
            nanny = nannies.First(x => x.firstName == name[1] && x.lastName == name[2]);
        }

        private void signContract_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addContract(child, nanny, true);
                MessageBox.Show("contract signed");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
