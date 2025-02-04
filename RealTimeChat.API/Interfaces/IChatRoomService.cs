using RealTimeChat.API.Models.Domain;
//using RealTimeChat.API.Models.DTO;

namespace RealTimeChat.API.Interfaces
{
    public interface IChatRoomService
    {
        Task<ChatRoom> CreateRoom(ChatRoom chatRoom);
        Task<IEnumerable<ChatRoom>> GetAllRooms();
        Task<IEnumerable<ChatRoom>> GetAllUserRooms(Guid userId);
        Task<ChatRoom?> GetRoomDetails(Guid Id);
        //Task<ChatRoom?> UpdateRoom(Guid roomId);
        Task<ChatRoom?> DeleteRoom(Guid roomId);
        //Task<ChatRoom> JoinRoom(Guid roomId, Guid userId);
        //Task<ChatRoom> LeaveRoom(Guid roomId, Guid userId);

    }
}
