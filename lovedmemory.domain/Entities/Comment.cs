using lovedmemory.domain.Common;
using System.Text.Json.Serialization;

namespace lovedmemory.domain.Entities
{
    public class Comment : BaseAuditableEntity
    {
        public int Id { get; set; }
        public int MemorialId { get; set; }
        public int TreeLevel { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public CommentStatus Status { get; set; } = 0;
        public bool Edited { get; set; }
        public int? ParentCommentId { get; set; }
        [JsonIgnore]
        public virtual Memorial Memorial { get; set; }
        [JsonIgnore]
        public virtual Comment ParentComment { get; set; }
        public virtual ICollection<Comment> Replies { get; set; } = new List<Comment>();

        public Comment()
        {
            Replies = new List<Comment>();
        }
    }

    public enum CommentType
    {
        Comment = 0,
        Reply = 1
    }
    public enum CommentStatus
    {
        Pending = 0,
        Approved = 1,
        Rejected = 2,
        Deleted = 3
    }
}
