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
    /// Interaction logic for URLUserControl.xaml
    /// </summary>
    public partial class URLUserControl : UserControl
    {
        private MainWindow mainWindow;
        public URLUserControl()
        {
            InitializeComponent();

            mainWindow = Application.Current.MainWindow as MainWindow;
            this.DataContext = mainWindow.urlData;
        }
    }
}
