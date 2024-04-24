using Spectre.Console;
using Spectre.Console.Rendering;

public class TaskUIService : ITaskUIService
{
    public IRenderable CreateTaskGrid(IEnumerable<TaskItem> tasks)
    {
        var grid = new Grid();

        grid.AddColumn();
        grid.AddColumn();
        grid.AddColumn();
        grid.AddColumn();
        grid.AddColumn();
        grid.AddColumn();
        grid.AddColumn();
        grid.AddColumn();

        grid.AddRow(
            new Text[]
            {
                new Text("Id", new Style(Color.Red, Color.Black)).Centered(),
                new Text("Labels", new Style(Color.Purple3, Color.Black)).Centered(),
                new Text("Title", new Style(Color.Green, Color.Black)).Centered(),
                new Text("Priority", new Style(Color.Blue, Color.Black)).Centered(),
                new Text("Start At", new Style(Color.Purple3, Color.Black)).Centered(),
                new Text("End At", new Style(Color.Purple3, Color.Black)).Centered(),
                new Text("Note", new Style(Color.Lime, Color.Black)).Centered(),
                new Text("Status", new Style(Color.Lime, Color.Black)).Centered(),
            }
        );

        foreach (var task in tasks)
        {
            grid.AddRow(
                new Text[]
                {
                    new Text(task.Id.ToString()).LeftJustified(),
                    new Text(string.Join(" ", task.Labels.Select(x => x.Name))).Centered(),
                    new Text(task.Title).Centered(),
                    new Text(task.Priority.ToString()).Centered(),
                    new Text(task.StartAt?.ToString() ?? string.Empty).Centered(),
                    new Text(task.EndAt?.ToString() ?? string.Empty).Centered(),
                    new Text(task.Note.ToString()).Centered(),
                    new Text(task.Status.ToString()).Centered(),
                }
            );
        }
        return grid;
    }
}
