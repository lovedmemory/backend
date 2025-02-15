using lovedmemory.domain.Common;

namespace lovedmemory.domain.Entities
{
    public class Comment : BaseAuditableEntity
    {
        public int Id { get; set; }
        public int MemorialId { get; set; }
        public int TreeLevel { get; set; }
        public string Details { get; set; }
        public bool Visible { get; set; } = true;
        public bool Edited { get; set; }
        public int? ParentCommentId { get; set; }
        public virtual IList<Comment> Replies { get; set; } = [];

        public Comment()
        {
            Replies = [];
        }   
    }
}
