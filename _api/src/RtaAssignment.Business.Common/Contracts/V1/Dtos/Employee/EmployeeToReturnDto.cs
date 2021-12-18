using RtaAssignment.Business.Common.Contracts.V1.Dtos.Employee.Photo;

namespace RtaAssignment.Business.Common.Contracts.V1.Dtos.Employee
{
    public class EmployeeToReturnDto : EmployeeDto
    {
        public int Id { get; set; }
        public EmployeeTypeToReturnDto Type { get; set; } = new EmployeeTypeToReturnDto();
        public EmployeePhotoToReturnDto Photo { get; set; } = new EmployeePhotoToReturnDto();
    }
}