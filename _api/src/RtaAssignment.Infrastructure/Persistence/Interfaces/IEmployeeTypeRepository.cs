using System.Collections.Generic;
using System.Threading.Tasks;
using RtaAssignment.Core.Entities;

namespace RtaAssignment.Infrastructure.Persistence.Interfaces
{
    public interface IEmployeeTypeRepository
    {
        Task<IEnumerable<EmployeeType>> GetAll();
    }
}