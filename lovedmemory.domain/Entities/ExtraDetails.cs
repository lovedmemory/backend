using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lovedmemory.domain.Entities
{
    public class ExtraDetails
    {
        [Key]
        public int MemorialId { get; set; }
        public string? NickName { get; set; }
        public Relationship? Relationship { get; set; }
        public DateOnly? DateOfBirth{ get; set; }
        public DateOnly? DateOfDeath { get; set; }
        public DateOnly? CommemorationDate { get; set; }
        public string? BirthCountry { get; set; }
        public string? DeathCountry { get; set; }
        public string? LifeStory { get; set; }
        // Pet-specific fields
        public string? Species { get; set; }
        public string? Breed { get; set; }
        public string? Color { get; set; }
        public string? MicrochipNumber { get; set; }

    }
    public enum Relationship
    {
        Spouse = 0,
        Child = 1,
        Parent = 2,
        Sibling = 3,
        Grandparent = 4,
        Grandchild = 5,
        AuntUncle = 6,
        NieceNephew = 7,
        Cousin = 8,
        Friend = 9,
        Colleague = 10,
        Pet = 11,
        Other = 12
    }
}
