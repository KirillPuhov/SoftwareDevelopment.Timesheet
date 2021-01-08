using System;
using System.Collections.Generic;

namespace Timesheet.Domain.Models
{
    public class EmployeeReport
    {
        public string LastName { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }


        public List<TimeLog> TimeLogs { get; set; }


        public int TotalHours { get; set; }

        public decimal Bill { get; set; }
    }
}
