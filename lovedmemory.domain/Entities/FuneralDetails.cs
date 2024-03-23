namespace lovedmemory.domain.Entities
{
    public class FuneralDetails
    {
        public int Id { get; set; }
        public int TributeId { get; set; }
        public DateTime FuneralDate { get; set; }
        public string FuneralLocation { get; set; }
        public string FuneralDetails { get; set; }
    }
}
