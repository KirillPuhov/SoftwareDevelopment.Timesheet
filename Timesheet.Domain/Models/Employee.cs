using System;
using System.Collections.Generic;
using System.Text;

namespace Timesheet.Domain.Models
{
    public class Employee
    {
        public string LastName { get; set; }

        public string Post { get; set; }

        public decimal Rate { get; set; }
    }
}
