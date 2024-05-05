namespace lovedmemory.application.DTOs
{
    public class TributeDto
    {
        public int? Id { get; set; }
        public int? ViewCount { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Slug { get; set; }
        public string MainImageUrl { get; set; }
        public DateTime RunDate { get; set; }
        public bool? Active { get; set; }
    }
}
