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
            bool isValid = !string.IsNullOrEmpty(staffEmployee.LastName) && staffEmployee.Rate > 0;

            if (isValid)
            {
                _employeeRepository.AddEmployee(staffEmployee);
            }

            return isValid;
        }
    }
}
