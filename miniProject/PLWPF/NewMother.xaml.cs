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
    /// Interaction logic for NewMother.xaml
    /// </summary>
    
    public partial class NewMother : Window
    {
        BE.Mother mother;
        BL.IBL bl;
        public NewMother()
        {
            InitializeComponent();
            mother = new BE.Mother();
            bl = BL.FactoryBL.GetBL();

            this.DataContext = mother;
        }
        
        private void JoinButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addMother(mother);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
