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
    /// Interaction logic for SignedNanny.xaml
    /// </summary>
    public partial class SignedNanny : Window
    {
        Nanny nanny;
        IBL bl;
        
        public SignedNanny()
        {
            nanny = new Nanny();
            bl = FactoryBL.GetBL();
            InitializeComponent();
            
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            int nannyId;
            try
            {
                string str = id.Text;
                nannyId = int.Parse(str);
                nanny = bl.getNannyById(nannyId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (nanny == null)
            {
                MessageBox.Show("no nanny with such id");
                return;
            }
            enterId.Visibility = Visibility.Hidden;
            id.Visibility = Visibility.Hidden;
            enter.Visibility = Visibility.Hidden;
            
            label.Content = "Welcome " + nanny.firstName + " " + nanny.lastName;
            label.Visibility = Visibility.Visible;
            
            childrenView.IsEnabled = true;
            update.IsEnabled = true;
            delete.IsEnabled = true;
        }

        private void childrenView_Click(object sender, RoutedEventArgs e)
        {
            List<Child> childrenList = bl.childrenByNanny(nanny);
            string str = "";
            if (childrenList.Count == 0)
            {
                MessageBox.Show("you have no children yet");
                return;
            }
            foreach(var child in childrenList)
            {
                str += child.firstName + " " + child.lastName + "\n";
            }

            MessageBox.Show(str);
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Window update = new updateNanny(nanny);
            update.Show();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.removeNanny(nanny);
                this.Close();
                MessageBox.Show("Thanks for using our service");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        
    }
}
