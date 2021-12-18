using System;

namespace RtaAssignment.Business.Common.Contracts.V1.Dtos.Identity.Users
{
    public abstract class UserToReturnDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}