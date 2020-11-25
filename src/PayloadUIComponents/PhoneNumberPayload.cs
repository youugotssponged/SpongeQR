using System.Windows;
using System.Windows.Controls;

namespace SpongeQR
{
    public class PhoneNumberPayload : IPayloadUI
    {
        public TextBox number;

        public void GenerateComponents(Grid parent)
        {
            number = new TextBox();

            number.Text = "The Phone Number";
            number.Height = 23;
            number.Margin = new Thickness(383, 169, 0, 0);
            number.TextWrapping = TextWrapping.Wrap;
            number.Width = 363;
            number.VerticalAlignment = VerticalAlignment.Top;
            number.HorizontalAlignment = HorizontalAlignment.Left;

            parent.Children.Add(number);
        }

        public void RemoveComponents(Grid parent)
        {
            parent.Children.Remove(number);
        }
    }
}