using System;
using System.Drawing;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Interop;

using QRCoder;
using static QRCoder.PayloadGenerator;

namespace SpongeQR
{
    public class QRPayloadOperations
    {
        private QRCodeGenerator qrGenerator;
        public Bitmap qrCodeImage { get; private set; }
        public BitmapSource bitmapsource{ get; private set; }

        private MainWindow windowRef;
        // ctor
        public QRPayloadOperations()
        {
            qrGenerator = new QRCodeGenerator();
            qrCodeImage = null;

            windowRef = MainWindow.window;
        }

        public void GenerateMessagePayload(System.Windows.Controls.Image imageViewer)
        {
            string messageToEncode = windowRef.SimpleMessage.message.Text;

            QRCodeData qrCodeData = qrGenerator.CreateQrCode(messageToEncode, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            
            ConvertBitmapToSource(qrCodeImage, qrCode, bitmapsource, imageViewer);

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

            //QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            //var qrCodeAsBitmap = qrCode.GetGraphic(20);

            ConvertBitmapToSource(qrCodeImage, qrCode, bitmapsource, imageViewer);

            // Notify for now
            MessageBox.Show("Code was Generated Successfully, to save click \"Save QR Image\"");
        }

        private void ConvertBitmapToSource(Bitmap qrImage, QRCode code, BitmapSource source, System.Windows.Controls.Image imageViewer)
        {
            // Dispose bitmap from memory 
            using (qrImage = code.GetGraphic(20))
            {
                // Convert and Set as Bitmap Data is sitting in memory and not in a file for the image viewer to load as a URI
                ImageSourceConverter imgcv = new ImageSourceConverter();
                bitmapsource = Imaging.CreateBitmapSourceFromHBitmap(qrImage.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                imageViewer.Source = bitmapsource; // BitmapSource
            };
        }

    }
}
