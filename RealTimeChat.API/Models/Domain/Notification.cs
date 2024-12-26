namespace RealTimeChat.API.Models.Domain
{
    public class Notification
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
    }

}
