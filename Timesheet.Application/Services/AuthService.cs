using System.Collections.Generic;
using System.Linq;
using Timesheet.Domain;
using Timesheet.Domain.Models;

namespace Timesheet.Application.Services
{
    public sealed class AuthService : IAuthService
    {
        public AuthService()
        {
            Emloyees.Add(new Employee()
            {
                LastName = "Иванов",
                Post = "Сотрудник",
                Rate = 120000
            });

            Emloyees.Add(new Employee()
            {
                LastName = "Петров",
                Post = "Сотрудник",
                Rate = 100000
            });

            Emloyees.Add(new Employee()
            {
                LastName = "Сидоров",
                Post = "Сотрудник",
                Rate = 125000
            });

        }

        public List<Employee> Emloyees = new List<Employee>();

        public bool Login(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                return false;
            }

            bool isEmployeeExist = Emloyees.Exists(x => x.LastName == lastName);

            if (isEmployeeExist)
            {
                UserSession.Sessions.Add(lastName);
            }

            return isEmployeeExist;
        }

        public Employee GetEmployee(string lastName)
        {
            var targetEmployee = Emloyees.Find(x => x.LastName == lastName);
            return targetEmployee;
        }
    }

    public static class UserSession
    {
        public static HashSet<string> Sessions { get; set; } = new HashSet<string>();
    }
}
