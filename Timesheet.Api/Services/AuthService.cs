using System.Collections.Generic;

namespace Timesheet.Api.Services
{
    public sealed class AuthService
    {
        public AuthService()
        {
            Emloyees = new List<string>
            {
                "Иванов",
                "Петров",
                "Сидоров"
            };
        }

        public List<string> Emloyees { get; private set; }


        public bool Login(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                return false;
            }

            bool isEmployeeExist = Emloyees.Contains(lastName);

            if (isEmployeeExist)
            {
                UserSession.Sessions.Add(lastName);
            }

            return isEmployeeExist;
        }
    }

    public static class UserSession
    {
        public static HashSet<string> Sessions { get; set; } = new HashSet<string>();
    }
}
