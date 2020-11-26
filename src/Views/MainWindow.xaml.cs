using System;
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
        public CalendarPayload Calendar;

        // Reference to this window
        public static MainWindow window;

        // Function pointer to repoint functionality
        public delegate void Generate(Image image);
        public Generate generate;

        public MainWindow()
        {
            // Forward reference to this window
            window = this;
            
            // Window Settings
            ResizeMode = ResizeMode.NoResize;

            // Initialize Application Operations
            windowOperations = new WindowOperations();
            qrOperations = new QRPayloadOperations();

            // Initialize Payloads
            Message = new MessagePayload();
            Email = new EmailPayload();
            Url = new URLPayload();
            PhoneNumber = new PhoneNumberPayload();
            Wifi = new WIFIPayload();
            Calendar = new CalendarPayload();

            // Set Window Title
            Title = $"Sponge QR ({windowOperations.devInfo.Version})";



            // Init Components that belong to the window;
            InitializeComponent();

            // Disable Save Button and Menu Button
            CheckIfUserCanSave();
        }


        #region Common Component Handlers

        // Generate QR Image Handler
        private void btn_GenerateQR_Click(object sender, RoutedEventArgs e)
        {
            generate(image_viewer); // Execute whatever function generate is pointed to.
            CheckIfUserCanSave();
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

            CheckIfUserCanSave();
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

        #endregion Common Component Handlers

        #region Unique Component Handlers

        // Fires Upon Drop-down option Being Changed
        private void EncodeChoiceDropDown_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            image_viewer.Source = null; // Clear when selection type changes
            CheckIfUserCanSave();

            switch (EncodeChoiceDropDown.SelectedIndex)
            {
                case (int)DropDownOptions.SimpleMessage:
                    GenerateAndRemoveComponents(Message, qrOperations.GenerateMessagePayload, Email, Url, PhoneNumber, Wifi, Calendar);
                    break;
                case (int)DropDownOptions.Email:
                    GenerateAndRemoveComponents(Email, qrOperations.GenerateEmailPayload, Message, Url, PhoneNumber, Wifi, Calendar);
                    break;
                case (int)DropDownOptions.URL:
                    GenerateAndRemoveComponents(Url, qrOperations.GenerateURLPayload, Message, Email, PhoneNumber, Wifi, Calendar);
                    break;
                case (int)DropDownOptions.PhoneNumber:
                    GenerateAndRemoveComponents(PhoneNumber, qrOperations.GeneratePhoneNumberPayload, Message, Email, Url, Wifi, Calendar);
                    break;
                case (int)DropDownOptions.Wifi:
                    GenerateAndRemoveComponents(Wifi, qrOperations.GenerateWIFIPayload, Message, Email, Url, PhoneNumber, Calendar);
                    break;
                case (int)DropDownOptions.CalendarEvent:
                    GenerateAndRemoveComponents(Calendar, qrOperations.GenerateCalendarEventPayload, Message, Email, Url, PhoneNumber, Wifi);
                    break;
            }
        }
        #endregion Unique Component Handlers

        #region Helper Functions
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
        private bool CheckIfUserCanSave()
        {
            // If the image has not been generated, disable save feature
            if(image_viewer.Source == null)
            {
                btn_SaveQRImage.IsEnabled = false;
                Save_Menu.IsEnabled = false;

                return false;
            } 
            // else turn it back on when
            else
            {
                btn_SaveQRImage.IsEnabled = true;
                Save_Menu.IsEnabled = true;

                return true;
            }
        }
        #endregion

        #region Enums
        private enum DropDownOptions
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