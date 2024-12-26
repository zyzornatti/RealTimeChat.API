namespace RealTimeChat.API.Models.Domain
{
    public class Message
    {
        public Guid Id { get; set; } // Primary Key
        public string Content { get; set; } // The actual message content
        public DateTime SentAt { get; set; } // Timestamp of when the message was sent
        public bool IsRead { get; set; } // Whether the message has been read by the recipient(s)

        // Foreign Keys
        public Guid UserId { get; set; } // Sender's User ID
        public Guid ChatRoomId { get; set; } // The ChatRoom where the message was sent

        // Navigation properties
        public ApplicationUser User { get; set; } // The sender
        public ChatRoom ChatRoom { get; set; } // The chat room where the message belongs
    }

}
