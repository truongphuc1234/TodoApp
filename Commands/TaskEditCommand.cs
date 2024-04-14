using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;

public sealed class TaskEditCommand : AsyncCommand<TaskEditCommand.Settings>
{
    private ITaskService taskService;

    public TaskEditCommand(ITaskService service) : base()
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
        var task = await this.taskService.GetByIdAsync(settings.Id);
        AnsiConsole.WriteLine("Edit task with:");
        var name = AnsiConsole.Prompt(
            new TextPrompt<string>("[green bold]Title[/]").DefaultValue(task.Title)
            );

        AnsiConsole.WriteLine("Edit task with:");
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
                .UseConverter(x => Constants.REMINDS.FirstOrDefault(l => l.Id == x)?.Description ?? string.Empty)
                );

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

        var updateTask = new TaskItem
        {
            Title = name,
            Priority = priority,
            Note = string.Empty,
            Remind = remind,
            IsRepeat = isRepeat
        };
        await this.taskService.UpdateTask(updateTask);
        return 1;
    }
}

