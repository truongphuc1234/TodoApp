using Microsoft.EntityFrameworkCore;

public class TemplateService : ITemplateService
{
    private AppDbContext db;

    public TemplateService(AppDbContext db)
    {
        this.db = db;
    }

    public async Task CreateTask(WorkTemplate template)
    {
        db.Add(template);
        await db.SaveChangesAsync();
    }

    public async Task<List<WorkTemplate>> GetAllTemplates()
    {
        return await db.WorkTemplates
            .OrderBy(t => t.Id)
            .ToListAsync();
    }

    public async Task UpdateTask(WorkTemplate task)
    {
        var t = await db.WorkTemplates.Where(x => x.Id == task.Id).FirstAsync();
        db.Entry(t).CurrentValues.SetValues(task);
        await db.SaveChangesAsync();
    }

    public async Task DeleteTask(int id)
    {
        db.Remove(id);
        await db.SaveChangesAsync();
    }

    public async Task<WorkTemplate> GetByIdAsync(int id)
    {
        return await db.WorkTemplates.SingleAsync(x => x.Id == id);
    }
}

