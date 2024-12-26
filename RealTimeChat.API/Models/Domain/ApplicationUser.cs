using Microsoft.AspNetCore.Identity;

namespace RealTimeChat.API.Models.Domain
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string DisplayName { get; set; }
        public string ProfilePictureUrl { get; set; }
        public DateTime CreatedAt { get; set; } // Account creation date

        // Navigation properties
        public ICollection<Message> Messages { get; set; } // Messages sent by the user
        public ICollection<ChatRoomUser> ChatRooms { get; set; } // Chat rooms the user is part of
        public ICollection<UserConnection> UserConnections { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
