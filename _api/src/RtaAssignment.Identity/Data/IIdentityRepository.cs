using System.Collections.Generic;
using System.Threading.Tasks;
using RtaAssignment.Identity.Entity;

namespace RtaAssignment.Identity.Data
{
    public interface IIdentityRepository
    {
        Task<AppUser> FindByUsernameAsync(string username);
        Task<AppUser> CreateUser(AppUser user, string password, string role);
        Task<AppUser> FindByUsernameAndPasswordAsync(string username, string password);
        Task<IList<string>> GetUserRolesAsync(AppUser appUser);
        Task<IEnumerable<AppUser>> GetUsersInRole(string role);
    }
}