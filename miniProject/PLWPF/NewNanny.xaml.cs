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
            nanny.workingHours[0, 0] = enterHoures_0.Value.Value.TimeOfDay;
            nanny.workingHours[0, 1] = leaveHoures_0.Value.Value.TimeOfDay;
            nanny.workingHours[1, 0] = enterHoures_1.Value.Value.TimeOfDay;
            nanny.workingHours[1, 1] = leaveHoures_1.Value.Value.TimeOfDay;
            nanny.workingHours[2, 0] = enterHoures_2.Value.Value.TimeOfDay;
            nanny.workingHours[2, 1] = leaveHoures_2.Value.Value.TimeOfDay;
            nanny.workingHours[3, 0] = enterHoures_3.Value.Value.TimeOfDay;
            nanny.workingHours[3, 1] = leaveHoures_3.Value.Value.TimeOfDay;
            nanny.workingHours[4, 0] = enterHoures_4.Value.Value.TimeOfDay;
            nanny.workingHours[4, 1] = leaveHoures_4.Value.Value.TimeOfDay;
            nanny.workingHours[5, 0] = enterHoures_5.Value.Value.TimeOfDay;
            nanny.workingHours[5, 1] = leaveHoures_5.Value.Value.TimeOfDay;

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
