public interface ITemplateService
{
    public Task<List<WorkTemplate>> GetAllTemplates();
    public Task CreateTask(WorkTemplate task);
    public Task UpdateTask(WorkTemplate task);
    public Task DeleteTask(int id);
    Task<WorkTemplate> GetByIdAsync(int id);
}


