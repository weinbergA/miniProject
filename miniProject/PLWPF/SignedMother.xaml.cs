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
        Child child;
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
            update.IsEnabled = true;
            delete.IsEnabled = true;
            childrenView.IsEnabled = true;
            manage.IsEnabled = true;
            manageChildren.IsEnabled = true;
            addChild.IsEnabled = true;
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
            if(child == null)
            {
                MessageBox.Show("please choose child");
                return;
            }
            if (bl.contractsList().FindAll(x => x.childId == child.Id).Count != 0)
            {
                MessageBox.Show("this child has already a nanny");
                return;
            }
            NannyChoose nanny = new NannyChoose(mother, child);
            nanny.Show();
        }

        private void updateChild_Click(object sender, RoutedEventArgs e)
        {
            if (child == null)
            {
                MessageBox.Show("please choose child");
                return;
            }
            Window updateChild = new UpdateChild(child);
            updateChild.Show();

        }


        private void deleteChild_Click(object sender, RoutedEventArgs e)
        {
            if (child == null)
            {
                MessageBox.Show("please choose child");
                return;
            }
            try
            {
                bl.removeChild(child);
                children.Items.Remove(children.SelectedItem);
                children.SelectedItem = null;
                MessageBox.Show("child was deleted susccesfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            Window updateMoter = new UpdateMother(mother);
            updateMoter.Show();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.removeMother(mother);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void manageChildren_Checked(object sender, RoutedEventArgs e)
        {
            
            List<Child> childrenOfMother = bl.childrenByMother(mother);
            if (childrenOfMother.Count == 0)
            {
                MessageBox.Show("you have no children yet");
                return;
            }
            updateChild.IsEnabled = true;
            deleteChild.IsEnabled = true;
            findNanny.IsEnabled = true;
            foreach (var child in childrenOfMother)
            {
                ComboBoxItem newChild = new ComboBoxItem();
                newChild.Content = child.firstName;
                children.Items.Add(newChild);
            }
            children.IsEnabled = true;
        }

        private void children_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string str = children.SelectedItem.ToString();
            string[] name = str.Split(' ');
            child = bl.childrenByMother(mother).First(x => x.firstName == name[1]);
        }
    }
}

