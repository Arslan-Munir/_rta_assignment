using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RtaAssignment.Identity.Entity;

namespace RtaAssignment.Identity.Data
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly UserManager<AppUser> _userManager;

        public IdentityRepository(UserManager<AppUser> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<AppUser> FindByUsernameAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<AppUser> CreateUser(AppUser user, string password, string role)
        {
            var creationResult = await _userManager.CreateAsync(user, password);
            var roleAssignResult = await _userManager.AddToRoleAsync(user, role);

            if (!creationResult.Succeeded)
                throw new InvalidOperationException(creationResult.Errors.FirstOrDefault()?.Description);

            if (!roleAssignResult.Succeeded)
                throw new InvalidOperationException(roleAssignResult.Errors.FirstOrDefault()?.Description);

            return user;
        }

        public async Task<AppUser> FindByUsernameAndPasswordAsync(string username, string password)
        {
            var appUser = await _userManager.FindByNameAsync(username);
            if (appUser == null)
                return null;

            if (!await _userManager.CheckPasswordAsync(appUser, password))
                return null;

            return appUser;
        }

        public async Task<IList<string>> GetUserRolesAsync(AppUser appUser)
        {
            return await _userManager.GetRolesAsync(appUser);
        }

        public async Task<IEnumerable<AppUser>> GetUsersInRole(string role)
        {
            return await _userManager.GetUsersInRoleAsync(role);
        }
    }
}