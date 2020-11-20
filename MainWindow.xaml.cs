using System.Drawing;
using System.Windows;
using QRCoder;

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

            // Generate
            QRCodeGenerator qrGenerator = new QRCodeGenerator();

            // string param is the encoded link/message/thing
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("Adam is a damn amuzed legend.", QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            // Save
            qrCodeImage.Save("TEST.png"); // Save the bitmap image
        }
    }
}
