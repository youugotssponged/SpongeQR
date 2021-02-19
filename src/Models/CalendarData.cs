using System;

namespace SpongeQR.Models
{
    public class CalendarData
    {
        public string CalendarSubject { get; set; } = string.Empty;
        public string CalendarDescription { get; set; } = string.Empty;
        public string CalendarLocation { get; set; } = string.Empty; // address or lat/long
        public DateTime CalendarStart { get; set; } = DateTime.Today;
        public DateTime CalendarEnd { get; set; } = DateTime.Today;
        public bool CalendarIsAllDay { get; set; } = false;
        public SpongeQR.Types.CalendarEncodeTypes CalendarEncodeType { get; set; } = SpongeQR.Types.CalendarEncodeTypes.UNIVERSAL;
    }
}
