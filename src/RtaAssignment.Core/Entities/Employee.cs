using System;

namespace RtaAssignment.Core.Entities
{
    public class Employee : User
    {
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Nationality { get; set; }
        public string Designation { get; set; }
        public int PassportNo { get; set; }
        public DateTime PassportExpireDate { get; set; }
        public EmployeeType Type { get; set; }
        public EmployeePhoto Photo { get; set; }
        public PassportPhoto PassportPhoto { get; set; }
    }
}