using RealTimeChat.API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace RealTimeChat.API.Models.DTO
{
    public class AddChatRoomRequestDto
    {
        [Required]
        public string RoomName { get; set; }
        public string? Description { get; set; }
  
    }
}
