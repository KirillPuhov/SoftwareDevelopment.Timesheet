using System;
using Timesheet.Domain;
using Timesheet.Domain.Models;

namespace Timesheet.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public bool AddEmployee(Employee staffEmployee)
        {
            bool isValid = false;

            if (!string.IsNullOrEmpty(staffEmployee.LastName) 
                        && !string.IsNullOrEmpty(staffEmployee.NameRole) 
                        && staffEmployee.Bonus > 0 
                        && staffEmployee.Bonus < int.MaxValue / 2 
                        && staffEmployee.Salary > 0
                        && staffEmployee.Salary < int.MaxValue / 2)
            {
                _employeeRepository.AddEmployee(staffEmployee);
                isValid = true;
            }

            return isValid;
        }
    }
}
