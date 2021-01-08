using System.Collections.Generic;
using Timesheet.Domain.Models;

namespace Timesheet.Domain
{
    public interface IAuthService
    {
        public bool Login(string lastName);

        public Employee GetEmployee(string lastName);
    }
}
