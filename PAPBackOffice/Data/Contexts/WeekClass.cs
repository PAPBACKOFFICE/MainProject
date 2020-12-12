using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPBackOffice.Data.Contexts
{
    public class WeekClass
    {
        public List<DayEvent> Dates { get; set; } = new List<DayEvent>();
    }
}
