using Microsoft.EntityFrameworkCore;
namespace Star.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User.User> Users { get; set; }
}