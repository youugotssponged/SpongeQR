using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using SpongeQR.Models;

namespace SpongeQR
{
    public partial class MainWindow : Window
    {
        // Operation Specific - e.g. Save, Generate etc.
        public WindowOperations windowOperations;
        public QRPayloadOperations qrOperations;

        // Data models
        public EmailData emailData = new EmailData();
        public MessageData messageData = new MessageData();
        public URLData urlData = new URLData();
        public WIFIData wifiData = new WIFIData();
        public PhoneData phoneData = new PhoneData();
        public CalendarData calendarData = new CalendarData();

        // Pointer
        public Action<Image> qrAction;

        public MainWindow()
        {
            // Window Settings
            ResizeMode = ResizeMode.NoResize;

            // Initialize Application Operations
            windowOperations = new WindowOperations();
            qrOperations = new QRPayloadOperations();

            // Set Window Title
            Title = $"Sponge QR ({windowOperations.devInfo.Version})";

            // Init Components that belong to the window;
            InitializeComponent();
            PopulateQRDropdown();

            // Disable Save Button and Menu Button
            CheckIfUserCanSave();
        }



        // Generate QR Image Handler
        private void btn_GenerateQR_Click(object sender, RoutedEventArgs e)
        {
            qrAction(image_viewer); // Execute whatever function generate is pointed to.

            SaveStatusLabel.Content = "QR Currently Not Saved";
            SaveStatusLabel.Foreground = Brushes.Red;
            
            CheckIfUserCanSave();
        }

        // Save Handler
        private void btn_SaveQR(object sender, RoutedEventArgs e)
        {
            windowOperations.SaveImage(windowOperations.GetBitmap(qrOperations.Bitmapsource), SaveStatusLabel);
        }

        private void btn_OpenQR_Click(object sender, RoutedEventArgs e)
        {
            windowOperations.OpenImage(image_viewer);
        }


        private void MenuItem_New_Click(object sender, RoutedEventArgs e)
        {
            image_viewer.Source = null;
            EncodeChoiceDropDown.SelectedIndex = 0;

            SaveStatusLabel.Content = "QR Currently Empty...";
            SaveStatusLabel.Foreground = Brushes.Gray;

            CheckIfUserCanSave();
        }

        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
        {
            windowOperations.OpenImage(image_viewer);
        }

        private void MenuItem_Save_Click(object sender, RoutedEventArgs e)
        {
            windowOperations.SaveImage(windowOperations.GetBitmap(qrOperations.Bitmapsource), SaveStatusLabel);
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

        public void PopulateQRDropdown()
        {
            EncodeChoiceDropDown.ItemsSource = Enum.GetValues(typeof(SpongeQR.Types.QRTypes));
            EncodeChoiceDropDown.SelectedIndex = 0;
        }

        // Fires Upon Drop-down option Being Changed
        private void EncodeChoiceDropDown_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            image_viewer.Source = null; // Clear when selection type changes
            CheckIfUserCanSave();

            switch (EncodeChoiceDropDown.SelectedItem)
            {
                case SpongeQR.Types.QRTypes.Email:
                    UserControlController.Content = new SpongeQR.PayloadUserControls.EmailUserControl();
                    qrAction = qrOperations.GenerateEmailQR;
                    break;
                case SpongeQR.Types.QRTypes.Message:
                    UserControlController.Content = new SpongeQR.PayloadUserControls.MessageUserControl();
                    qrAction = qrOperations.GenerateMessageQR;
                    break;
                case SpongeQR.Types.QRTypes.PhoneNumber:
                    UserControlController.Content = new SpongeQR.PayloadUserControls.PhoneUserControl();
                    qrAction = qrOperations.GeneratePhoneNumberQR;
                    break;
                case SpongeQR.Types.QRTypes.URL:
                    UserControlController.Content = new SpongeQR.PayloadUserControls.URLUserControl();
                    qrAction = qrOperations.GenerateURLQR;
                    break;
                case SpongeQR.Types.QRTypes.WIFI:
                    UserControlController.Content = new SpongeQR.PayloadUserControls.WIFIUserControl();
                    qrAction = qrOperations.GenerateWIFIQR;
                    break;
                case SpongeQR.Types.QRTypes.CalendarEvent:
                    UserControlController.Content = new SpongeQR.PayloadUserControls.CalendarUserControl();
                    qrAction = qrOperations.GenerateCalendarEventQR;
                    break;
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

    }
}