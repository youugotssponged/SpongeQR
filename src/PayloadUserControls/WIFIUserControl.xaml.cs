using System;
using System.Windows;
using System.Windows.Controls;


namespace SpongeQR.PayloadUserControls
{
    /// <summary>
    /// Interaction logic for WIFIUserControl.xaml
    /// </summary>
    public partial class WIFIUserControl : UserControl
    {
        private MainWindow mainWindow;

        public WIFIUserControl()
        {
            InitializeComponent();

            mainWindow = Application.Current.MainWindow as MainWindow;
            this.DataContext = mainWindow.wifiData;

            PopulateAuthTypeComboBox();
        }

        public void PopulateAuthTypeComboBox()
        {
            AuthTypeComboBox.SelectedIndex = 0;
            AuthTypeComboBox.ItemsSource = Enum.GetValues(typeof(SpongeQR.Types.WIFIAuthTypes));
        }
    }
}
