using lovedmemory.domain.Common;

namespace lovedmemory.domain.Entities
{
    public class Comment : BaseAuditableEntity
    {
        public int Id { get; set; }
        public int TributeId { get; set; }
        public string Details { get; set; }
        public bool Visible { get; set; } = true;
        public bool Edited { get; set; }
        public int? ParentCommentId { get; set; }
        public virtual IList<Comment> Replies { get; set; }=new List<Comment>();

        public Comment()
        {
            Replies = [];
        }

        public void AddReply(Comment reply)
        {
            Replies.Add(reply);
        }
        public void Display(int level = 0)
        {
            string indentation = new string(' ', level * 2);

            foreach (var reply in Replies)
            {
                reply.Display(level + 1);
            }
        }
    }
}
