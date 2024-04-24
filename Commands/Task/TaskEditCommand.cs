using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;

public sealed class TaskEditCommand : AsyncCommand<TaskEditCommandSettings>
{
    private ITaskService taskService;
    private ITaskUIService uiService;

    public TaskEditCommand(ITaskService service, ITaskUIService uiService)
        : base()
    {
        this.taskService = service;
        this.uiService = uiService;
    }

    public override async Task<int> ExecuteAsync(
        [NotNull] CommandContext context,
        [NotNull] TaskEditCommandSettings settings
    )
    {
        var task = await this.taskService.GetByIdAsync(settings.Id);

        if (settings.Name is not null)
        {
            task.Title = settings.Name;
        }

        if (settings.Priority is not null)
        {
            task.Priority = (Priority)Enum.ToObject(typeof(Priority), settings.Priority);
        }

        var labels = new List<Label>();

        if (settings.Tags is not null)
        {
            if (settings.Tags is not null)
            {
                foreach (var label in settings.Tags)
                {
                    labels.Add(new Label { Name = label });
                }
            }
        }
        if (settings.EndAt is not null)
        {
            if (
                !string.IsNullOrEmpty(settings.EndAt)
                && DateTime.TryParse(settings.EndAt, out var endAt)
            )
            {
                task.EndAt = endAt;
            }
        }

        if (settings.StartAt is not null)
        {
            if (
                !string.IsNullOrEmpty(settings.StartAt)
                && DateTime.TryParse(settings.StartAt, out var startAt)
            )
            {
                task.StartAt = startAt;
            }
        }

        if (settings.Note is not null)
        {
            task.Note = settings.Note;
        }

        if (settings.IsRepeat is not null)
        {
            task.IsRepeat = settings.IsRepeat.Value;
        }
        await this.taskService.UpdateTask(task);
        var grid = this.uiService.CreateTaskGrid(new TaskItem[] { task });
        AnsiConsole.Write(grid);
        return 1;
    }
}
