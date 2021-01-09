using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Timesheet.Domain;
using Timesheet.Domain.Models;

namespace Timesheet.DataAccess.csv
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly char _delimeter;
        private readonly string _path;

        public EmployeeRepository(CsvSettings csvSettings)
        {
            _delimeter = csvSettings.Delimeter;
            _path = csvSettings.Path + "\\employees.csv";
        }

        public void AddEmployee(Employee staffEmployee)
        {
            var dataRow = $"{staffEmployee.LastName}{_delimeter}" +
                          $"{staffEmployee.NameRole}{_delimeter}" +
                          $"{staffEmployee.Bonus}{_delimeter}" +
                          $"{staffEmployee.Salary}{_delimeter}\n";

            File.AppendAllText(_path, dataRow);
        }

        public Employee GetEmployee(string lastName)
        {
            var data = File.ReadAllText(_path);
            var dataRows = data.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Employee staffEmployee = null;

            foreach (var dataRow in dataRows)
            {
                if (dataRow.Contains(lastName))
                {
                    var dataMembers = dataRow.Split(_delimeter);

                    staffEmployee = new Employee
                    {
                        LastName = dataMembers[0],
                        NameRole = dataMembers[1],
                        Bonus = decimal.TryParse(dataMembers[2], out var bouns) ? bouns : 0,
                        Salary = decimal.TryParse(dataMembers[3], out var salary) ? salary : 0
                    };

                    break;
                }
            }

            return staffEmployee;
        }
    }
}
