using SpongeQR.Types;

namespace SpongeQR.Models
{
    public class WIFIData
    {
        public string WifiSSID { get; set; } = string.Empty;
        public string WifiPassword { get; set; } = string.Empty;
        public WIFIAuthTypes WifiAuthType { get; set; } = WIFIAuthTypes.None;
    }
}
