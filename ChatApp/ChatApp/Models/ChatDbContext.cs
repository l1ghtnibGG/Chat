using Microsoft.EntityFrameworkCore;

namespace ChatApp.Models
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options) :
        base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
