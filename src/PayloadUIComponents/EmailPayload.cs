using System.Windows;
using System.Windows.Controls;

namespace SpongeQR
{
    public class EmailPayload : IPayloadUI
    {
        public TextBox email;
        public TextBox subject;
        public TextBox message;

        public void GenerateComponents(Grid parent)
        {
            email = new TextBox
            {
                Text = "The Email",
                Height = 23,
                Margin = new Thickness(383, 169, 0, 0),
                TextWrapping = TextWrapping.Wrap,
                Width = 363,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left
            };

            subject = new TextBox
            {
                Text = "The Subject.",
                Height = 23,
                Margin = new Thickness(383, 209, 0, 0),
                TextWrapping = TextWrapping.Wrap,
                Width = 363,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left
            };

            message = new TextBox
            {
                Text = "The Message.",
                Height = 102,
                Width = 363,
                Margin = new Thickness(383, 246, 0, 0),
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalScrollBarVisibility = ScrollBarVisibility.Visible,
                AcceptsReturn = true
            };

            // Append to the Window's grid
            parent.Children.Add(email);
            parent.Children.Add(subject);
            parent.Children.Add(message);
        }

        public void RemoveComponents(Grid parent)
        {
            parent.Children.Remove(email);
            parent.Children.Remove(subject);
            parent.Children.Remove(message);
        }
    }
}