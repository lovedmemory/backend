namespace lovedmemory.domain.Entities
{
    public class LifeStory
    {
        public int MemorialId { get; set; }
        public string StorySection { get; set; }
        public string Story { get; set; }
        public virtual Memorial Memorial { get; set; }
    }
}
