using System.Collections.Generic;
using System.Threading.Tasks;
using RtaAssignment.Business.Common.Contracts.V1.Dtos.Employee;
using RtaAssignment.Business.Common.Contracts.V1.Params;
using RtaAssignment.Business.Common.Helpers;
using RtaAssignment.Core.Entities;

namespace RtaAssignment.Infrastructure.Persistence.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<int> Add(Employee employee);
        Task<Employee> Get(int id);
        Task<PagedList<EmployeeViewToReturnDto>> GetAll(EmployeeParams employeeParams);
        Task<int> Update(Employee employee);
    }
}