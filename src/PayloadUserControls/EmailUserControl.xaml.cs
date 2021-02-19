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
    /// Interaction logic for EmailUserControl.xaml
    /// </summary>
    public partial class EmailUserControl : UserControl
    {
        private MainWindow mainWindow;

        public EmailUserControl()
        {
            InitializeComponent();

            mainWindow = Application.Current.MainWindow as MainWindow;
            this.DataContext = mainWindow.emailData;

            SetTextBoxProps();
        }

        public void SetTextBoxProps()
        {
            MessageTextBox.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            MessageTextBox.AcceptsTab = true;
            MessageTextBox.AcceptsReturn = true;
        }
    }
}
