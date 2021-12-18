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
        public DateTime PassportExpireDate { get; set; }
        
        public EmployeeViewToReturnDto(int id, string name, string mobileNo, string email,
            string designation, int passportNo, string nationality, string photoUrl, DateTime passportExpireDate)
        {
            Id = id;
            Name = name;
            MobileNo = mobileNo;
            Designation = designation;
            PassportNo = passportNo;
            Nationality = nationality;
            PassportExpireDate = passportExpireDate;
            Email = email;
            PhotoUrl = photoUrl;
        }
    }
}