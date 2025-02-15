namespace lovedmemory.domain.Entities
{
    public class CoverPhoto
    {
        public int? MemorialId { get; set; }
        public int? CoverPhotoId { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public virtual Memorial Memorial { get; set; }    
    }
}
