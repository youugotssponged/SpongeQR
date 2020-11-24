using System.Windows;

namespace SpongeQR
{
    public partial class MainWindow : Window
    {
        private WindowOperations windowOperations;
        private QRPayloadOperations qrOperations;

        public MainWindow()
        {
            InitializeComponent();

            // Initialise Application Operations
            windowOperations = new WindowOperations();
            qrOperations = new QRPayloadOperations();
        }

        #region Button Handlers
        // Generate QR Image Handler
        private void btn_GenerateQR_Click(object sender, RoutedEventArgs e)
        {
            qrOperations.GenerateSimpleMessage(TextBox_Message, image_viewer);
        }

        private void btn_OpenQR_Click(object sender, RoutedEventArgs e)
        {
            windowOperations.OpenImage(image_viewer);
        }

        // Exit Handler
        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            // Close Application
            Application.Current.Shutdown();
        }
        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
        {
            windowOperations.OpenImage(image_viewer);
        }

        // Save Handler
        private void btn_SaveQR(object sender, RoutedEventArgs e)
        {
            windowOperations.SaveImage(qrOperations.qrCodeImage);
            // Show Message Box upon save success
        }
        private void About_WindowMenuContext_Click(object sender, RoutedEventArgs e)
        {
            windowOperations.ShowAboutMessage();
        }

        #endregion

        #region Unique Component Handlers
        // Fires Upon Dropdown option Being Changed
        private void EncodeChoiceDropDown_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            /*if (EncodeChoiceDropDown.SelectedIndex == (int)Options.A)
            {
                MessageBox.Show("MESSAGE");
            } else if(EncodeChoiceDropDown.SelectedIndex == (int)Options.B)
            {
                MessageBox.Show("Email");
            }*/

            // Test representation of the dropdown selections
            /*enum Options
            {
                A = 0,
                B,
                C
            }*/
        }
        #endregion

    }
}
