namespace ApplicationService.Domain
{
    public class Application
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int JobId { get; set; }
        public StatusType Status { get; set; }
    }

    public enum StatusType
    {
        Unknown
    }
}
