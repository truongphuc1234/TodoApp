using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;

public sealed class TemplateCreateCommand : AsyncCommand<TemplateCreateCommandSettings>
{
    private ITemplateService taskService;

    public TemplateCreateCommand(ITemplateService service) : base()
    {
        this.taskService = service;
    }

    public sealed class Settings : CommandSettings
    {
    }

    public override async Task<int> ExecuteAsync([NotNull] CommandContext context, [NotNull] TemplateCreateCommandSettings settings)
    {
        return 1;
    }
}


