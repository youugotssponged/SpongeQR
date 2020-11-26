using System.Windows;
using System.Windows.Controls;

namespace SpongeQR
{
    // TODO: Implement This
    public class CalendarPayload : IPayloadUI
    {
        public Label notImplemented;
        public void GenerateComponents(Grid parent)
        {
            // Remove Later
            notImplemented = new Label
            {
                Content = "This feature is currently unavailable, but will be in the next update! - Sorry :(",
                HorizontalAlignment = HorizontalAlignment.Right,
                Margin = new Thickness(200, 100, 0, 0),
                VerticalAlignment = VerticalAlignment.Center,
                Width = 450
            };

            parent.Children.Add(notImplemented);
        }

        public void RemoveComponents(Grid parent)
        {
            parent.Children.Remove(notImplemented);
        }
    }
}
