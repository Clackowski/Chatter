using Microsoft.EntityFrameworkCore;

public class MessagesDbContext : DbContext
{
    public DbSet<Message> Messages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=messages.db");
    }
}