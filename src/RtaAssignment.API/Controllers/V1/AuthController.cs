using System;
using System.Threading.Tasks;
using RtaAssignment.Business.Common.Contracts.V1.Dtos.Identity.Auth;
using RtaAssignment.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RtaAssignment.API.Contracts;

namespace RtaAssignment.API.Controllers.V1
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        [HttpPost(ApiRoutes.Auth.Login)]
        public async Task<IActionResult> Login(UserToLoginDto dto)
        {
            var loggedInResult = await _authService.Login(dto);
            if (loggedInResult == null)
                return Unauthorized();

            return Ok(loggedInResult);
        }
    }
}