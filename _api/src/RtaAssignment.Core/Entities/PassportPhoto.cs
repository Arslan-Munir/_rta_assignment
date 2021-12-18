namespace RtaAssignment.Core.Entities
{
    public class PassportPhoto : Photo
    {
        public PassportPhoto(string url, string publicId)
        {
            Url = url;
            PublicId = publicId;
        }
    }
}