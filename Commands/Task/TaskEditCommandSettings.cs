using Spectre.Console.Cli;

public sealed class TaskEditCommandSettings : TaskSetting
{
    [CommandArgument(0, "[id]")]
    public int Id { get; set; }

    [CommandOption("-d|--description")]
    public string? Name { get; set; }

    [CommandOption("-p|--priority")]
    public int? Priority { get; set; }

    [CommandOption("-t|--tags")]
    public string[]? Tags { get; set; }

    [CommandOption("-r|--repeat", IsHidden = true)]
    public bool? IsRepeat { get; set; }

    [CommandOption("-s|--start")]
    public string? StartAt { get; set; }

    [CommandOption("-e|--end")]
    public string? EndAt { get; set; }

    [CommandOption("-n|--notify")]
    public int? Notify { get; set; }

    [CommandOption("-c|--comment")]
    public string? Note { get; set; }
}
