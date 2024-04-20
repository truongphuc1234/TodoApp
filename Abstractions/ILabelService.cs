public interface ILabelService
{
    public Task<List<Label>> GetAllLabels();
    public Task CreateTask(Label label);
    Task<Label> GetByIdAsync(string name);
    public Task<Label> FindByLabelName(string labelName);
}


