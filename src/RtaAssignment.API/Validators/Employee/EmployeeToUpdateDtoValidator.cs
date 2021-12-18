using FluentValidation;
using RtaAssignment.Business.Common.Contracts.V1.Dtos.Employee;

namespace RtaAssignment.API.Validators.Employee
{
    public class EmployeeToUpdateDtoValidator : AbstractValidator<EmployeeToUpdateDto>
    {
        public EmployeeToUpdateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Invalid name.");
            RuleFor(x => x.Nationality).NotEmpty().WithMessage("Invalid Nationality.");
            RuleFor(x => x.Designation).NotEmpty().WithMessage("Invalid Designation.");
        }
    }
}