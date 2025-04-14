using lovedmemory.domain.Entities;

namespace lovedmemory.application.DTOs
{
    public class CreateMemorialDto
    {
        public string? Title { get; set; }
        public string? Biography { get; set; }
        public string? PersonalPhrase { get; set; }
        public string? Description { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ImageUrl { get; set; }
        public string? Dob { get; set; }
        public string? Dod { get; set; }
        public char? Gender { get; set; } = 'U';
        public bool Privacy { get; set; }
        public DateTimeOffset? RunDate { get; set; }
        public bool Published { get; set; }
        public string? Slug { get; set; }
        public string? Email { get; set; }
        public DateOnly? CommemorationDate { get; set; }


    }
}
