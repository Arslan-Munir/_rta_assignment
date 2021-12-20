using System;

namespace RtaAssignment.Business.Common.Contracts.V1.Dtos.Employee
{
    public class EmployeeViewToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public string Designation { get; set; }
        public string Nationality { get; set; }
        public int PassportNo { get; set; }
        public string PassportExpireDate { get; set; }
        
        public EmployeeViewToReturnDto(int id, string name, string nationality, string designation, string mobileNo, string email,
             int passportNo, DateTime passportExpireDate)
        {
            Id = id;
            Name = name;
            Email = email;
            MobileNo = mobileNo;
            PassportNo = passportNo;
            Designation = designation;
            Nationality = nationality;
            PassportExpireDate = passportExpireDate.ToLongDateString();
        }
    }
}