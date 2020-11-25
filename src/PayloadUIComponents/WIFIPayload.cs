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
            hint = new Label();
            hint.Content = "Note: Must be WPA or WEP, for WPA2 just enter WPA";
            hint.HorizontalAlignment = HorizontalAlignment.Left;
            hint.Margin = new Thickness(413, 255, 0, 0);
            hint.VerticalAlignment = VerticalAlignment.Top;
            hint.Width = 309;

            ssid = new TextBox();
            ssid.HorizontalAlignment = HorizontalAlignment.Left;
            ssid.Height = 23;
            ssid.Margin = new Thickness(383, 167, 0, 0);
            ssid.TextWrapping = TextWrapping.Wrap;
            ssid.Text = "SSID - Wifi Name";
            ssid.VerticalAlignment = VerticalAlignment.Top;
            ssid.Width = 363;

            password = new TextBox();
            password.HorizontalAlignment = HorizontalAlignment.Left;
            password.Height = 23;
            password.Margin = new Thickness(383, 213, 0, 0);
            password.TextWrapping = TextWrapping.Wrap;
            password.Text = "Password";
            password.VerticalAlignment = VerticalAlignment.Top;
            password.Width = 363;

            authMode = new TextBox();
            authMode.HorizontalAlignment = HorizontalAlignment.Left;
            authMode.Height = 23;
            authMode.Margin = new Thickness(383, 281, 0, 0);
            authMode.TextWrapping = TextWrapping.Wrap;
            authMode.Text = "Authentication Type";
            authMode.VerticalAlignment = VerticalAlignment.Top;
            authMode.Width = 363;

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