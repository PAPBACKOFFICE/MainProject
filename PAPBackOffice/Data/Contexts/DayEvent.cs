using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAPBackOffice.Data.Contexts
{
    public class DayEvent
    {
        public int DayEventID { get; set; }
        public string Note { get; set; }
        public DateTime EventDate { get; set; } = new DateTime(1900, 1, 1);
   
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string DateValue { get; set; }
        public string DayName { get; set; }

    }
}
