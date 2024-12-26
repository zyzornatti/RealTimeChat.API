using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealTimeChat.API.Models.Domain;

namespace RealTimeChat.API.Data
{
    public class ChatAppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<ChatRoomUser> ChatRoomUsers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserConnection> UserConnections { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public ChatAppDbContext(DbContextOptions<ChatAppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Many-to-Many: ChatRoom and ApplicationUser
            modelBuilder.Entity<ChatRoomUser>()
                .HasKey(cu => new { cu.ChatRoomId, cu.UserId });

            modelBuilder.Entity<ChatRoomUser>()
                .HasOne(cu => cu.ChatRoom)
                .WithMany(c => c.ChatRoomUsers)
                .HasForeignKey(cu => cu.ChatRoomId);

            modelBuilder.Entity<ChatRoomUser>()
                .HasOne(cu => cu.User)
                .WithMany(u => u.ChatRooms) // Add ICollection<ChatRoomUser> to ApplicationUser
                .HasForeignKey(cu => cu.UserId);

            // One-to-Many: ChatRoom and Message
            modelBuilder.Entity<Message>()
                .HasOne(m => m.ChatRoom)
                .WithMany(c => c.Messages)
                .HasForeignKey(m => m.ChatRoomId);

            // One-to-Many: ApplicationUser and Message
            modelBuilder.Entity<Message>()
                .HasOne(m => m.User)
                .WithMany(u => u.Messages) 
                .HasForeignKey(m => m.UserId);

            // One-to-Many: ApplicationUser and USerConnection
            modelBuilder.Entity<UserConnection>()
                .HasOne(m => m.User)
                .WithMany(u => u.UserConnections)
                .HasForeignKey(m => m.UserId);

            // One-to-Many: ApplicationUser and Notification
            modelBuilder.Entity<Notification>()
                .HasOne(m => m.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(m => m.UserId);

        }
    }

}
