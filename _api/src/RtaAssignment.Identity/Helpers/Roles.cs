using System.Collections.Generic;

namespace RtaAssignment.Identity.Helpers
{
    public static class Roles
    {
        public const string SuperAdmin = "Super Admin";
        public const string Admin = "Admin";

        public static IEnumerable<string> GetRoles()
        {
            return new[] {SuperAdmin, Admin};
        }
    }
}