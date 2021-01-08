using System.Collections.Generic;
using Timesheet.Domain;
using Timesheet.Domain.Models;

namespace Timesheet.Application.Services
{
    public sealed class TimesheetService : ITimesheetService
    {
        public bool TrackTime(TimeLog timeLog)
        {
            bool isValid = false;

            if (timeLog.WorkingTimeHours > 0 
                && timeLog.WorkingTimeHours <= 24
                && !string.IsNullOrWhiteSpace(timeLog.LastName))
            {
                if (UserSession.Sessions.Contains(timeLog.LastName))
                {
                    Timesheets.TimeLogs.Add(timeLog);
                    isValid = true;
                }
            }

            return isValid;
        }
    }

    public static class Timesheets
    {
        public static List<TimeLog> TimeLogs { get; set; } = new List<TimeLog>();
    }
}
