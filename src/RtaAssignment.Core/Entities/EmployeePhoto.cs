using System.Linq;

namespace RtaAssignment.Core.Entities
{
    public class EmployeePhoto : Photo
    {
        public int EmployeeId { get; set; }

        public EmployeePhoto()
        { }

        public EmployeePhoto(int id, string url, string publicId)
        {
            EmployeeId = id;
            Url = url;
            PublicId = publicId;
        }
    }
}