using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RealTimeChat.API.Data
{
    public class ChatAppAuthDbContext : IdentityDbContext
    {
        public ChatAppAuthDbContext(DbContextOptions<ChatAppAuthDbContext> options) : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //}
    }
}
