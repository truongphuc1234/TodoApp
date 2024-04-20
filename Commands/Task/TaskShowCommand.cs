using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;

public sealed class TaskShowCommand : AsyncCommand<TaskShowCommandSettings>
{
    private ITaskService taskService;
    private ITaskUIService uiService;

    public TaskShowCommand(ITaskService service, ITaskUIService uiService) : base()
    {
        this.taskService = service;
        this.uiService = uiService;
    }

    public override async Task<int> ExecuteAsync([NotNull] CommandContext context, [NotNull] TaskShowCommandSettings settings)
    {
        var tasks = await this.taskService.GetAllTasks();
        var grid = this.uiService.CreateTaskGrid(tasks);

        AnsiConsole.Write(grid);
        return 1;
    }
}


