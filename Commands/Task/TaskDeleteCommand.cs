using System.Diagnostics.CodeAnalysis;
using Spectre.Console.Cli;

public sealed class TaskDeleteCommand : AsyncCommand<TaskDeleteCommandSettings>
{
    private ITaskService taskService;

    public TaskDeleteCommand(ITaskService service) : base()
    {
        this.taskService = service;
    }

    public override async Task<int> ExecuteAsync([NotNull] CommandContext context, [NotNull] TaskDeleteCommandSettings settings)
    {
        await this.taskService.DeleteTask(settings.Id);
        return 1;
    }
}


