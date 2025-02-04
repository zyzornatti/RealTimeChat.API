using Microsoft.EntityFrameworkCore;
using RealTimeChat.API.Data;
using RealTimeChat.API.Interfaces;
using RealTimeChat.API.Models.Domain;
using System;

namespace RealTimeChat.API.Services
{
    public class ChatRoomService : IChatRoomService
    {
        private readonly ChatAppDbContext _context;

        public ChatRoomService(ChatAppDbContext context)
        {
            _context = context;
        }

        public async Task<ChatRoom> CreateRoom(ChatRoom chatRoom)
        {
            //var room = new ChatRoom
            //{
            //    RoomName = roomName                
            //};

            _context.ChatRooms.Add(chatRoom);
            await _context.SaveChangesAsync();

            var roomUser = new ChatRoomUser
            {
                ChatRoomId = chatRoom.Id,
                UserId = chatRoom.CreatedByUserId
            };

            _context.ChatRoomUsers.Add(roomUser);
            await _context.SaveChangesAsync();

            return chatRoom;
        }

        public async Task<ChatRoom?> DeleteRoom(Guid roomId)
        {
            var room = await _context.ChatRooms.FirstOrDefaultAsync(x => x.Id == roomId);
            var roomUser = await _context.ChatRoomUsers
                .Include(m => m.User)
                .FirstOrDefaultAsync(x => x.ChatRoomId == roomId);

            if (room == null && roomUser == null)
            {
                return null;
            }
            _context.ChatRooms.Remove(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<IEnumerable<ChatRoom>> GetAllRooms()
        {
            var rooms = await _context.ChatRooms.ToListAsync();
            return rooms;
        }

        public async Task<IEnumerable<ChatRoom>> GetAllUserRooms(Guid userId)
        {
            var rooms = await _context.ChatRooms.Where(r => r.CreatedByUserId == userId).ToListAsync();
            return rooms;
        }

        public async Task<ChatRoom?> GetRoomDetails(Guid Id)
        {
            var room = await _context.ChatRooms.Where(r => r.Id == Id).FirstOrDefaultAsync();
            if (room == null) return null;

            return room;
        }

        //public Task<ChatRoom> JoinRoom(Guid roomId, Guid userId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ChatRoom> LeaveRoom(Guid roomId, Guid userId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<ChatRoom?> UpdateRoom(Guid userId)
        //{
        //    throw new NotImplementedException();
        //}
    }

}
