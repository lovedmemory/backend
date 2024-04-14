namespace lovedmemory.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int TributeId { get; set; }
        public string Details { get; set; }
        public bool Visible { get; set; } = true;
        public DateTime DatePosted { get; set; }
        public bool Edited { get; set; }
        public DateTime DateEdited { get; set; }
        public int? ParentCommentId { get; set; }
        public virtual List<Comment> Replies { get; set; }

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
            //Console.WriteLine($"{indentation}Comment ID: {CommentId}");
            //Console.WriteLine($"{indentation}Text: {Text}");
            //Console.WriteLine($"{indentation}Date Posted: {DatePosted}");

            foreach (var reply in Replies)
            {
                reply.Display(level + 1);
            }
        }
    }
}
