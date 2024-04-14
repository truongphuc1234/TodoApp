using Microsoft.EntityFrameworkCore;

public class TaskService : ITaskService
{
    private AppDbContext db;

    public TaskService(AppDbContext db)
    {
        this.db = db;
    }

    public async Task CreateTask(TaskItem task)
    {
        db.Add(task);
        await db.SaveChangesAsync();
    }

    public async Task<List<TaskItem>> GetAllTasks()
    {
        return await db.Tasks
            .OrderBy(t => t.Id)
            .ToListAsync();
    }

    public async Task UpdateTask(TaskItem task)
    {
        var t = await db.Tasks.Where(x => x.Id == task.Id).FirstAsync();
        db.Entry(t).CurrentValues.SetValues(task);
        await db.SaveChangesAsync();
    }

    public async Task DeleteTask(int id)
    {
        db.Remove(id);
        await db.SaveChangesAsync();
    }

    public async Task<TaskItem> GetByIdAsync(int id)
    {
        return await db.Tasks.SingleAsync(x => x.Id == id);
    }
}
