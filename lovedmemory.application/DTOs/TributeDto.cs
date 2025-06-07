using lovedmemory.domain.Entities;

namespace lovedmemory.application.DTOs
{
    public class TributeDto
    {
        public int? Id { get; set; }
        public int? ViewCount { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Slug { get; set; }
        public string MainImageUrl { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset RunDate { get; set; }
        public bool? Active { get; set; }
        public IList<Comment> Comments { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
    }
    public class CreateTributeDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string TributeName { get; set; }
        public string? NickName { get; set; }
        public string? Slug { get; set; }
        public string MainImageUrl { get; set; }

    }
}
