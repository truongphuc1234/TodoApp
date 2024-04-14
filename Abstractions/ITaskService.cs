public interface ITaskService
{
    public Task<List<TaskItem>> GetAllTasks();
    public Task CreateTask(TaskItem task);
    public Task UpdateTask(TaskItem task);
    public Task DeleteTask(int id);
    Task<TaskItem> GetByIdAsync(int id);
}

