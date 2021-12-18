using System.Collections.Generic;
using System.Threading.Tasks;
using RtaAssignment.Business.Common.Contracts.V1.Dtos.Employee;

namespace RtaAssignment.Business.Interfaces
{
    public interface IEmployeeTypeService
    {
        Task<IEnumerable<EmployeeTypeToReturnDto>> GetAll();
    }
}