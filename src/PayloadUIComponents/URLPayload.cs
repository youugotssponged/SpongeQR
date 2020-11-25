using System.Windows;
using System.Windows.Controls;

namespace SpongeQR
{
    public class URLPayload : IPayloadUI
    {
        public TextBox url;

        public void GenerateComponents(Grid parent)
        {
            url = new TextBox();

            url.Text = "URL to Encode";
            url.TextWrapping = System.Windows.TextWrapping.Wrap;
            url.AcceptsReturn = true;
            url.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            url.Margin = new Thickness(384, 164, 46, 119);

            parent.Children.Add(url);
        }

        public void RemoveComponents(Grid parent)
        {
            parent.Children.Remove(url);
        }
    }
}