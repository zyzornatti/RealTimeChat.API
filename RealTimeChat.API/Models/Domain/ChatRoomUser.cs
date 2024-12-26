namespace RealTimeChat.API.Models.Domain
{
    public class ChatRoomUser
    {
        public Guid UserId { get; set; } // Foreign Key to ApplicationUser
        public Guid ChatRoomId { get; set; } // Foreign Key to ChatRoom

        // Navigation properties
        public ApplicationUser User { get; set; }
        public ChatRoom ChatRoom { get; set; }
    }

}
