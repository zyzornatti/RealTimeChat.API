using RealTimeChat.API.Models.Domain;

namespace RealTimeChat.API.Interfaces
{
    public interface IAuthService
    {
        Task<ApplicationUser?> LoginAsync(ApplicationUser user);
        Task<ApplicationUser?> RegisterAsync(ApplicationUser userDetails);
    }
}
