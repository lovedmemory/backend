using lovedmemory.domain.Common;

namespace lovedmemory.domain.Entities
{
    public class Tribute : BaseAuditableEntity
    {
        public int Id { get; set; }
        public int ViewCount { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Slug { get; set; }
        public string MainImageUrl { get; set; }
        public DateTimeOffset Edited { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset RunDate { get; set; }
        public bool Active { get; set; }
        public virtual IList<Comment> Comments { get; set; } = new List<Comment>();
    }
}
