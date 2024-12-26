namespace RealTimeChat.API.Models.Domain
{
    public class UserConnection
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string ConnectionId { get; set; } // SignalR Connection ID
        public DateTime ConnectedAt { get; set; }
        public DateTime? DisconnectedAt { get; set; }
    }

}
