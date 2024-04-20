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
            .OrderBy(t => t.Name)
            .ToListAsync();
    }

    public async Task<Label> GetByIdAsync(string name)
    {
        return await db.Labels.SingleAsync(x => x.Name == name);
    }

    public async Task<Label> FindByLabelName(string labelName)
    {
        return await db.Labels.SingleAsync(x => x.Name == labelName);
    }
}

