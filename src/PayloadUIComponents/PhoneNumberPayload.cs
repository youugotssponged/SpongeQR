using System.Windows;
using System.Windows.Controls;

namespace SpongeQR
{
    public class PhoneNumberPayload : IPayloadUI
    {
        public TextBox number;

        public void GenerateComponents(Grid parent)
        {
            number = new TextBox
            {
                Text = "The Phone Number",
                Height = 23,
                Margin = new Thickness(383, 169, 0, 0),
                TextWrapping = TextWrapping.Wrap,
                Width = 363,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left
            };

            parent.Children.Add(number);
        }

        public void RemoveComponents(Grid parent)
        {
            parent.Children.Remove(number);
        }
    }
}