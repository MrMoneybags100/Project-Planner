using Microsoft.EntityFrameworkCore;
using projectplanner.Models;

namespace projectplanner.Data
{
    // AppDbContext is the "bridge" between C# code and SQL Server
    // EF Core (Entity Framework) uses this class to translate your C# classes into database tables
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        // DbSet<T> represents a table in your SQL database
        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserGroupLink> UserGroupLinks { get; set; }
    }
}
