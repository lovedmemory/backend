namespace lovedmemory.domain.Entities
{
    public class ExtraDetails
    {
        public int TributeId { get; set; }
        public string NickName { get; set; }
        public Relationship Relationship { get; set; }
        public DateTimeOffset DateOfBirth{ get; set; }
        public DateTimeOffset DateOfDeath { get; set; }
        public string? BirthCountry { get; set; }

        public string DeathCountry { get; set; }
        public string LifeStory { get; set; }
    }
    public enum Relationship
    {
        Spouse = 0,
        Child = 1
    }
}
