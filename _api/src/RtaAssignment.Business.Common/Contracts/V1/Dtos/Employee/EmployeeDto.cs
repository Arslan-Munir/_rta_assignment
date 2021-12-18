using System;

namespace RtaAssignment.Business.Common.Contracts.V1.Dtos.Employee
{
    public abstract class EmployeeDto
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value.Trim();
        }

        public string Nationality { get; set; }
        public string Designation { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        
        public int PassportNo { get; set; }
        public DateTime PassportExpireDate { get; set; }
    }
}