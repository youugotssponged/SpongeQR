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
        public MessagePayload Message;

        public EmailPayload Email;
        public URLPayload Url;
        public PhoneNumberPayload PhoneNumber;
        public WIFIPayload Wifi;

        // Reference to this window
        public static MainWindow window;

        // Function pointer to repoint functionality
        public delegate void Generate(Image image);

        public Generate generate;

        public MainWindow()
        {
            // Window Settings
            ResizeMode = ResizeMode.NoResize;

            // Forward reference to this window
            window = this;

            // Initialize Application Operations
            windowOperations = new WindowOperations();
            qrOperations = new QRPayloadOperations();

            // Initialize Payloads
            Message = new MessagePayload();
            Email = new EmailPayload();
            Url = new URLPayload();
            PhoneNumber = new PhoneNumberPayload();
            Wifi = new WIFIPayload();

            // Initialize Main Window Components
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
            windowOperations.SaveImage(windowOperations.GetBitmap(qrOperations.Bitmapsource));
        }

        private void btn_OpenQR_Click(object sender, RoutedEventArgs e)
        {
            windowOperations.OpenImage(image_viewer);
        }

        #region Menu Items

        private void MenuItem_New_Click(object sender, RoutedEventArgs e)
        {
            image_viewer.Source = null;
            EncodeChoiceDropDown.SelectedIndex = 0;
        }

        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
        {
            windowOperations.OpenImage(image_viewer);
        }

        private void MenuItem_Save_Click(object sender, RoutedEventArgs e)
        {
            windowOperations.SaveImage(windowOperations.GetBitmap(qrOperations.Bitmapsource));
        }

        // Exit Handler
        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void About_WindowMenuContext_Click(object sender, RoutedEventArgs e)
        {
            windowOperations.ShowAboutMessage();
        }

        #endregion Menu Items

        #endregion Button Handlers

        #region Unique Component Handlers

        // Fires Upon Drop-down option Being Changed
        private void EncodeChoiceDropDown_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            switch (EncodeChoiceDropDown.SelectedIndex)
            {
                case (int)DropDownOptions.SimpleMessage:
                    GenerateAndRemoveComponents(Message, qrOperations.GenerateMessagePayload, Email, Url, PhoneNumber, Wifi);
                    break;

                case (int)DropDownOptions.Email:
                    GenerateAndRemoveComponents(Email, qrOperations.GenerateEmailPayload, Message, Url, PhoneNumber, Wifi);
                    break;
                // IMPLEMENT THE REST
                case (int)DropDownOptions.URL:
                    GenerateAndRemoveComponents(Url, qrOperations.GenerateURLPayload, Message, Email, PhoneNumber, Wifi);
                    break;

                case (int)DropDownOptions.PhoneNumber:
                    GenerateAndRemoveComponents(PhoneNumber, qrOperations.GeneratePhoneNumberPayload, Message, Email, Url, Wifi);
                    break;

                case (int)DropDownOptions.Wifi:
                    GenerateAndRemoveComponents(Wifi, qrOperations.GenerateWIFIPayload, Message, Email, Url, PhoneNumber);
                    break;

                case (int)DropDownOptions.CalendarEvent:

                    generate = qrOperations.GenerateCalendarEventPayload;
                    break;
            }
        }

        private void GenerateAndRemoveComponents(IPayloadUI toGenerate, Generate PayloadOperationToBeExecuted, params IPayloadUI[] toBeRemoved)
        {
            // Call Generate
            toGenerate.GenerateComponents(mainGrid);

            // Point to operation to be executed later
            generate = PayloadOperationToBeExecuted;

            // Remove Each Specified
            foreach (IPayloadUI component in toBeRemoved)
            {
                component.RemoveComponents(mainGrid);
            }
        }

        private enum DropDownOptions
        {
            SimpleMessage = 0,
            Email,
            URL,
            PhoneNumber,
            Wifi,
            CalendarEvent
        }

        #endregion Unique Component Handlers
    }
}