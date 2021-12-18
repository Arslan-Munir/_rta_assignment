using System;
using System.Threading.Tasks;
using RtaAssignment.Business.Common.Contracts.V1.Params;
using RtaAssignment.Business.Common.Helpers;
using RtaAssignment.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RtaAssignment.API.Contracts;
using RtaAssignment.Business.Common.Contracts.V1.Dtos.Employee;
using RtaAssignment.Business.Common.Contracts.V1.Dtos.Employee.Photo;

namespace RtaAssignment.API.Controllers.V1
{
    [ApiController]
    [Authorize(Roles = "Super Admin")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        }

        [HttpPost(ApiRoutes.Employee.Add)]
        public async Task<IActionResult> Add(EmployeeToAddDto dto)
        {
            var employeeToReturn = await _employeeService.Add(dto);
            return CreatedAtRoute("GetEmployee", new {id = employeeToReturn.Id}, employeeToReturn);
        }

        [HttpGet(ApiRoutes.Employee.Get, Name = "GetEmployee")]
        public async Task<IActionResult> Get(int id)
        {
            var employeeToReturn = await _employeeService.Get(id);
            return Ok(employeeToReturn);
        }

        [HttpGet(ApiRoutes.Employee.GetAll)]
        public async Task<IActionResult> GetAll([FromQuery] EmployeeParams employeeParams)
        {
            var (employeesToReturn, paginationDetails) = await _employeeService.GetAll(employeeParams);
            Response.AddPagination(paginationDetails);
            return Ok(employeesToReturn);
        }

        [HttpPut(ApiRoutes.Employee.Update)]
        public async Task<IActionResult> Update(int id, EmployeeToUpdateDto dto)
        {
            var employeeToReturn = await _employeeService.Update(id, dto);
            if (employeeToReturn == null)
                return BadRequest();

            return Ok(employeeToReturn);
        }

        [HttpPost(ApiRoutes.Employee.UploadPhoto)]
        public async Task<IActionResult> UploadPhoto(int id, [FromForm] EmployeePhotoToUploadDto dto)
        {
            var photoToReturn = await _employeeService.UploadPhoto(id, dto);
            if (photoToReturn == null)
                return BadRequest("Failed to upload photo.");

            return CreatedAtRoute("EmployeePhoto", new {id = photoToReturn.Id}, photoToReturn);
        }

        [HttpGet(ApiRoutes.Employee.Photo, Name = "EmployeePhoto")]
        public async Task<IActionResult> GetPhoto(int id)
        {
            var photoToReturn = await _employeeService.GetPhoto(id);
            return Ok(photoToReturn);
        }
        

        [HttpDelete(ApiRoutes.Employee.DeletePhoto)]
        public async Task<IActionResult> DeletePhoto(int photoId)
        {
            var result = await _employeeService.DeletePhoto(photoId);
            return result ? (IActionResult) NoContent() : BadRequest("Failed to delete photo.");
        }
    }
}