using Microsoft.EntityFrameworkCore;
using RealTimeChat.API.Data;
using RealTimeChat.API.Interfaces;
using RealTimeChat.API.Models.Domain;

namespace RealTimeChat.API.Services
{
    public class MessageService : IMessageService
    {
        private readonly ChatAppDbContext _context;

        public MessageService(ChatAppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<Message> AddMessageToRoom(string roomName, Guid userId, string messageContent)
        {
            var room = await _context.ChatRooms
                .Include(r => r.Messages)
                .FirstOrDefaultAsync(r => r.RoomName == roomName);

            if (room == null) throw new Exception("Chat room not found");

            var message = new Message
            {
                Content = messageContent,
                SentAt = DateTime.UtcNow,
                UserId = userId,
                ChatRoomId = room.Id
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return message;
        }

        public async Task<Message?> GetMessage(Guid msgId)
        {
            var message = await _context.Messages                
                .Include(m => m.User)
                .FirstOrDefaultAsync(r => r.Id == msgId);
            return message ?? null;
        }

        public async Task<IEnumerable<Message>> GetMessages(Guid roomId)
        {
            var room = await _context.ChatRooms
                .Include(r => r.Messages)
                .ThenInclude(m => m.User)
                .FirstOrDefaultAsync(r => r.Id == roomId);

            return room?.Messages.OrderBy(m => m.SentAt) ?? Enumerable.Empty<Message>();
        }
    }
}
