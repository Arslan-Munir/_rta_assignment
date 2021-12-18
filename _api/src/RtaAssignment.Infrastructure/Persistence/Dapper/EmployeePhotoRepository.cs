using System.Threading.Tasks;
using RtaAssignment.Core.Entities;
using Dapper;
using RtaAssignment.Infrastructure.Persistence.Interfaces;

namespace RtaAssignment.Infrastructure.Persistence.Dapper
{
    public class EmployeePhotoRepository : IEmployeePhotoRepository
    {
        public async Task<int> Add(EmployeePhoto photo)
        {
            const string query =
                @"INSERT INTO public.employee_photos(url, public_id, employee_id) 
                VALUES (@url, @publicId, @employeeId) RETURNING id";

            using var con = await ConnectionFactory.DbConnection();

            return await con.ExecuteScalarAsync<int>(query, new
            {
                url = photo.Url,
                publicId = photo.PublicId,
                employeeId = photo.EmployeeId
            });
        }

        public async Task<EmployeePhoto> Get(int id)
        {
            const string query = @"SELECT id, url, public_id AS publicId, employee_id AS employeeId 
            FROM public.employee_photos WHERE id = @id";

            using var con = await ConnectionFactory.DbConnection();

            return await con.QueryFirstOrDefaultAsync<EmployeePhoto>(query, new {id});
        }
        
        public async Task<int> Delete(int id)
        {
            const string query = "DELETE FROM public.employee_photos WHERE id = @id RETURNING id";

            using var con = await ConnectionFactory.DbConnection();

            return await con.ExecuteAsync(query, new {id});
        }
    }
}