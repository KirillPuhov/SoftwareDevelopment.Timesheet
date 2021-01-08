using Microsoft.AspNetCore.Mvc;
using Timesheet.Domain;
using Timesheet.Domain.Models;

namespace Timesheet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesheetController : ControllerBase
    {
        private readonly ITimesheetService _timeSheetService;
        public TimesheetController(ITimesheetService timeSheetService)
        {
            _timeSheetService = timeSheetService;
        }

        [HttpPost]
        public ActionResult<bool> Add(TimeLog timeLog)
        {
            return Ok(_timeSheetService.TrackTime(timeLog));
        }
    }
}
