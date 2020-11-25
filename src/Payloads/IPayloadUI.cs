using System.Windows.Controls;

namespace SpongeQR
{
    public interface IPayloadUI
    {
        void GenerateComponents(Grid parent);
        void RemoveComponents(Grid parent);
    }
}
