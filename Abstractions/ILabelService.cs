public interface ILabelService
{
    public Task<List<Label>> GetAllLabels();
    public Task CreateTask(Label label);
    public Task UpdateTask(Label label);
    public Task DeleteTask(int id);
    Task<Label> GetByIdAsync(int id);
    public Task<Label> FindByLabelName(string labelName);
}


