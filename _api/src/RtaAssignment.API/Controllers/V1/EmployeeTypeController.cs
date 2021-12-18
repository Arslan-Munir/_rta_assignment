using System;
using System.Threading.Tasks;
using RtaAssignment.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RtaAssignment.API.Contracts;

namespace RtaAssignment.API.Controllers.V1
{
    [ApiController]
    [Authorize(Roles = "Super Admin")]
    public class EmployeeTypeController : ControllerBase
    {
        private readonly IEmployeeTypeService _service;

        public EmployeeTypeController(IEmployeeTypeService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }
        
        [HttpGet(ApiRoutes.EmployeeType.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var employeeTypes = await _service.GetAll();
            return Ok(employeeTypes);
        }
    }
}