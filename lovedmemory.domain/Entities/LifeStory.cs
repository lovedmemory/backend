namespace lovedmemory.domain.Entities
{
    public class LifeStory
    {
        public int TributeId { get; set; }
        public string StorySection { get; set; }
        public string Story { get; set; }
        public virtual Tribute Tribute { get; set; }
    }
}
