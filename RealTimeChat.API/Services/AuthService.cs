using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealTimeChat.API.CustomExceptions;
using RealTimeChat.API.Data;
using RealTimeChat.API.Interfaces;
using RealTimeChat.API.Models.Domain;

namespace RealTimeChat.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<ApplicationUser?> LoginAsync(ApplicationUser user)
        {
            // Find user by email
            var existingUser = await _userManager.FindByEmailAsync(user.Email);
            if (existingUser == null) return null;

            // Verify password
            var result = await _userManager.CheckPasswordAsync(existingUser, user.PasswordHash);
            if (!result) return null;

            return existingUser;
        }

        public async Task<ApplicationUser?> RegisterAsync(ApplicationUser userDetails)
        {

            var isUserExist = await _userManager.FindByEmailAsync(userDetails.Email);
            if (isUserExist == null)
            {

                var user = new ApplicationUser
                {
                    UserName = userDetails.UserName,
                    Email = userDetails.Email,
                    DisplayName = userDetails.DisplayName,
                    ProfilePictureUrl = userDetails.ProfilePictureUrl,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, userDetails.PasswordHash);

                if (result.Succeeded)
                {
                    return user;
                }
                
            }
            throw new ResourceNotFoundException("An account with this email already exist!");
        }
    }
}
