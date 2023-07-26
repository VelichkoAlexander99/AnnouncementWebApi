namespace WebApi.DTOs.Incoming
{
    public class UserForCreationOrUpdateDto
    {
        public required string Name { get; set; }
        public required bool IsAdmin { get; set; }
    }
}
