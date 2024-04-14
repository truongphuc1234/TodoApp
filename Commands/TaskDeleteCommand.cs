using System.Diagnostics.CodeAnalysis;
using Spectre.Console.Cli;

public sealed class TaskDeleteCommand : AsyncCommand<TaskDeleteCommand.Settings>
{
    private ITaskService taskService;

    public TaskDeleteCommand(ITaskService service) : base()
    {
        this.taskService = service;
    }

    public sealed class Settings : CommandSettings
    {
        [CommandArgument(0, "[id]")]
        public int Id { get; set; }
    }

    public override async Task<int> ExecuteAsync([NotNull] CommandContext context, [NotNull] Settings settings)
    {
        await this.taskService.DeleteTask(settings.Id);
        return 1;
    }
}


