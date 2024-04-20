using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;

public sealed class TaskCreateCommand : AsyncCommand<TaskCreateCommandSettings>
{
    private ITaskService taskService;

    public TaskCreateCommand(ITaskService service) : base()
    {
        this.taskService = service;
    }

    public sealed class Settings : CommandSettings
    {
    }

    public override async Task<int> ExecuteAsync([NotNull] CommandContext context, [NotNull] TaskCreateCommandSettings settings)
    {
        AnsiConsole.WriteLine("Create new task with:");
        var name = AnsiConsole.Ask<string>("[green bold]Title[/]");

        var remind = AnsiConsole.Prompt(
            new SelectionPrompt<Remind>()
                .Title("Remind")
                .AddChoices(new[] {
                    Remind.None,
                    Remind.OnTime,
                    Remind.FiveMinute,
                    Remind.TenMinute,
                    Remind.FifteenMinute,
                    Remind.ThirtyMinute,
                    Remind.Hour,
                    Remind.Day
                })
                .UseConverter(x => Constants.REMINDS.FirstOrDefault(l => l.Id == x)?.Description ?? string.Empty));

        var priority = AnsiConsole.Prompt(
            new SelectionPrompt<Priority>()
                .Title("Priority")
                .AddChoices(new[] {
                    Priority.None,
                    Priority.LowPriority,
                    Priority.MediumPriority,
                    Priority.HighPriority,
                })
                .UseConverter(x => Constants.PRIORITIES.FirstOrDefault(l => l.Id == x)?.Description ?? string.Empty));

        var isRepeat = AnsiConsole.Confirm("Repeat");

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

