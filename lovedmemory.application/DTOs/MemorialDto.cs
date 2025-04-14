using lovedmemory.domain.Entities;

namespace lovedmemory.application.DTOs
{
    public class MemorialDto
    {
        public int? Id { get; set; }
        public int? ViewCount { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Biography { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Slug { get; set; }
        public DateOnly Dob { get; set; }
        public DateOnly Dod { get; set; }
        public string ImageUrl { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset RunDate { get; set; }
        public bool? Active { get; set; }
        public IList<Comment> Comments { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
        public string PersonalPhrase { get; set; }
        public bool Published { get; set; }
        public DateOnly? CommemorationDate { get; set; }


    }

}
