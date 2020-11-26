using System.Windows;
using System.Windows.Controls;

namespace SpongeQR
{
    public class MessagePayload : IPayloadUI
    {
        public TextBox message;

        public void GenerateComponents(Grid parent)
        {
            message = new TextBox
            {
                Text = "Message to Encode",
                TextWrapping = TextWrapping.Wrap,
                AcceptsReturn = true,
                VerticalScrollBarVisibility = ScrollBarVisibility.Visible,
                Margin = new Thickness(384, 164, 46, 119)
            };


            parent.Children.Add(message);
        }

        public void RemoveComponents(Grid parent)
        {
            parent.Children.Remove(message);
        }
    }
}