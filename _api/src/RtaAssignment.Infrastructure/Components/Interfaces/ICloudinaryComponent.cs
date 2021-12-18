using System.Threading.Tasks;
using RtaAssignment.Business.Common.Contracts.V1.Dtos.Cloudinary;
using RtaAssignment.Core.Enums;
using Microsoft.AspNetCore.Http;

namespace RtaAssignment.Infrastructure.Components.Interfaces
{
    public interface ICloudinaryComponent
    {
        Task<ImageUploadResultDto> UploadPhoto(IFormFile file, PhotoType photoType);
        Task<ImageDeletionResultDto> DeletePhoto(string publicId);
    }
}