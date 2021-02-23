using System.Collections.Generic;

namespace PAPBackOffice.Data.Entities
{
    public class WeekClass
    {
        public List<DayEvent> Dates { get; set; } = new List<DayEvent>();
    }
}
