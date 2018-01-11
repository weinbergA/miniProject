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
    /// Interaction logic for chiled.xaml
    /// </summary>
    public partial class newChild : Window
    {
        BE.Child child;
        BL.IBL bl;
        public newChild()
        {
            InitializeComponent();
            child = new BE.Child();
            bl = BL.FactoryBL.GetBL();
            this.DataContext = child;
        }
        public newChild(int motherId)
        {
            InitializeComponent();
            child = new BE.Child();
            child.motherId = motherId;
            bl = BL.FactoryBL.GetBL();
            this.DataContext = child;
        }



        private void addChild_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.addChild(child);
                this.Close();
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
