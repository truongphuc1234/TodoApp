using System.Diagnostics.CodeAnalysis;
using Spectre.Console.Cli;

public sealed class TaskCreateCommand : AsyncCommand<TaskCreateCommandSettings>
{
    private ITaskService taskService;

    public TaskCreateCommand(ITaskService service, ILabelService labelService) : base()
    {
        this.taskService = service;
    }

    public override async Task<int> ExecuteAsync([NotNull] CommandContext context, [NotNull] TaskCreateCommandSettings settings)
    {
        var priority = (Priority) Enum.ToObject(typeof(Priority) , settings.Priority);
        var task = new TaskItem
        {
            Title = settings.Title,
            Priority = priority,
            Note = settings.Note,
            Remind = Remind.None,
            IsRepeat = settings.IsRepeat
       S 
        };
        await this.taskService.CreateTask(task);
        return 1;
    }
}

