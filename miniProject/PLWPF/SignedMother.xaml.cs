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
    /// Interaction logic for signedMother.xaml
    /// </summary>
    public partial class SignedMother : Window
    {
        IBL bl;
        Mother mother;
        public SignedMother()
        {
            InitializeComponent();
            bl = FactoryBL.GetBL();
            mother = new Mother();
        }

        

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            int motherId;
            try
            {
                string str = id.Text;
                motherId = int.Parse(str);
                mother = bl.getMotherById(motherId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (mother == null)
            {
                MessageBox.Show("no mother with such id");
                return;
            }
            id.Visibility = Visibility.Hidden;
            enterId.Visibility = Visibility.Hidden;
            enter.Visibility = Visibility.Hidden;
            label.Content = "Welcome " + mother.firstName + " " + mother.lastName;
            label.Visibility = Visibility.Visible;
        }

        private void childrenView_Click(object sender, RoutedEventArgs e)
        {
            string str = "";
            List<Child> children = bl.childrenByMother(mother);
            foreach (var child in children)
                str += child.firstName + "\n";
            MessageBox.Show(str);
        }

        private void addChild_Click(object sender, RoutedEventArgs e)
        {
            newChild child = new newChild(mother.id);
            child.Show();
        }

        private void findNanny_Click(object sender, RoutedEventArgs e)
        {

        }

        private void updateChild_Click(object sender, RoutedEventArgs e)
        {

        }


        private void deleteChild_Click(object sender, RoutedEventArgs e)
        {

        }

        private void update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

