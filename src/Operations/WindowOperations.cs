using Microsoft.Win32;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows;
using System.Windows.Media.Imaging;

namespace SpongeQR
{
    public class WindowOperations
    {
        public DevInfo devInfo;

        public WindowOperations()
        {
            devInfo = new DevInfo
            (
                "1.0.0",
                "jordanmccann64@outlook.com",
                "Thank you for using Sponge QR! \n\nHope it has helped you on your venture <3"
            );
        }

        public void OpenImage(System.Windows.Controls.Image imageToOpen)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a QR Code to Open";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

            if (op.ShowDialog() == true)
            {
                imageToOpen.Source = new BitmapImage(new Uri(op.FileName));
            }
        }

        public void SaveImage(Bitmap imageToSave)
        {
            if (imageToSave == null)
            {
                return;
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Bitmap Image (.bmp)|*.bmp|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png";

                if (saveFileDialog.ShowDialog() == true)
                {
                    saveFileDialog.Title = "Save a QR Code";
                    imageToSave.Save(saveFileDialog.FileName);
                    MessageBox.Show($"{saveFileDialog.FileName} was saved successfully", "Save Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        public void ShowAboutMessage()
        {
            MessageBox.Show(devInfo.ToString(), "Sponge QR: " + devInfo.Version, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // BitmapSource to Bitmap Helper from https://gist.github.com/nashby
        public Bitmap GetBitmap(BitmapSource source)
        {
            if (source == null)
            {
                MessageBox.Show("There is no image to be saved, please generate one!");
                return null;
            }
            else
            {
                Bitmap bmp = new Bitmap
                (
                  source.PixelWidth,
                  source.PixelHeight,
                  System.Drawing.Imaging.PixelFormat.Format32bppPArgb
                );

                BitmapData data = bmp.LockBits
                (
                    new System.Drawing.Rectangle(System.Drawing.Point.Empty, bmp.Size),
                    ImageLockMode.WriteOnly,
                    System.Drawing.Imaging.PixelFormat.Format32bppPArgb
                );

                source.CopyPixels
                (
                  Int32Rect.Empty,
                  data.Scan0,
                  data.Height * data.Stride,
                  data.Stride
                );

                bmp.UnlockBits(data);

                return bmp;
            }
        }
    }
}