namespace lovedmemory.domain.Entities
{
    public class Tribute
    {
        public int Id { get; set; }
        public int ViewCount { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int Owner { get; set; }
        public string MainImageUrl { get; set; }
        public DateTime Edited { get; set; }
        public DateTime Created { get; set; }
        public DateTime RunDate { get; set; }
        public bool Active { get; set; }
    }
}
