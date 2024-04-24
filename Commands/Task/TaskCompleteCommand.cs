using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;

public sealed class TaskCompleteCommand : AsyncCommand<TaskCompleteCommandSettings>
{
    private ITaskService taskService;
    private ITaskUIService uiService;

    public TaskCompleteCommand(ITaskService service, ITaskUIService uiService)
        : base()
    {
        this.taskService = service;
        this.uiService = uiService;
    }

    public override async Task<int> ExecuteAsync(
        [NotNull] CommandContext context,
        [NotNull] TaskCompleteCommandSettings settings
    )
    {
        var task = await this.taskService.GetByIdAsync(settings.Id);
        task.Status = Status.Complete;
        await this.taskService.UpdateTask(task);
        var grid = this.uiService.CreateTaskGrid(new TaskItem[] { task });
        AnsiConsole.Write(grid);
        return 1;
    }
}
