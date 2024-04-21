using Spectre.Console.Cli;

public sealed class TaskCompleteCommandSettings : TaskSetting
{
    [CommandArgument(0, "[id]")]
    public int Id { get; set; }
}
