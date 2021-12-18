using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RtaAssignment.Infrastructure.Persistence.Interfaces;
using AutoMapper;
using RtaAssignment.Business.Common.Contracts.V1.Dtos.Employee;
using RtaAssignment.Business.Interfaces;

namespace RtaAssignment.Business
{
    public class EmployeeTypeService : IEmployeeTypeService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeTypeRepository _repository;

        public EmployeeTypeService(IMapper mapper, IEmployeeTypeRepository repository)

        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        
        public async Task<IEnumerable<EmployeeTypeToReturnDto>> GetAll()
        {
            var employeeTypes = await _repository.GetAll();
            return _mapper.Map<IEnumerable<EmployeeTypeToReturnDto>>(employeeTypes);
        }
    }
}