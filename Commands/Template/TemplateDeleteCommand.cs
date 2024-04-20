using System.Diagnostics.CodeAnalysis;
using Spectre.Console.Cli;

public sealed class TemplateDeleteCommand : AsyncCommand<TemplateDeleteCommandSettings>
{
    private ITaskService taskService;

    public TemplateDeleteCommand(ITaskService service) : base()
    {
        this.taskService = service;
    }

    public sealed class Settings : CommandSettings
    {
        [CommandArgument(0, "[id]")]
        public int Id { get; set; }
    }

    public override async Task<int> ExecuteAsync([NotNull] CommandContext context, [NotNull] TemplateDeleteCommandSettings settings)
    {
        await this.taskService.DeleteTask(settings.Id);
        return 1;
    }
}



