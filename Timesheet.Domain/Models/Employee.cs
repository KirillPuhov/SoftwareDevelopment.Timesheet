using System;

namespace Timesheet.Domain.Models
{
    public class Employee
    {
        public string LastName { get; set; }

        public string NameRole { get; set; }

        public decimal Bonus { get; set; }

        public decimal Salary { get; set; }
    }
}
