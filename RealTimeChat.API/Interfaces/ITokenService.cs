using RealTimeChat.API.Models.Domain;

namespace RealTimeChat.API.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(ApplicationUser user);
    }
}
