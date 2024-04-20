using Microsoft.EntityFrameworkCore;

public class LabelService : ILabelService
{
    private AppDbContext db;

    public LabelService(AppDbContext db)
    {
        this.db = db;
    }

    public async Task CreateTask(Label label)
    {
        db.Add(label);
        await db.SaveChangesAsync();
    }

    public async Task<List<Label>> GetAllLabels()
    {
        return await db.Labels
            .OrderBy(t => t.Id)
            .ToListAsync();
    }

    public async Task UpdateTask(Label label)
    {
        var t = await db.Tasks.Where(x => x.Id == label.Id).FirstAsync();
        db.Entry(t).CurrentValues.SetValues(label);
        await db.SaveChangesAsync();
    }

    public async Task DeleteTask(int id)
    {
        db.Remove(id);
        await db.SaveChangesAsync();
    }

    public async Task<Label> GetByIdAsync(int id)
    {
        return await db.Labels.SingleAsync(x => x.Id == id);
    }

    public async Task<Label> FindByLabelName(string labelName)
    {
        return await db.Labels.SingleAsync(x => x.Description == labelName);
    }
}

