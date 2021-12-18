using AutoMapper;
using RtaAssignment.Business.Common.Contracts.V1.Dtos.Employee;
using RtaAssignment.Business.Common.Contracts.V1.Dtos.Employee.Photo;
using RtaAssignment.Core.Entities;

namespace RtaAssignment.API.MappingProfiles
{
    public class DomainToDtoProfile : Profile
    {
        public DomainToDtoProfile()
        {
            EmployeeMapper();
        }

        private void EmployeeMapper()
        {
            CreateMap<EmployeeType, EmployeeTypeToReturnDto>();
            CreateMap<Employee, EmployeeToReturnDto>();
            CreateMap<EmployeePhoto, EmployeePhotoToReturnDto>();
        }
    }
}