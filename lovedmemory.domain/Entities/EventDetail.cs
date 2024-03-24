namespace lovedmemory.Domain.Entities
{
    public class EventDetail
    {
        public int Id { get; set; }
        public int TributeId { get; set; }
        public DateTime EventDate { get; set; }
        public string EventLocation { get; set; }
        public string Details { get; set; }
    }
}
