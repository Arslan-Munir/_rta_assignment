namespace RtaAssignment.Core.Entities
{
    public abstract class Photo : Entity
    {
        public string Url { get; set; }
        public string PublicId { get; set; }
    }
}