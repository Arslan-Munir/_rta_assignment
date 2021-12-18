using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RtaAssignment.Business.Common.Contracts.V1.Dtos.Identity.Users.SuperAdmin;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RtaAssignment.Identity.Entity;
using RtaAssignment.Identity.Helpers;

namespace RtaAssignment.Identity.Data
{
    public class SeedIdentity
    {
        public static async Task AddRoles(RoleManager<IdentityRole> roleManager)
        {
            var roles = Roles.GetRoles();

            foreach (var role in roles)
            {
                if (await roleManager.RoleExistsAsync(role))
                    continue;

                await roleManager.CreateAsync(new IdentityRole {Name = role});
            }
        }

        public static async Task AddSuperAdminUsers(UserManager<AppUser> userManager,
            IEnumerable<SuperAdminToRegisterDto> users)
        {
            var availableUsers = await userManager.Users.ToListAsync();

            foreach (var user in users.Where(user => !availableUsers.Any(x => x.UserName.Equals(user.Username))))
            {
                var appUser = new AppUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = user.Username.ToLower(),
                    Email = user.Email
                };

                await userManager.CreateAsync(appUser, user.Password);
                await userManager.AddToRoleAsync(appUser, Roles.SuperAdmin);
            }
        }
    }
}