using FluentValidation;
using RtaAssignment.Business.Common.Contracts.V1.Dtos.Employee.Photo;

namespace RtaAssignment.API.Validators.Employee
{
    public class EmployeePhotoToUploadDtoValidator : AbstractValidator<EmployeePhotoToUploadDto>
    {
        public EmployeePhotoToUploadDtoValidator()
        {
            RuleFor(x => x.File).NotEmpty().WithMessage("Invalid document.");
            RuleFor(x => x.File.Length).GreaterThan(0).WithMessage("Invalid document.");
        }
    }
}