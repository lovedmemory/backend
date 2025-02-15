namespace lovedmemory.domain.Entities
{
    public class Gallery
    {
        public int MemorialId { get; set; }
        public string MediaUrl { get; set; }
        public MediaType MediaType { get; set; }
        public bool Active { get; set; }
        public bool Approved { get; set; }
        public DateTimeOffset Added { get; set; } = DateTimeOffset.UtcNow;    
        public string MediaTitle { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public string UserId { get; set; }
        public virtual AppUser AddedBy { get; set; }
        public virtual Memorial Memorial { get; set; }

    }
    public enum MediaType
    {
        Image = 0,
        Video = 1
    }
}
