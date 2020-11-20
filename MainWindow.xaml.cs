using System.Drawing;
using System.Windows;
using QRCoder;

using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System;
using static QRCoder.PayloadGenerator;

namespace SpongeQR
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_GenerateQR_Click(object sender, RoutedEventArgs e)
        {
            // INITIAL TEST
            //
            //
            // TODO: ALLOW URL, AND OTHER THINGS TO BE ASSIGNED ALONG WITH DIRECTORY CHOICE AND FILE NAMING

            // CatJam URL Payload Test
            Url generator = new Url("https://tenor.com/view/cat-jam-cat-jam-head-bounce-kitty-gif-17946989");
            string payload = generator.ToString();

            // Generate
            QRCodeGenerator qrGenerator = new QRCodeGenerator();

            // string param is the encoded link/message/thing
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            // Save to same folder exe is in
            qrCodeImage.Save("TEST.png"); // Save the bitmap image
        }

        // Open a QR Code Image
        private void btn_OpenQR_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                image_viewer.Source = new BitmapImage(new Uri(op.FileName));
            }
        }
    }
}
