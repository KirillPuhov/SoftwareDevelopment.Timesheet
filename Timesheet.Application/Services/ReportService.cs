using System;
using System.Linq;
using Timesheet.Domain;
using Timesheet.Domain.Models;

namespace Timesheet.Application.Services
{
    public class ReportService : IReportService
    {
        private readonly ITimesheetRepository _timesheetRepository;
        private readonly IAuthService _authService;

        public ReportService(ITimesheetRepository timesheetRepository, IAuthService authService)
        {
            _timesheetRepository = timesheetRepository;
            _authService = authService;
        }

        public EmployeeReport GetEmployeeReport(string lastName)
        {
            var timeLogs = _timesheetRepository.GetTimeLogs(lastName);
            var employee = _authService.GetEmployee(lastName);
            decimal bill;
            int hours = 0;

            foreach (var log in timeLogs)
            {
                hours += log.WorkingTimeHours;
            }
            bill = hours/160 * employee.Salary;

            var result = new EmployeeReport
            {
                LastName = lastName,
                TimeLogs = timeLogs.ToList(),
                Bill = bill,
                StartTime = timeLogs.Select(t => t.Date).Min(),
                EndTime = timeLogs.Select(t => t.Date).Max(),
                TotalHours = timeLogs.Sum(x => x.WorkingTimeHours)
            };

            return result;
        }
    }
}
