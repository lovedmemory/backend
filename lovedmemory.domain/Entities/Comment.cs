using lovedmemory.domain.Common;
using System.Text.Json.Serialization;

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
}
