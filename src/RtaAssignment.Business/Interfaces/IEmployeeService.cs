using System.Collections.Generic;
using System.Threading.Tasks;
using RtaAssignment.Business.Common.Contracts.V1.Dtos;
using RtaAssignment.Business.Common.Contracts.V1.Dtos.Employee;
using RtaAssignment.Business.Common.Contracts.V1.Dtos.Employee.Photo;
using RtaAssignment.Business.Common.Contracts.V1.Params;

namespace RtaAssignment.Business.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeToReturnDto> Add(EmployeeToAddDto dto);
        Task<EmployeeToReturnDto> Get(int id);
        Task<(IEnumerable<EmployeeViewToReturnDto>, PaginationDetailsDto)> GetAll(EmployeeParams employeeParams);
        Task<EmployeeToReturnDto> Update(int id, EmployeeToUpdateDto dto);
        Task<EmployeePhotoToReturnDto> UploadPhoto(int employeeId, EmployeePhotoToUploadDto dto);
        Task<EmployeePhotoToReturnDto> GetPhoto(int id);
        Task<bool> DeletePhoto(int photoId);
    }
}