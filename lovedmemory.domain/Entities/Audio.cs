namespace lovedmemory.domain.Entities
{
    public class Audio
    {
        public int Id { get; set; }
        public int MemorialId { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Tags { get; set; }
        public required string UserId { get; set; }
        public virtual required AppUser AddedBy { get; set; }
        public virtual required Memorial Memorial { get; set; }
        public DateTimeOffset Added { get; set; } = DateTimeOffset.UtcNow;
        public required string Url { get; set; }
    }
}
