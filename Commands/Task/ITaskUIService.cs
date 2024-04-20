using Spectre.Console.Rendering;

public interface ITaskUIService
{
    IRenderable CreateTaskGrid(IEnumerable<TaskItem> tasks);
}
