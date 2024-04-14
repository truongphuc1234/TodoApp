using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<TaskItem> Tasks { get; set; }
    public DbSet<Label> Labels { get; set; }
    public DbSet<WorkQueue> WorkQueues { get; set; }
    public DbSet<WorkTemplate> WorkTemplates { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}

