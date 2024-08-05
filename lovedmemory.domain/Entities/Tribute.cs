using lovedmemory.domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace lovedmemory.domain.Entities
{
    public class Tribute : BaseAuditableEntity
    {
        public int Id { get; set; }
        public int ViewCount { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherNames { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string Template { get; set; }
        public string MainImageUrl { get; set; }
        public DateTimeOffset Edited { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset RunDate { get; set; }
        public bool Published { get; set; } = true;
        public bool Active { get; set; }
        public virtual IList<Comment> Comments { get; set; } = [];
        public virtual ExtraDetails ExtraDetails { get; set; }
        public virtual IList<Gallery> Gallery { get; set; } = [];
        [NotMapped]
        public string FullName
        {
            get
            {
               return $"{FirstName} {OtherNames} {LastName}".Trim();
            }
        }
    }
}
