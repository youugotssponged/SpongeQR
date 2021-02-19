using System;
using System.Collections.Generic;
using System.Text;

namespace SpongeQR.Types
{
    public enum QRTypes
    {
        Message,
        Email,
        PhoneNumber,
        URL,
        WIFI,
        CalendarEvent
    }

    public enum WIFIAuthTypes
    {
        None,
        WEP,
        WPA,
        WPA2
    }

    public enum CalendarEncodeTypes
    {
        UNIVERSAL,
        ICAL
    }
}
