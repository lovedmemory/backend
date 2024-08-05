using System.ComponentModel.DataAnnotations;

namespace lovedmemory.domain.Entities
{
    public class ExtraDetails
    {
        public int TributeId { get; set; }
        public string NickName { get; set; }
        public DateTimeOffset DateOfBirth{ get; set; }
        public DateTimeOffset DateOfDeath { get; set; }
        public string LifeStory { get; set; }
        public virtual Tribute Tribute { get; set; }
    }
}
