using System.Linq;
using RtaAssignment.Business.Common.Contracts.V1.Dtos.Identity.Auth;
using FluentValidation;

namespace RtaAssignment.API.Validators.Auth
{
    public class UserToLoginDtoValidator : AbstractValidator<UserToLoginDto>
    {
        public UserToLoginDtoValidator()
        {
            RuleFor(x => x.Username).Must(n => !string.IsNullOrWhiteSpace(n) && !n.Any(char.IsWhiteSpace))
                .WithMessage("Invalid username.");
            RuleFor(x => x.Password).Must(n => !string.IsNullOrWhiteSpace(n)).WithMessage("Invalid password.");
        }
    }
}