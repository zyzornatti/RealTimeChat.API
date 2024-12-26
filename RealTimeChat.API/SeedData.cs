using Microsoft.AspNetCore.Identity;
using RealTimeChat.API.Data;
using RealTimeChat.API.Models.Domain;
using System.Threading;

namespace RealTimeChat.API
{
    public class SeedData
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ChatAppDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Ensure database is created
            context.Database.EnsureCreated();

            // Seed Users
            if (!context.Users.Any())
            {
                var user1 = new ApplicationUser
                {
                    UserName = "zyzornatti",
                    Email = "zyzornatti@chatapp.com",
                    DisplayName = "Zyzor Natti",
                    ProfilePictureUrl = "https://example.com/john.jpg",
                    EmailConfirmed = true
                };

                var user2 = new ApplicationUser
                {
                    UserName = "tobi",
                    Email = "tobiloba@chatapp.com",
                    DisplayName = "Tobi Loba",
                    ProfilePictureUrl = "https://example.com/jane.jpg",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(user1, "Password123!");
                await userManager.CreateAsync(user2, "Password123!");
            }

            // Seed Chat Rooms
            if (!context.ChatRooms.Any())
            {
                context.ChatRooms.AddRange(
                    new ChatRoom
                    {
                        Id = Guid.Parse("4ea6e6ec-35e2-433a-b909-406976792e71"),
                        RoomName = "General Chat",
                        Description = "A room for general discussions",
                        CreatedByUserId = context.Users.First().Id,
                        CreatedAt = DateTime.UtcNow
                    },
                    new ChatRoom
                    {
                        Id = Guid.Parse("3935a103-fd0a-44c3-8192-75b162768039"),
                        RoomName = "Tech Chat",
                        Description = "Discuss the latest in tech",
                        CreatedByUserId = context.Users.Skip(1).First().Id,
                        CreatedAt = DateTime.UtcNow
                    }
                );
                await context.SaveChangesAsync();
            }

            // Seed Messages
            if (!context.Messages.Any())
            {
                var generalChatId = context.ChatRooms.First(c => c.RoomName == "General Chat").Id;

                context.Messages.AddRange(
                    new Message
                    {
                        Id = Guid.Parse("d77dee7c-ce85-4b11-b075-df3bcc29a23a"),
                        Content = "Welcome to General Chat!",
                        SentAt = DateTime.UtcNow,
                        IsRead = false,
                        UserId = context.Users.First().Id,
                        ChatRoomId = generalChatId
                    },
                    new Message
                    {
                        Id = Guid.Parse("61f21745-8e9b-4820-835b-6d8f493ffe81"),
                        Content = "Hello, everyone!",
                        SentAt = DateTime.UtcNow,
                        IsRead = false,
                        UserId = context.Users.Skip(1).First().Id,
                        ChatRoomId = generalChatId
                    }
                );
                await context.SaveChangesAsync();
            }
        }
    }

}
