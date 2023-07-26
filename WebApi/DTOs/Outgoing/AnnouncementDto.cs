namespace WebApi.DTOs.Outgoing
{
    public class AnnouncementDto
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public Guid UserId { get; set; }
        public string? Text { get; set; }
        public Uri? ImageUri { get; set; }
        public int Rating { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expity { get; set; }
    }
}
