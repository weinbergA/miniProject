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
using BL;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for chooseNanny.xaml
    /// </summary>
    public partial class chooseNanny : Window
    {
        IBL bl;
        Mother mother;
        public chooseNanny()
        {
            InitializeComponent();
        }
        public chooseNanny(Mother m)
        {
            bl = FactoryBL.GetBL();
            InitializeComponent();
            mother = m;
            List<Nanny> nannies = bl.bestNannies(mother);

        }
    }
}
