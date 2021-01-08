using System;

namespace Timesheet.Domain.Models
{
    public class TimeLog
    {
        public DateTime Date { get; set; }

        public int WorkingTimeHours { get; set; }

        public string LastName { get; set; }
    }
}
