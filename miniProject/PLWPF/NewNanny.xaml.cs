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
        BE.Nanny nanny;
        BL.IBL bl;
        public NewNanny()
        {
            InitializeComponent();
            nanny = new BE.Nanny();
            bl = BL.FactoryBL.GetBL();
            this.DataContext = nanny;
        }

        
        private void nanny_join_Click(object sender, RoutedEventArgs e)
        {
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
    }
}
