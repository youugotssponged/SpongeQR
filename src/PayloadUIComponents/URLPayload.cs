using System.Windows;
using System.Windows.Controls;

namespace SpongeQR
{
    public class URLPayload : IPayloadUI
    {
        public TextBox url;

        public void GenerateComponents(Grid parent)
        {
            url = new TextBox
            {
                Text = "URL to Encode",
                TextWrapping = System.Windows.TextWrapping.Wrap,
                AcceptsReturn = true,
                VerticalScrollBarVisibility = ScrollBarVisibility.Visible,
                Margin = new Thickness(384, 164, 46, 119)
            };

            parent.Children.Add(url);
        }

        public void RemoveComponents(Grid parent)
        {
            parent.Children.Remove(url);
        }
    }
}