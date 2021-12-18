using Microsoft.AspNetCore.Http;

namespace RtaAssignment.Business.Common.Contracts.V1.Dtos.Photo
{
    public abstract class PhotoToUploadDto
    {
        public IFormFile File { get; set; }
    }
}