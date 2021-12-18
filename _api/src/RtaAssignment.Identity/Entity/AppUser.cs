using System;
using Microsoft.AspNetCore.Identity;

namespace RtaAssignment.Identity.Entity
{
    public sealed class AppUser : IdentityUser
    {
        public AppUser()
        { }

        public AppUser(string userName, string email, string phoneNumber)
        {
            if(string.IsNullOrWhiteSpace(userName) ||
               string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phoneNumber))
                throw new InvalidOperationException("Please provide all details for user.");

            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}