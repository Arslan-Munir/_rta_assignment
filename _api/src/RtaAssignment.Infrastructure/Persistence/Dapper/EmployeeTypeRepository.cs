using System.Collections.Generic;
using System.Threading.Tasks;
using RtaAssignment.Business.Common.Contracts.V1.Params;
using RtaAssignment.Core.Entities;
using Dapper;
using RtaAssignment.Infrastructure.Persistence.Interfaces;

namespace RtaAssignment.Infrastructure.Persistence.Dapper
{
    public class EmployeeTypeRepository : IEmployeeTypeRepository
    {
        public async Task<IEnumerable<EmployeeType>> GetAll()
        {
            var query = @$"SELECT 
                                       id, 
                                       name
                                   FROM public.employee_types
                                   ORDER BY id;";

            using var con = await ConnectionFactory.DbConnection();

            return await con.QueryAsync<EmployeeType>(query);
        }
    }
}