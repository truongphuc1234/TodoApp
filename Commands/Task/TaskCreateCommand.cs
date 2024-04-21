using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;

public sealed class TaskCreateCommand : AsyncCommand<TaskCreateCommandSettings>
{
    private ITaskService taskService;
    private ITaskUIService uiService;

    public TaskCreateCommand(ITaskService service, ITaskUIService uiService)
        : base()
    {
        this.taskService = service;
        this.uiService = uiService;
    }

    public override async Task<int> ExecuteAsync(
        [NotNull] CommandContext context,
        [NotNull] TaskCreateCommandSettings settings
    )
    {
        var priority = (Priority)Enum.ToObject(typeof(Priority), settings.Priority);

        var task = new TaskItem
        {
            Title = settings.Title,
            Priority = priority,
            Note = settings.Note,
            Remind = Remind.None,
            IsRepeat = settings.IsRepeat,
        };

        if (
            !string.IsNullOrEmpty(settings.StartAt)
            && DateTime.TryParse(settings.StartAt, out var startAt)
        )
        {
            task.StartAt = startAt;
        }

        if (
            !string.IsNullOrEmpty(settings.EndAt)
            && DateTime.TryParse(settings.EndAt, out var endAt)
        )
        {
            task.EndAt = endAt;
        }

        var labels = new List<Label>();

        if (settings.Tags is not null)
        {
            foreach (var label in settings.Tags)
            {
                labels.Add(new Label { Name = label });
            }
        }

        task.Labels = labels;

        var createTask = await this.taskService.CreateTask(task);
        var grid = this.uiService.CreateTaskGrid(new TaskItem[] { createTask });
        AnsiConsole.Write(grid);
        return 1;
    }
}
