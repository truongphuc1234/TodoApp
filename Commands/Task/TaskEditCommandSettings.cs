using Spectre.Console.Cli;

public sealed class TaskEditCommandSettings : TaskSetting
{
    [CommandArgument(0, "[id]")]
    public int Id { get; set; }
}

