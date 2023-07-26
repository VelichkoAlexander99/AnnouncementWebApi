namespace WebApi.DTOs.Incoming
{
    public class AnnouncementForUpdateDto
    {
        public required string Text { get; set; }
        public required Uri ImageUri { get; set; }
        public required int Rating { get; set; }
        public required DateTime Created { get; set; }
        public required DateTime Expity { get; set; }
    }
}
