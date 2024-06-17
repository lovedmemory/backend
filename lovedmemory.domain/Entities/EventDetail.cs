namespace lovedmemory.domain.Entities
{
    public class EventDetail
    {
        public int Id { get; set; }
        public int TributeId { get; set; }
        public DateTimeOffset EventDate { get; set; }
        public string EventLocation { get; set; }
        public string Details { get; set; }
    }
}
