using Timesheet.Domain;
using Timesheet.Domain.Models;

namespace Timesheet.Application.Services
{
    public sealed class TimesheetService : ITimesheetService
    {
        private readonly ITimesheetRepository _timesheetRepository;

        public TimesheetService(ITimesheetRepository timesheetRepository)
        {
            _timesheetRepository = timesheetRepository;
        }

        public bool TrackTime(TimeLog timeLog)
        {
            bool isValid = false;

            if (timeLog.WorkingTimeHours > 0 
                        && timeLog.WorkingTimeHours <= 24 
                        && timeLog.LastName != string.Empty)
            {
                if (UserSession.Sessions.Contains(timeLog.LastName))
                {
                    _timesheetRepository.Add(timeLog);
                    isValid = true;
                }
            }

            return isValid;
        }
    }
}
