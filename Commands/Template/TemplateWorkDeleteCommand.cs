using System.Diagnostics.CodeAnalysis;
using Spectre.Console.Cli;

public sealed class TemplateWorkDeleteCommand : AsyncCommand<TemplateWorkDeleteCommandSettings>
{
    private ITaskService taskService;

    public TemplateWorkDeleteCommand(ITaskService service) : base()
    {
        this.taskService = service;
    }

    public sealed class Settings : CommandSettings
    {
        [CommandArgument(0, "[id]")]
        public int Id { get; set; }
    }

    public override async Task<int> ExecuteAsync([NotNull] CommandContext context, [NotNull] TemplateWorkDeleteCommandSettings settings)
    {
        await this.taskService.DeleteTask(settings.Id);
        return 1;
    }
}



