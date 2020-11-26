using System.Windows;
using System.Windows.Controls;

namespace SpongeQR
{
    public class WIFIPayload : IPayloadUI
    {
        public Label hint;
        public TextBox ssid;
        public TextBox password;
        public TextBox authMode;

        public void GenerateComponents(Grid parent)
        {
            hint = new Label
            {
                Content = "Note: Must be WPA or WEP, for WPA2 just enter WPA. \nIf neither then please enter NONE",
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(400, 240, 0, 0),
                VerticalAlignment = VerticalAlignment.Top,
                Width = 300
            };

            ssid = new TextBox
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                Height = 23,
                Margin = new Thickness(383, 167, 0, 0),
                TextWrapping = TextWrapping.Wrap,
                Text = "SSID - Wifi Name",
                VerticalAlignment = VerticalAlignment.Top,
                Width = 363
            };

            password = new TextBox
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                Height = 23,
                Margin = new Thickness(383, 213, 0, 0),
                TextWrapping = TextWrapping.Wrap,
                Text = "Password",
                VerticalAlignment = VerticalAlignment.Top,
                Width = 363
            };

            authMode = new TextBox
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                Height = 23,
                Margin = new Thickness(383, 281, 0, 0),
                TextWrapping = TextWrapping.Wrap,
                Text = "Authentication Type",
                VerticalAlignment = VerticalAlignment.Top,
                Width = 363
            };

            // Add to grid
            parent.Children.Add(hint);
            parent.Children.Add(ssid);
            parent.Children.Add(password);
            parent.Children.Add(authMode);
        }

        public void RemoveComponents(Grid parent)
        {
            parent.Children.Remove(hint);
            parent.Children.Remove(ssid);
            parent.Children.Remove(password);
            parent.Children.Remove(authMode);
        }
    }
}