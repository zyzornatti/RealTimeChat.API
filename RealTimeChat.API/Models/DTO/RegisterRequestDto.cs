namespace RealTimeChat.API.Models.DTO
{
    public class RegisterRequestDto
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}
