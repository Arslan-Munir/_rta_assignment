using System.Collections.Generic;
using System.Threading.Tasks;
using RtaAssignment.Core.Entities;

namespace RtaAssignment.Infrastructure.Persistence.Interfaces
{
    public interface IEmployeePhotoRepository
    {
        Task<int> Add(EmployeePhoto photo);
        Task<EmployeePhoto> Get(int id);
        Task<int> Delete(int id);
    }
}