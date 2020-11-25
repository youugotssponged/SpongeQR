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

        // ctor
        public QRPayloadOperations()
        {
            qrGenerator = new QRCodeGenerator();
            qrCodeImage = null;

            windowRef = MainWindow.window;
        }

        #region Generate Payload Methods

        public void GenerateMessagePayload(System.Windows.Controls.Image imageViewer)
        {
            string messageToEncode = windowRef.Message.message.Text;

            QRCodeData qrCodeData = qrGenerator.CreateQrCode(messageToEncode, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            ConvertBitmapToSourceAndDisplay(qrCodeImage, qrCode, Bitmapsource, imageViewer);

            // Notify for now
            MessageBox.Show("Code was Generated Successfully, to save click \"Save QR Image\"");
        }

        public void GenerateEmailPayload(System.Windows.Controls.Image imageViewer)
        {
            string email = windowRef.Email.email.Text;
            string subject = windowRef.Email.subject.Text;
            string message = windowRef.Email.message.Text;

            // Replace with textbox text
            Mail generator = new Mail(email, subject, message);
            string payload = generator.ToString();

            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            ConvertBitmapToSourceAndDisplay(qrCodeImage, qrCode, Bitmapsource, imageViewer);

            // Notify for now
            MessageBox.Show("Code was Generated Successfully, to save click \"Save QR Image\"");
        }

        public void GenerateURLPayload(System.Windows.Controls.Image imageViewer)
        {
            string url = windowRef.Url.url.Text;

            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            ConvertBitmapToSourceAndDisplay(qrCodeImage, qrCode, Bitmapsource, imageViewer);

            // Notify for now
            MessageBox.Show("Code was Generated Successfully, to save click \"Save QR Image\"");
        }

        public void GeneratePhoneNumberPayload(System.Windows.Controls.Image imageViewer)
        {
            string phoneNumber = windowRef.PhoneNumber.number.Text;

            QRCodeData qrCodeData = qrGenerator.CreateQrCode(phoneNumber, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            ConvertBitmapToSourceAndDisplay(qrCodeImage, qrCode, Bitmapsource, imageViewer);

            MessageBox.Show("Code was Generated Successfully, to save click \"Save QR Image\"");
        }

        public void GenerateWIFIPayload(System.Windows.Controls.Image imageViewer)
        {
            string ssid = windowRef.Wifi.ssid.Text;
            string password = windowRef.Wifi.password.Text;
            string authMode = windowRef.Wifi.authMode.Text;

            // clean this up
            WiFi.Authentication auth;

            // TODO: Show message box if authmode != WPA OR WEP, IF empty
            if (authMode == "WPA") auth = WiFi.Authentication.WPA;
            else if (authMode == "WEP") auth = WiFi.Authentication.WEP;
            else auth = WiFi.Authentication.nopass;

            WiFi generator = new WiFi(ssid, password, auth);
            string payload = generator.ToString();

            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            ConvertBitmapToSourceAndDisplay(qrCodeImage, qrCode, Bitmapsource, imageViewer);

            MessageBox.Show("Code was Generated Successfully, to save click \"Save QR Image\"");
        }

        public void GenerateCalendarEventPayload(System.Windows.Controls.Image imageViewer)
        {
            MessageBox.Show("Calendar");
        }

        #endregion Generate Payload Methods

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
        }
    }
}