using System.Threading.Tasks;
using RtaAssignment.Business.Common.Contracts.V1.Dtos.Identity.Auth;

namespace RtaAssignment.Business.Interfaces
{
    public interface IAuthService
    {
        Task<AuthSuccessDto> Login(UserToLoginDto dto);
    }
}