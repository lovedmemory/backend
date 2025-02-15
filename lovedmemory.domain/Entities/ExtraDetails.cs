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
        public string? BirthCountry { get; set; }
        public string? DeathCountry { get; set; }
        public string? LifeStory { get; set; }

    }
    public enum Relationship
    {
        Spouse = 0,
        Child = 1
    }
}
