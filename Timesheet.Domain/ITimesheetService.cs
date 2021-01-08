using Timesheet.Domain.Models;

namespace Timesheet.Domain
{
    public interface ITimesheetService
    {
        public bool TrackTime(TimeLog timeLog);
    }
}
