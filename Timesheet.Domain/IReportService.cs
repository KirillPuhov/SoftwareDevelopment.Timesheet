﻿using System;
using System.Collections.Generic;
using System.Text;
using Timesheet.Domain.Models;

namespace Timesheet.Domain
{
    public interface IReportService
    {
        public EmployeeReport GetEmployeeReport(string lastName);
    }
}
