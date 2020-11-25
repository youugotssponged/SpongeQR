using System.Windows;
using System.Windows.Controls;

namespace SpongeQR
{
    public partial class MainWindow : Window
    {
        // Operation Specific - e.g. Save, Generate etc.
        private WindowOperations windowOperations;
        private QRPayloadOperations qrOperations;

        // Payloads - Payload Dynamic UI Models
        public SimpleMessagePayload SimpleMessage;
        public EmailPayload Email;

        // Reference to this window
        public static MainWindow window;

        // Function pointer to repoint functionality 
        public delegate void Generate(Image image);
        public Generate generate;

        public MainWindow()
        {
            // Window Settings
            ResizeMode = ResizeMode.NoResize;

            // Foward reference to this window
            window = this;

            // Initialise Application Operations
            windowOperations = new WindowOperations();
            qrOperations = new QRPayloadOperations();

            // Initialise Payloads
            SimpleMessage = new SimpleMessagePayload();
            Email = new EmailPayload();

            // Initialise Main Window Components
            InitializeComponent();
        }

        #region Button Handlers
        // Generate QR Image Handler
        private void btn_GenerateQR_Click(object sender, RoutedEventArgs e)
        {
            generate(image_viewer); // Execute whatever function generate is pointed to.
        }

        // Save Handler
        private void btn_SaveQR(object sender, RoutedEventArgs e)
        {
            windowOperations.SaveImage(windowOperations.GetBitmap(qrOperations.bitmapsource));
        }

        private void btn_OpenQR_Click(object sender, RoutedEventArgs e)
        {
            windowOperations.OpenImage(image_viewer);
        }

        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
        {
            windowOperations.OpenImage(image_viewer);
        }

        private void MenuItem_Save_Click(object sender, RoutedEventArgs e)
        {
            windowOperations.SaveImage(windowOperations.GetBitmap(qrOperations.bitmapsource));
        }

        // Exit Handler
        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            // Close Application
            Application.Current.Shutdown();
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
            switch (EncodeChoiceDropDown.SelectedIndex)
            {
                case (int)DropDownOptions.SimpleMessage:
                    SimpleMessage.GenerateComponents(mainGrid);
                    Email.RemoveComponents(mainGrid);

                    generate = qrOperations.GenerateMessagePayload;
                    break;

                case (int)DropDownOptions.Email:
                    Email.GenerateComponents(mainGrid);
                    SimpleMessage.RemoveComponents(mainGrid);

                    generate = qrOperations.GenerateEmailPayload;
                    break;


                // IMPLEMENT THE REST
                case (int)DropDownOptions.URL:
                    break;

                case (int)DropDownOptions.PhoneNumber:
                    break;

                case (int)DropDownOptions.Wifi:
                    break;

                case (int)DropDownOptions.CalendarEvent:
                    break;
            }
        }

        public enum DropDownOptions
        {
            SimpleMessage = 0,
            Email,
            URL,
            PhoneNumber,
            Wifi,
            CalendarEvent
        }
        #endregion
    }
}
