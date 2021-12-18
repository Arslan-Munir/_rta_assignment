using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using RtaAssignment.Business.Common.Configurations;
using RtaAssignment.Business.Common.Contracts.V1.Dtos.Identity.Auth;
using RtaAssignment.Identity.Data;
using RtaAssignment.Identity.Entity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RtaAssignment.Business.Interfaces;

namespace RtaAssignment.Business
{
    public class AuthService : IAuthService
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly JwtConfigurations _jwtConfigurations;

        public AuthService(IIdentityRepository identityRepository, IOptions<JwtConfigurations> jwtConfigurations)
        {
            _identityRepository = identityRepository ?? throw new ArgumentNullException(nameof(identityRepository));
            _jwtConfigurations = jwtConfigurations.Value ?? throw new ArgumentNullException(nameof(jwtConfigurations));
        }

        public async Task<AuthSuccessDto> Login(UserToLoginDto dto)
        {
            var appUser = await _identityRepository.FindByUsernameAndPasswordAsync(dto.Username, dto.Password);
            if (appUser == null)
                return null;
            var roles = await _identityRepository.GetUserRolesAsync(appUser);
            return await GenerateAuthToken(appUser);
        }

        private async Task<AuthSuccessDto> GenerateAuthToken(AppUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfigurations.Secret);
            var claims = AssignClaims(user);
            await AssignRoles(user, claims);
            var tokenDescription = TokenDescription(claims, key);
            var token = tokenHandler.CreateToken(tokenDescription);

            return new AuthSuccessDto
            {
                Token = tokenHandler.WriteToken(token)
            };
        }

        private List<Claim> AssignClaims(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id", user.Id)
            };
            return claims;
        }

        private async Task AssignRoles(AppUser user, List<Claim> claims)
        {
            var roles = await _identityRepository.GetUserRolesAsync(user);
            if (roles.Any()) claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
        }

        private SecurityTokenDescriptor TokenDescription(IEnumerable<Claim> claims, byte[] key)
        {
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(_jwtConfigurations.TokenLifetime),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _jwtConfigurations.Issuer,
                Audience = _jwtConfigurations.Audience
            };
            return tokenDescription;
        }
    }
}