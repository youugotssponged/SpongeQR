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

        private MainWindow windowRef;

        public QRPayloadOperations()
        {
            qrGenerator = new QRCodeGenerator();
            qrCodeImage = null;

            windowRef = MainWindow.window;
        }

        #region Generate Payload QR Code Methods

        public void GenerateMessageQR(System.Windows.Controls.Image imageViewer)
        {
            string messageToEncode = windowRef.Message.message.Text;

            QRCode qrCode = GenerateQRData(messageToEncode);

            ConvertBitmapToSourceAndDisplay(qrCodeImage, qrCode, Bitmapsource, imageViewer);
        }

        public void GenerateEmailQR(System.Windows.Controls.Image imageViewer)
        {
            string email = windowRef.Email.email.Text;
            string subject = windowRef.Email.subject.Text;
            string message = windowRef.Email.message.Text;

            Mail generator = new Mail(email, subject, message);
            string payload = generator.ToString();

            QRCode qrCode = GenerateQRData(payload);

            ConvertBitmapToSourceAndDisplay(qrCodeImage, qrCode, Bitmapsource, imageViewer);
        }

        public void GenerateURLQR(System.Windows.Controls.Image imageViewer)
        {
            string url = windowRef.Url.url.Text;

            QRCode qrCode = GenerateQRData(url);

            ConvertBitmapToSourceAndDisplay(qrCodeImage, qrCode, Bitmapsource, imageViewer);
        }

        public void GeneratePhoneNumberQR(System.Windows.Controls.Image imageViewer)
        {
            string phoneNumber = windowRef.PhoneNumber.number.Text;

            QRCode qrCode = GenerateQRData(phoneNumber);

            ConvertBitmapToSourceAndDisplay(qrCodeImage, qrCode, Bitmapsource, imageViewer);
        }

        public void GenerateWIFIQR(System.Windows.Controls.Image imageViewer)
        {
            string ssid = windowRef.Wifi.ssid.Text;
            string password = windowRef.Wifi.password.Text;
            string authMode = windowRef.Wifi.authMode.Text;

            WiFi.Authentication auth = CheckWIFIAuthTypeSelected(authMode);
            if (auth == WiFi.Authentication.nopass) return;

            WiFi generator = new WiFi(ssid, password, auth);
            string payload = generator.ToString();

            QRCode qrCode = GenerateQRData(payload);

            ConvertBitmapToSourceAndDisplay(qrCodeImage, qrCode, Bitmapsource, imageViewer);
        }

        public void GenerateCalendarEventQR(System.Windows.Controls.Image imageViewer)
        {
            MessageBox.Show("Calendar Feature Not Available");
        }

        #endregion Generate Payload QR Code Methods

        #region Helper Functions

        private QRCode GenerateQRData(string payload)
        {
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            return qrCode;
        }

        private WiFi.Authentication CheckWIFIAuthTypeSelected(string authModeChosen)
        {
            if (authModeChosen == "WPA")
            {
                return WiFi.Authentication.WPA;
            }
            else if (authModeChosen == "WEP")
            {
                return WiFi.Authentication.WEP;
            }
            else
            {
                MessageBox.Show("Please Enter an Authentication Type!");
                return WiFi.Authentication.nopass;
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

        #endregion Helper Functions
    }
}