namespace RealTimeChat.API.Models.DTO
{
    public class ChatRoomDto
    {
        public Guid Id { get; set; }
        public string RoomName { get; set; }
        public string? Description { get; set; }
    }
}
