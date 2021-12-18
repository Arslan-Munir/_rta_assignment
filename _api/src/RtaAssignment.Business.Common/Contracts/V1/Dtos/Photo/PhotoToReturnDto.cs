using System;

namespace RtaAssignment.Business.Common.Contracts.V1.Dtos.Photo
{
    public abstract class PhotoToReturnDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
    }
}