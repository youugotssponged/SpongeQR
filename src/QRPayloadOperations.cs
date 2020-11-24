using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Interop;

using QRCoder;


namespace SpongeQR
{
    public class QRPayloadOperations
    {
        private QRCodeGenerator qrGenerator;
        public Bitmap qrCodeImage { get; private set; }
        public BitmapSource bitmapsource{ get; private set; }
        // ctor
        public QRPayloadOperations()
        {
            qrGenerator = new QRCodeGenerator();
            qrCodeImage = null;
        }

        public void GenerateSimpleMessage(TextBox textBoxMessage, System.Windows.Controls.Image imageViewer)
        {
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(textBoxMessage.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            
            // TODO: Consider breaking this out into it's own function to be used by other payload types
            // Dispose bitmap from memory 
            using (qrCodeImage = qrCode.GetGraphic(20)) {
                // Convert and Set as Bitmap Data is sitting in memory and not in a file for the image viewer to load as a URI
                ImageSourceConverter imgcv = new ImageSourceConverter();
                bitmapsource = Imaging.CreateBitmapSourceFromHBitmap(qrCodeImage.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                imageViewer.Source = bitmapsource; // BitmapSource
            };

            // Notify for now
            MessageBox.Show("Code was Generated Successfully, to save click \"Save QR Image\"");
        }


    }
}
