using System;

namespace RtaAssignment.Business.Common.Contracts.V1.Dtos.Identity.Users
{
    public abstract class UserToRegisterDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
    }
}