using NUnit.Framework;
using System;
using Timesheet.Api.Models;
using Timesheet.Api.Services;

namespace Timesheet.Tests
{
    class TimesheetServiceTest
    {
        [Test]
        public void TrackTime_ShouldReturnTrue()
        {
            //arrange
            var timeLog = new TimeLog
            {
                Data = new DateTime(),
                WorkingTimeHours = 1,
                LastName = ""
            };

            var service = new TimesheetService();

            //act
            var result = service.TrackTime(timeLog);

            //assert
            Assert.IsTrue(result);
        }

        [Test]
        public void TrackTime_ShouldReturnFalse()
        {
            //arrange
            var timeLog = new TimeLog
            {
                Data = new DateTime(),
                WorkingTimeHours = 1,
                LastName = ""
            };

            var service = new TimesheetService();

            //act
            var result = service.TrackTime(timeLog);

            //assert
            Assert.IsFalse(result);
        }
    }
}
