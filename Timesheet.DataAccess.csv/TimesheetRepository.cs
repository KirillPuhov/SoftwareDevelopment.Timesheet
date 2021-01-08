using System;
using System.Collections.Generic;
using System.IO;
using Timesheet.Domain;
using Timesheet.Domain.Models;

namespace Timesheet.DataAccess.csv
{
    public class TimesheetRepository : ITimesheetRepository
    {
        private readonly char _delimeter;
        private readonly string _path;

        public TimesheetRepository(CsvSettings csvSettings)
        {
            _delimeter = csvSettings.Delimeter;
            _path = csvSettings.Path + "\\timesheet.csv";
        }

        public void Add(TimeLog timeLog)
        {
            var dataRow = $"{timeLog.Date}{_delimeter}" +
                          $"{timeLog.LastName}{_delimeter}" +
                          $"{timeLog.WorkingTimeHours}\n";

            File.AppendAllText(_path, dataRow);
        }

        public TimeLog[] GetTimeLogs(string lastName)
        {
            var data = File.ReadAllText(_path);
            var dataRows = data.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var timeLogs = new List<TimeLog>();

            foreach (var dataRow in dataRows)
            {

                if (dataRow.Contains(lastName))
                {
                    var timeLog = new TimeLog();

                    var dataMembers = dataRow.Split(_delimeter);

                    timeLog.Date = DateTime.TryParse(dataMembers[1], out var date) ? date : new DateTime();
                    timeLog.LastName = dataMembers[2];
                    timeLog.WorkingTimeHours = int.TryParse(dataMembers[3], out var workingHours) ? workingHours : 0;

                    timeLogs.Add(timeLog);
                }
            }

            return timeLogs.ToArray();
        }
    }
}
