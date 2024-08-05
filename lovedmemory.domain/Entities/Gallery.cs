using System.ComponentModel.DataAnnotations;

namespace lovedmemory.domain.Entities
{
    public class Gallery
    {
        public int TributeId { get; set; }
        public string MediaUrl { get; set; }
        public bool Active { get; set; }
        public bool Approved { get; set; }
        public DateTimeOffset Added { get; set; } = DateTimeOffset.UtcNow;    
        public string MediaTitle { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public string UserId { get; set; }
        public virtual AppUser AddedBy { get; set; }
        public virtual Tribute Tribute { get; set; }

    }
}
