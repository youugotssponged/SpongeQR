using System;
using System.Drawing;
using System.Windows;
using System.Windows.Media.Imaging;

using Microsoft.Win32;

using QRCoder;
//using static QRCoder.PayloadGenerator;


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
            //Url generator = new Url("https://tenor.com/view/cat-jam-cat-jam-head-bounce-kitty-gif-17946989");
            //string payload = generator.ToString();

            // Generate
            QRCodeGenerator qrGenerator = new QRCodeGenerator();

            // string param is the encoded link/message/thing
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(TextBox_Message.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            // Save to same folder exe is in
            qrCodeImage.Save($"{TextBox_QRImageName.Text}"+".png"); // Save the bitmap image
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

        private void About_WindowMenuContext_Click(object sender, RoutedEventArgs e)
        {
            DevInfo devInfo = new DevInfo(
                "1.0.1", 
                "jordanmccann64@outlook.com",
                "Thank you for using Sponge QR! \n\nHope it has helped you on your venture <3"
            );

            MessageBox.Show(devInfo.ToString(), "Sponge QR - About");
        }

        // Exit Handler
        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            // Close Application
            Application.Current.Shutdown();
        }
        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
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

        // Save Handler
        private void btn_SaveQR(object sender, RoutedEventArgs e)
        {

            // Show Message Box upon save success
        }

        // Fires Upon Dropdown option Being Changed
        private void EncodeChoiceDropDown_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            /*if (EncodeChoiceDropDown.SelectedIndex == (int)Options.A)
            {
                MessageBox.Show("MESSAGE");
            } else if(EncodeChoiceDropDown.SelectedIndex == (int)Options.B)
            {
                MessageBox.Show("Email");
            }*/
        }


        // Test representation of the dropdown selections
        /*enum Options
        {
            A = 0,
            B,
            C
        }*/
    }
}
