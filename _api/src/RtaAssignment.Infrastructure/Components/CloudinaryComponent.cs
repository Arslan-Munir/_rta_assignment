using System;
using System.Threading.Tasks;
using RtaAssignment.Business.Common.Configurations;
using RtaAssignment.Business.Common.Contracts.V1.Dtos.Cloudinary;
using RtaAssignment.Core.Enums;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using RtaAssignment.Infrastructure.Components.Interfaces;

namespace RtaAssignment.Infrastructure.Components
{
    public class CloudinaryComponent : ICloudinaryComponent
    {
        private readonly CloudinaryConfigurations _cloudinaryConfigs;
        private readonly Cloudinary _cloudinary;

        public CloudinaryComponent(IOptions<CloudinaryConfigurations> cloudinaryConfigs)
        {
            _cloudinaryConfigs = cloudinaryConfigs.Value ?? throw new ArgumentNullException(nameof(cloudinaryConfigs));

            var configs = cloudinaryConfigs.Value ?? throw new ArgumentNullException(nameof(CloudinaryConfigurations));

            var acc = new Account(
                configs.CloudName,
                configs.ApiKey,
                configs.ApiSecret
            );

            _cloudinary = new Cloudinary(acc);
        }

        public async Task<ImageUploadResultDto> UploadPhoto(IFormFile file, PhotoType photoType)
        {
            var folder = SetFolderName(photoType);

            await using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.Name, stream),
                Folder = folder
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);
            if (uploadResult == null)
                return null;

            return new ImageUploadResultDto
            {
                Url = uploadResult.SecureUrl.ToString(),
                PublicId = uploadResult.PublicId
            };
        }

        public async Task<ImageDeletionResultDto> DeletePhoto(string publicId)
        {
            var deletionParams = new DeletionParams(publicId)
            {
                Invalidate = true
            };
            var result = await _cloudinary.DestroyAsync(deletionParams);
            
            return new ImageDeletionResultDto
            {
                StatusCode = result.StatusCode
            };
        }

        private string SetFolderName(PhotoType photoType)
        {
            return photoType switch
            {
                PhotoType.EmployeePhoto => _cloudinaryConfigs.EmployeePhotoFolder,
                PhotoType.PassportPhoto => _cloudinaryConfigs.PassportPhotoFolder,
                _ => throw new ArgumentOutOfRangeException(nameof(photoType), photoType, null)
            };
        }
    }
}