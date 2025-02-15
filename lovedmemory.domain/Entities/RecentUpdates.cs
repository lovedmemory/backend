namespace lovedmemory.domain.Entities
{
    public class RecentUpdates
    {
        public int MemorialId { get; set; }
        public string UpdateType { get; set; }
        public string UserId { get; set; }
        public bool IsPublic { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
    }
}
