using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<TaskItem> Tasks { get; set; }
    public DbSet<Label> Labels { get; set; }
    public DbSet<WorkQueue> WorkQueues { get; set; }
    public DbSet<WorkTemplate> WorkTemplates { get; set; }

    public AppDbContext () {}

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {

        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        var dbPath = System.IO.Path.Join(path, "blogging.db");
        options.UseSqlite($"Data Source={dbPath}");
    }
}

