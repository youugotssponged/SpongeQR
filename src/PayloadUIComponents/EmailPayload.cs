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
            email = new TextBox();
            subject = new TextBox();
            message = new TextBox();

            email.Text = "The Email";
            email.Height = 23;
            email.Margin = new Thickness(383, 169, 0, 0);
            email.TextWrapping = TextWrapping.Wrap;
            email.Width = 363;
            email.VerticalAlignment = VerticalAlignment.Top;
            email.HorizontalAlignment = HorizontalAlignment.Left;

            subject.Text = "The Subject.";
            subject.Height = 23;
            subject.Margin = new Thickness(383, 209, 0, 0);
            subject.TextWrapping = TextWrapping.Wrap;
            subject.Width = 363;
            subject.VerticalAlignment = VerticalAlignment.Top;
            subject.HorizontalAlignment = HorizontalAlignment.Left;

            message.Text = "The Message.";
            message.Height = 102;
            message.Width = 363;
            message.Margin = new Thickness(383, 246, 0, 0);
            message.TextWrapping = TextWrapping.Wrap;
            message.VerticalAlignment = VerticalAlignment.Top;
            message.HorizontalAlignment = HorizontalAlignment.Left;
            message.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            message.AcceptsReturn = true;

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