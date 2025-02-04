using RealTimeChat.API.Models.Domain;

namespace RealTimeChat.API.Interfaces
{
    public interface IMessageService
    {
        Task<Message> AddMessageToRoom(string roomName, Guid userId, string messageContent);
        Task<IEnumerable<Message>> GetMessages(Guid roomId);
        Task<Message> GetMessage(Guid msgId);
        //Task<Message> UpdateMessage(Guid msgId, Guid userId);
        //Task<Message> DeleteMessage(Guid msgId, Guid userId);
    }
}
