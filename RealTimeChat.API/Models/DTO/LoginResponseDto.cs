using RealTimeChat.API.Models.Domain;

namespace RealTimeChat.API.Models.DTO
{
    public class LoginResponseDto
    {
        public string JwtToken { get; set; }
        public UserDto Profile { get; set; }
    }
}
