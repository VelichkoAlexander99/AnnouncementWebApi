namespace WebApi.DTOs.Incoming
{
    public class AnnouncementForCreationDto
    {
        public required Guid UserId { get; set; }
        public required string Text { get; set; }
        public required Uri ImageUri { get; set; }
        public required int Rating { get; set; }
        public required DateTime Expity { get; set; }
    }
}
