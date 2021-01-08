using NUnit.Framework;
using System;
using Timesheet.Application.Services;
using Timesheet.Domain.Models;

namespace Timesheet.Tests
{
    class TimesheetServiceTest
    {
        [TestCase(12, "Сидоров")]
        [TestCase(21, "Иванов")]
        public void TrackTime_ShouldReturnTrue(short hours, string lastName)
        {
            //arrange
           UserSession.Sessions.Add(lastName);

            var timeLog = new TimeLog
            {
                Date = new DateTime(),
                WorkingTimeHours = hours,
                LastName = lastName
            };

            var service = new TimesheetService();

            //act
            var result = service.TrackTime(timeLog);

            //assert
            Assert.IsTrue(result);
        }

        [TestCase(25, "")]
        [TestCase(0, null)]
        [TestCase(-1, "")]
        [TestCase(-1, "TestUser")]
        [TestCase(0, null)]
        [TestCase(4, "")]
        [TestCase(4, null)]
        public void TrackTime_ShouldReturnFalse(short hours, string lastName)
        {
            //arrange
            var timeLog = new TimeLog
            {
                Date = new DateTime(),
                WorkingTimeHours = hours,
                LastName = lastName
            };

            var service = new TimesheetService();

            //act
            var result = service.TrackTime(timeLog);

            //assert
            Assert.IsFalse(result);
        }
    }
}
