using AutoMapper;
using RtaAssignment.Business.Common.Contracts.V1.Dtos.Employee;
using RtaAssignment.Core.Entities;

namespace RtaAssignment.API.MappingProfiles
{
    public class DtoToDomainProfile : Profile
    {
        public DtoToDomainProfile()
        {
            EmployeeMapper();
        }

        private void EmployeeMapper()
        {

            CreateMap<EmployeeToAddDto, Employee>()
                .ForPath(dest => dest.Type.Id, opt => opt.MapFrom(src => src.TypeId));


            CreateMap<EmployeeToUpdateDto, Employee>()
                .ForPath(dest => dest.Type.Id, opt => opt.MapFrom(src => src.TypeId));
        }
    }
}