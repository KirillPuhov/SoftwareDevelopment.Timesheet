using System;

namespace Timesheet.Api.Models
{
    public class TimeLog
    {
        public DateTime Data { get; set; }

        public int WorkingTimeHours { get; set; }

        public string LastName { get; set; }
    }
}
