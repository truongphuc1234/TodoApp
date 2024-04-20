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
        AnsiConsole.WriteLine("Create new template with:");
        var name = AnsiConsole.Ask<string>("[green bold]Name[/]");
        var listPeriods = new List<WorkPeriod>();

        
        AnsiConsole.WriteLine("Add new period");
        while (true)
        {
            var startAtHour = AnsiConsole.Prompt(
                new TextPrompt<int>("Start at (hour):")
                .PromptStyle("green")
                .ValidationErrorMessage("[red]That's not a valid hour[/]")
                .Validate(hour =>
                    {
                        return hour switch
                        {
                            <= 0 => ValidationResult.Error("[red]Hour must be larger than 0[/]"),
                            >= 24 => ValidationResult.Error("[red]Hour must less than 24[/]"),
                            _ => ValidationResult.Success(),
                        };
            }));
            var startAtMinute = AnsiConsole.Prompt(
                new TextPrompt<int>("Start at (minute):")
                .PromptStyle("green")
                .ValidationErrorMessage("[red]That's not a valid minute[/]")
                .Validate(hour =>
                    {
                        return hour switch
                        {
                            <= 0 => ValidationResult.Error("[red]Minute must be larger than 0[/]"),
                            >= 60 => ValidationResult.Error("[red]Minute must less than 24[/]"),
                            _ => ValidationResult.Success(),
                        };
            }));
            var endAtHour = AnsiConsole.Prompt(
                new TextPrompt<int>("End at (hour):")
                .PromptStyle("green")
                .ValidationErrorMessage("[red]That's not a valid age[/]")
                .Validate(hour =>
                    {
                        return hour switch
                        {
                            <= 0 => ValidationResult.Error("[red]Hour must be larger than 0[/]"),
                            >= 24 => ValidationResult.Error("[red]Hour must less than 24[/]"),
                            _ => ValidationResult.Success(),
                        };
            }));

            var endAtMinute = AnsiConsole.Prompt(
                new TextPrompt<int>("End at (minute):")
                .PromptStyle("green")
                .ValidationErrorMessage("[red]That's not a valid minute[/]")
                .Validate(hour =>
                    {
                        return hour switch
                        {
                            <= 0 => ValidationResult.Error("[red]Minute must be larger than 0[/]"),
                            >= 60 => ValidationResult.Error("[red]Minute must less than 24[/]"),
                            _ => ValidationResult.Success(),
                        };
            }));

            var addPeriod = AnsiConsole.Confirm("[green bold]Add new period ?:[/]");
            if (!addPeriod)
            {
                break;
            }
        }

        var task = new TaskItem
        {
            Title = name,
            Priority = priority,
            Note = string.Empty,
            Remind = remind,
            IsRepeat = isRepeat
        };
        await this.taskService.CreateTask(task);
        return 1;
    }
}


