using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using RtaAssignment.Business.Common.Contracts.V1.Dtos;
using RtaAssignment.Business.Common.Contracts.V1.Params;
using RtaAssignment.Infrastructure.Components.Interfaces;
using RtaAssignment.Infrastructure.Persistence.Interfaces;
using RtaAssignment.Infrastructure.UnitOfWork;
using AutoMapper;
using RtaAssignment.Business.Common.Contracts.V1.Dtos.Employee;
using RtaAssignment.Business.Common.Contracts.V1.Dtos.Employee.Photo;
using RtaAssignment.Business.Interfaces;
using RtaAssignment.Core.Entities;
using RtaAssignment.Core.Enums;

namespace RtaAssignment.Business
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ICloudinaryComponent _cloudinaryComponent;
        private readonly IMapper _mapper;
        private readonly IEmployeePhotoRepository _photoRepository;
        private readonly IEmployeeRepository _repository;
        private readonly IUnitOfWorkFactory _unitOfWork;

        public EmployeeService(IMapper mapper, IUnitOfWorkFactory unitOfWork, IEmployeeRepository repository,
            IEmployeePhotoRepository photoRepository,
            ICloudinaryComponent cloudinaryComponent)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _photoRepository = photoRepository ?? throw new ArgumentNullException(nameof(photoRepository));
            _cloudinaryComponent = cloudinaryComponent ?? throw new ArgumentNullException(nameof(cloudinaryComponent));
        }
        public async Task<EmployeeToReturnDto> Add(EmployeeToAddDto dto)
        {
            var employee = _mapper.Map<Employee>(dto);

            using (var unitOfWork = _unitOfWork.Create())
            {
                if ((employee.Id = await _repository.Add(employee)) <= 0)
                    throw new Exception("Failed to add employee.");
                unitOfWork.Commit();
            }

            return await Get(employee.Id);
        }

        public async Task<EmployeeToReturnDto> Get(int id)
        {
            var employee = await _repository.Get(id);
            return _mapper.Map<EmployeeToReturnDto>(employee);
        }
        
        public async Task<(IEnumerable<EmployeeViewToReturnDto>, PaginationDetailsDto)> GetAll(
            EmployeeParams employeeParams)
        {
            var employees = await _repository.GetAll(employeeParams);
            return (employees,
                new PaginationDetailsDto(employees.CurrentPage, employees.ItemsPerPage, employees.TotalItems,
                    employees.TotalPages));
        }

        public async Task<EmployeeToReturnDto> Update(int id, EmployeeToUpdateDto dto)
        {
            var employee = await _repository.Get(id);
            if (employee == null)
                return null;

            if (!string.Equals(employee.Name, dto.Name, StringComparison.InvariantCultureIgnoreCase))
                _mapper.Map(dto, employee);

            using (var unitOfWork = _unitOfWork.Create())
            {
                if (await _repository.Update(employee) <= 0) throw new Exception("Failed to update employee.");
                unitOfWork.Commit();
            }

            return _mapper.Map<EmployeeToReturnDto>(employee);
        }
        
        public async Task<EmployeePhotoToReturnDto> UploadPhoto(int employeeId, EmployeePhotoToUploadDto dto)
        {
            var employee = await _repository.Get(employeeId);
            if (employee == null)
                return null;

            var uploadResult = await _cloudinaryComponent.UploadPhoto(dto.File, PhotoType.EmployeePhoto);
            if (uploadResult == null)
                return null;

            var photo = new EmployeePhoto(employee.Id, uploadResult.Url, uploadResult.PublicId);

            using var unitOfWork = _unitOfWork.Create();
            if ((photo.Id = await _photoRepository.Add(photo)) <= 0)
                throw new Exception("Failed to upload photo.");
            unitOfWork.Commit();

            return _mapper.Map<EmployeePhotoToReturnDto>(photo);
        }

        public async Task<EmployeePhotoToReturnDto> GetPhoto(int id)
        {
            var employeePhoto = await _photoRepository.Get(id);
            return _mapper.Map<EmployeePhotoToReturnDto>(employeePhoto);
        }
        
        public async Task<bool> DeletePhoto(int photoId)
        {

            var photoToDelete = await _photoRepository.Get(photoId);
            var cloudinaryDeleteResult = await _cloudinaryComponent.DeletePhoto(photoToDelete.PublicId);
            if (!cloudinaryDeleteResult.StatusCode.Equals(HttpStatusCode.OK))
                return false;
            
            using var unitOfWork = _unitOfWork.Create();
            if (await _photoRepository.Delete(photoId) <= 0)
                return false;
            unitOfWork.Commit();

            return true;
        }
    }
}