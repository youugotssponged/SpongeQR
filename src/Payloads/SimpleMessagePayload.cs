using System.Windows;
using System.Windows.Controls;

namespace SpongeQR
{
    public class SimpleMessagePayload : IPayloadUI
    {
        public TextBox message;

        public void GenerateComponents(Grid parent)
        {
            message = new TextBox();

            message.Text = "Message to Encode";
            message.TextWrapping = System.Windows.TextWrapping.Wrap;
            message.AcceptsReturn = true;
            message.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            message.Margin = new Thickness(384, 164, 46, 119);

            parent.Children.Add(message);
        }

        public void RemoveComponents(Grid parent)
        {
            parent.Children.Remove(message);
        }
    }
}
