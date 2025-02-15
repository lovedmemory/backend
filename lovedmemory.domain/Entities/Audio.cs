namespace lovedmemory.domain.Entities
{
    public class Audio
    {
        public int Id { get; set; }
        public int MemorialId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public string UserId { get; set; }
        public virtual AppUser AddedBy { get; set; }
        public virtual Memorial Memorial { get; set; }
        public DateTimeOffset Added { get; set; } = DateTimeOffset.UtcNow;

        public string Url { get; set; }
    }
}
