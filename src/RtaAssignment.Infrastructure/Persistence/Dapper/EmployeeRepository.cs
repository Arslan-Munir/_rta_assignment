using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RtaAssignment.Business.Common.Contracts.V1.Params;
using RtaAssignment.Business.Common.Helpers;
using RtaAssignment.Core.Entities;
using Dapper;
using RtaAssignment.Business.Common.Contracts.V1.Dtos.Employee;
using RtaAssignment.Infrastructure.Persistence.Interfaces;

namespace RtaAssignment.Infrastructure.Persistence.Dapper
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public async Task<int> Add(Employee employee)
        {
            const string query = @"INSERT INTO public.employees(name, nationality, designation, mobileNo, email, passportExpireDate, 
            passportNo, typeId) 
            VALUES (@name, @nationality, @designation, @mobileNo, @email, @passportExpireDate, @passportNo, @typeId) RETURNING id";

            using var con = await ConnectionFactory.DbConnection();

            return await con.ExecuteScalarAsync<int>(query, new
            {
                name = employee.Name,
                nationality = employee.Nationality,
                designation = employee.Designation,
                mobileNo = employee.MobileNo,
                email = employee.Email,
                passportExpireDate = employee.PassportExpireDate,
                passportNo = employee.PassportNo,
                typeId = employee.Type.Id
            });
        }

        public async Task<Employee> Get(int id)
        {
            var query = @"
            SELECT 
                id, name, nationality, designation, mobileNo, email, passportExpireDate, 
            passportNo, typeId 
            FROM public.employees WHERE id = @id;
                
            SELECT et.id, et.name FROM public.employee_types AS et 
                INNER JOIN public.employees AS e ON et.Id = e.typeId WHERE e.Id = @id;
                
            SELECT p.id, p.url, p.public_id AS publicId FROM public.employee_photos As p 
                WHERE p.employee_id = @id;";

            using var con = await ConnectionFactory.DbConnection();

            var result = await con.QueryMultipleAsync(query, new {id = id});
            var employee = (await result.ReadAsync<Employee>()).FirstOrDefault();

            if (employee == null) return null;

            employee.Type = (await result.ReadAsync<EmployeeType>()).FirstOrDefault();
            employee.Photo = (await result.ReadAsync<EmployeePhoto>()).FirstOrDefault();

            return employee;
        }

        public async Task<PagedList<EmployeeViewToReturnDto>> GetAll(EmployeeParams employeeParams)
        {
            var query = $@"SELECT COUNT(*) OVER() AS total, e.id, e.name, e.nationality,
                e.designation, e.mobileNo, e.email, 
                e.passportExpireDate, e.passportNo
                FROM public.employees AS e
                ORDER BY id desc LIMIT @itemsPerPage OFFSET (@currentPage - 1) * @itemsPerPage;";
            
            using var con = await ConnectionFactory.DbConnection();

            var result = await con.QueryMultipleAsync(query, new
            {
                itemsPerPage = employeeParams.ItemsPerPage,
                currentPage = employeeParams.CurrentPage
            });

            var (totalItems, employees) = await ReadData(result);

            if (employees.Count <= 0)
                return new PagedList<EmployeeViewToReturnDto>();

            return PagedList<EmployeeViewToReturnDto>.CreateAsync(employees, totalItems, employeeParams.CurrentPage,
                employeeParams.ItemsPerPage);
        }
        
        public async Task<int> Update(Employee employee)
        {
            const string query = @"UPDATE public.employees SET name = @name, nationality = @nationality,
                designation = @designation, mobileNo = @mobileNo, email = @email, passportExpireDate = @passportExpireDate, 
                passportNo = @passportNo, typeId = @typeId
                WHERE id = @id RETURNING id";

            using var con = await ConnectionFactory.DbConnection();

            return await con.ExecuteAsync(query, new
            {
                id = employee.Id, name = employee.Name, nationality = employee.Nationality,
                designation = employee.Designation, email = employee.Email, passportExpireDate = employee.PassportExpireDate,
                passportNo = employee.PassportNo, mobileNo = employee.MobileNo,
                typeId = employee.Type.Id
            });
        }

        private static async Task<(uint, List<EmployeeViewToReturnDto>)> ReadData(SqlMapper.GridReader grid)
        {
            var data = (await grid.ReadAsync<dynamic>()).ToList();

            if (data.Count <= 0)
                return (0, new List<EmployeeViewToReturnDto>());

            var totalItems = (uint) data.First().total;
            
            var employees = data.Select(e => new EmployeeViewToReturnDto
            (e.id, e.name, e.mobileNo, e.email, e.designation,
                e.passportNo,  e.nationality, e.photoUrl, e.passportExpireDate)).ToList();
            
            return (totalItems, employees);
        }
    }
}