namespace lovedmemory.application.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int TributeId { get; set; }
        public string Details { get; set; }
        public int? ParentCommentId { get; set; }
    }
}
