namespace RealTimeChat.API.Models.Domain
{
    public class ChatRoom
    {
        public Guid Id { get; set; }
        public string RoomName { get; set; }
        public string? Description { get; set; }
        public Guid CreatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<ChatRoomUser> ChatRoomUsers { get; set; }
        public ICollection<Message> Messages { get; set; }

    }

}
