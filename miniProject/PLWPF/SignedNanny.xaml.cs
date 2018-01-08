﻿using System;
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
    }
}
