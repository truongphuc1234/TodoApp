using Spectre.Console.Cli;

public sealed class TaskDeleteCommandSettings : TaskSetting
{
    [CommandArgument(0, "[id]")]
    public int Id { get; set; }
}

