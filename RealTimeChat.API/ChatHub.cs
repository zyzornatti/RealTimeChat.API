using Microsoft.AspNetCore.SignalR;
//using RealTimeChat.API.Models.Domain;
//using RealTimeChat.API.Interfaces;
//using RealTimeChat.API.Services;

namespace RealTimeChat.API
{
    public sealed class ChatHub : Hub
    {
        // Send a message to all connected clients
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        // Send a message to a specific group (e.g., chat room)
        public async Task SendMessageToGroup(string groupName, string user, string message)
        {
            await Clients.Group(groupName).SendAsync("ReceiveMessage", user, message);
        }
        //public async Task JoinSpecificChatRoom(string username, string chatRoom)
        //{
        //    await Groups.AddToGroupAsync(Context.ConnectionId, chatRoom);
        //    await Clients.Group(chatRoom).SendAsync("ReceiveMessage", $"{username} has joined {Context.ConnectionId}-{chatRoom}");
        //}

        // Add the user to a group
        public async Task JoinGroup(string username, string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await SendMessageToGroup(groupName, username, $"{username} has joined {groupName}");
        }

        // Remove the user from a group
        public async Task LeaveGroup(string username, string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
            await SendMessageToGroup(groupName, username, $"{username} has left {groupName}");
        }

        //public async Task JoinRoom(string roomName, Guid roomId)
        //{
        //    await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        //    var messages = await _messageService.GetMessages(roomId);
        //    await Clients.Caller.SendAsync("ReceiveMessages", messages); // Send previous messages to the user
        //}

        //// Method to send a message to a room
        //public async Task SendMessage(string roomName, string messageContent)
        //{
        //    var userId = Context.UserIdentifier;
        //    var message = await _messageService.AddMessageToRoom(roomName, Guid.Parse(userId), messageContent);
        //    await Clients.Group(roomName).SendAsync("ReceiveMessage", message);
        //}

        // Method to leave a chat room
        //public async Task LeaveRoom(string roomName)
        //{
        //    await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        //}
    }
}
