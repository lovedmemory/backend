using lovedmemory.domain.Common;

namespace lovedmemory.domain.Entities
{
    public class Memorial : BaseAuditableEntity
    {
        public int Id { get; set; }
        public int ViewCount { get; set; }
        public string Title { get; set; }
        public string PersonalPhrase { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string? OtherNames { get; set; }
        public string? Biography { get; set; }
        public char Gender { get; set; }
        public MemorialType MemorialType { get; set; }
        public string Slug { get; set; }
        public string Template { get; set; }
        public string? MainImageUrl { get; set; }
        public DateTimeOffset? Edited { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset RunDate { get; set; } = DateTimeOffset.UtcNow;
        public bool Published { get; set; } = true;
        public bool Active { get; set; } = true;
        public bool IsPrivate { get; set; }
        public CoverPhoto? CoverPhoto { get; set; }
        public virtual IList<Comment> Comments { get; set; } = [];
        public virtual ExtraDetails ExtraDetails { get; set; }
        public virtual IList<Gallery> Gallery { get; set; } = [];
        public virtual IList<Audio>? Audios { get; set; } = [];
        public virtual LifeStory? LifeStory { get; set; }


    }

    public enum MemorialType
    {
        Person,
        Pet
    }
    public class MemorialBuilder 
    {
        private Memorial _memorial = new Memorial();

        public MemorialBuilder WithBasicInfo(string title, string personalPhrase, string firstName, string lastName, string description, char gender, string slug, string template)
        {
            _memorial.Title = title;
            _memorial.PersonalPhrase = personalPhrase;
            _memorial.FirstName = firstName;
            _memorial.LastName = lastName;
            _memorial.Description = description;
            _memorial.Gender = gender;
            _memorial.Slug = slug;
            _memorial.Template = template;       
           
            return this;
        }

        public MemorialBuilder WithInitialStatus(int viewCount, DateTimeOffset created, DateTimeOffset edited, DateTimeOffset runDate, bool published, bool active, bool isPrivate)
        {
            _memorial.ViewCount = 0;
            _memorial.Created = DateTimeOffset.UtcNow;
            _memorial.Edited = null;
            _memorial.RunDate = runDate;
            _memorial.Published = published;
            _memorial.Active = active;
            _memorial.IsPrivate = isPrivate;
            return this;
        }
        public MemorialBuilder WithExtraDetails(string otherNames, string biography)
        {
            _memorial.OtherNames = otherNames;
            _memorial.Biography = biography;
            return this;
        }
        public MemorialBuilder WithGallery(string mainImageUrl, IList<Gallery> gallery)
        {
            _memorial.MainImageUrl = mainImageUrl;
            _memorial.Gallery = gallery;

            return this;
        }
        public Memorial Build()
        {
            return _memorial;
        }
    }
}
