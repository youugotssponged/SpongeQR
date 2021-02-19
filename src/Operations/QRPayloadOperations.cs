using QRCoder;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static QRCoder.PayloadGenerator;

namespace SpongeQR
{
    public class QRPayloadOperations
    {
        private QRCodeGenerator qrGenerator;
        public Bitmap qrCodeImage { get; private set; }
        public BitmapSource Bitmapsource { get; private set; }

        private MainWindow mainWindow;

        public QRPayloadOperations()
        {
            qrGenerator = new QRCodeGenerator();
            qrCodeImage = null;

            mainWindow = Application.Current.MainWindow as MainWindow;
        }

        public void GenerateMessageQR(System.Windows.Controls.Image imageViewer)
        {
            string messageToEncode = mainWindow.messageData.MessageText;

            QRCode qrCode = GenerateQRData(messageToEncode);

            ConvertBitmapToSourceAndDisplay(qrCodeImage, qrCode, Bitmapsource, imageViewer);
        }

        public void GenerateEmailQR(System.Windows.Controls.Image imageViewer)
        {
            string email = mainWindow.emailData.EmailAddress;
            string subject = mainWindow.emailData.EmailSubject;
            string message = mainWindow.emailData.EmailMessage;

            Mail generator = new Mail(email, subject, message);
            string payload = generator.ToString();

            QRCode qrCode = GenerateQRData(payload);

            ConvertBitmapToSourceAndDisplay(qrCodeImage, qrCode, Bitmapsource, imageViewer);
        }

        public void GenerateURLQR(System.Windows.Controls.Image imageViewer)
        {
            string url = mainWindow.urlData.URL;

            QRCode qrCode = GenerateQRData(url);

            ConvertBitmapToSourceAndDisplay(qrCodeImage, qrCode, Bitmapsource, imageViewer);
        }

        public void GeneratePhoneNumberQR(System.Windows.Controls.Image imageViewer)
        {
            string phoneNumber = mainWindow.phoneData.PhoneNumber;

            QRCode qrCode = GenerateQRData(phoneNumber);

            ConvertBitmapToSourceAndDisplay(qrCodeImage, qrCode, Bitmapsource, imageViewer);
        }

        public void GenerateWIFIQR(System.Windows.Controls.Image imageViewer)
        {
            string ssid = mainWindow.wifiData.WifiSSID;
            string password = mainWindow.wifiData.WifiPassword;
            SpongeQR.Types.WIFIAuthTypes authMode = mainWindow.wifiData.WifiAuthType;

            WiFi.Authentication auth = CheckWIFIAuthTypeSelected(authMode);

            WiFi generator = new WiFi(ssid, password, auth);

            string payload = generator.ToString();
            Console.WriteLine(payload);

            QRCode qrCode = GenerateQRData(payload);

            ConvertBitmapToSourceAndDisplay(qrCodeImage, qrCode, Bitmapsource, imageViewer);
        }

        public void GenerateCalendarEventQR(System.Windows.Controls.Image imageViewer)
        {
            // Pluck data from main window
            string subject = mainWindow.calendarData.CalendarSubject;
            string description = mainWindow.calendarData.CalendarDescription;
            string location = mainWindow.calendarData.CalendarLocation;

            DateTime start = mainWindow.calendarData.CalendarStart;
            DateTime end = mainWindow.calendarData.CalendarEnd;

            bool allday = mainWindow.calendarData.CalendarIsAllDay;

            // Check and map encoding types
            CalendarEvent.EventEncoding calendarType = CheckCalendarEncodeTypeSelected(mainWindow.calendarData.CalendarEncodeType);

            // Convert to payload, generate and update image view
            CalendarEvent calendarGenerator = new CalendarEvent(subject, description, location, start, end, allday, calendarType);
            string payload = calendarGenerator.ToString();

            QRCode qrCode = GenerateQRData(payload);
            ConvertBitmapToSourceAndDisplay(qrCodeImage, qrCode, Bitmapsource, imageViewer);
        }

        private QRCode GenerateQRData(string payload)
        {
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            return qrCode;
        }

        private WiFi.Authentication CheckWIFIAuthTypeSelected(SpongeQR.Types.WIFIAuthTypes authModeChosen)
        {
            if (authModeChosen == SpongeQR.Types.WIFIAuthTypes.WPA || authModeChosen == SpongeQR.Types.WIFIAuthTypes.WPA2)
            {
                return WiFi.Authentication.WPA;
            }
            else if (authModeChosen == SpongeQR.Types.WIFIAuthTypes.WEP)
            {
                return WiFi.Authentication.WEP;
            }
            else if (authModeChosen == SpongeQR.Types.WIFIAuthTypes.None)
            {
                return WiFi.Authentication.nopass;
            }
            else
            {
                // Default to WPA as a fallback - as most routers use this
                return WiFi.Authentication.WPA;
            }
        }

        public CalendarEvent.EventEncoding CheckCalendarEncodeTypeSelected(SpongeQR.Types.CalendarEncodeTypes type)
        {
            if (type == SpongeQR.Types.CalendarEncodeTypes.UNIVERSAL)
            {
                return CalendarEvent.EventEncoding.Universal;
            }
            else if (type == SpongeQR.Types.CalendarEncodeTypes.ICAL)
            {
                return CalendarEvent.EventEncoding.iCalComplete;
            }
            else
            {
                return CalendarEvent.EventEncoding.Universal;
            }
        }

        private void ConvertBitmapToSourceAndDisplay(Bitmap qrImage, QRCode code, BitmapSource source, System.Windows.Controls.Image imageViewer)
        {
            // Dispose bitmap from memory with GC as Bitmap is IDisposable
            using (qrImage = code.GetGraphic(20))
            {
                // Convert and Set as Bitmap Data is sitting in memory and not in a file for the image viewer to load as a URI
                ImageSourceConverter imgcv = new ImageSourceConverter();
                Bitmapsource = Imaging.CreateBitmapSourceFromHBitmap
                (
                    qrImage.GetHbitmap(),
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions()
                );

                imageViewer.Source = Bitmapsource; // Set the newly converted source.
            };

            MessageBox.Show("Code was Generated Successfully, to save click \"Save QR Image\"", "QR Generation Success!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}