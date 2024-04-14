using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;

public sealed class TaskShowCommand : AsyncCommand<TaskShowCommand.Settings>
{
    private ITaskService taskService;

    public TaskShowCommand(ITaskService service) : base()
    {
        this.taskService = service;
    }

    public sealed class Settings : CommandSettings
    {
    }

    public override async Task<int> ExecuteAsync([NotNull] CommandContext context, [NotNull] Settings settings)
    {
        var tasks = await this.taskService.GetAllTasks();
        var grid = new Grid();

        grid.AddColumn();
        grid.AddColumn();
        grid.AddColumn();
        grid.AddColumn();
        grid.AddColumn();
        grid.AddColumn();

        grid.AddRow(new Text[]{
    		new Text("Id", new Style(Color.Red, Color.Black)).Centered(),
    		new Text("Title", new Style(Color.Green, Color.Black)).Centered(),
    		new Text("Priority", new Style(Color.Blue, Color.Black)).Centered(),
    		new Text("Remind", new Style(Color.Aqua, Color.Black)).Centered(),
    		new Text("Is Repeat", new Style(Color.Teal, Color.Black)).Centered(),
    		new Text("Note", new Style(Color.Lime, Color.Black)).Centered(),
        });

        foreach (var task in tasks)
        {
            grid.AddRow(new Text[]{
                new Text(task.Id.ToString()).LeftJustified(),
                new Text(task.Title).Centered(),
                new Text(task.Priority.ToString()).Centered(),
                new Text(task.Remind.ToString()).Centered(),
                new Text(task.IsRepeat.ToString()).Centered(),
                new Text(task.Note.ToString()).Centered(),
            });
        }

        AnsiConsole.Write(grid);
        return 1;
    }
}


