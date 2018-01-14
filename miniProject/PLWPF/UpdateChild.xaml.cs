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
    /// Interaction logic for UpdateChild.xaml
    /// </summary>
    public partial class UpdateChild : Window
    {
        Child child;
        IBL bl;
        public UpdateChild()
        {
            InitializeComponent();
        }
        public UpdateChild(Child ch)
        {
            InitializeComponent();
            child = ch;
            this.DataContext = child;
            bl = FactoryBL.GetBL();
        }

        private void addChild_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.updateChild(child);
                MessageBox.Show("update succseed");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
