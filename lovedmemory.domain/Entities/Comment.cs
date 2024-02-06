using System.ComponentModel.Design;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace lovedmemory.domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int TributeId { get; set; }
        public string Details { get; set; }
        public bool Visible { get; set; } = true;
        public DateTime DatePosted { get; set; }
        public List<Comment> Replies { get; set; }
        public Comment()
        {
            Replies = new List<Comment>();
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
        public virtual Tribute Tribute { get; set; }
    }
}
