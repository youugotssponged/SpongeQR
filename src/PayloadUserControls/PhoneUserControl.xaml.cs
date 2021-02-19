using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpongeQR.PayloadUserControls
{
    /// <summary>
    /// Interaction logic for PhoneUserControl.xaml
    /// </summary>
    public partial class PhoneUserControl : UserControl
    {

        private MainWindow mainWindow;

        public PhoneUserControl()
        {
            InitializeComponent();

            mainWindow = Application.Current.MainWindow as MainWindow;
            this.DataContext = mainWindow.phoneData;
        }
    }
}
