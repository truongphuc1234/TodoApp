using System.ComponentModel;
using Spectre.Console.Cli;

public sealed class TaskCreateCommandSettings : TaskSetting
{
    [CommandArgument(0, "<title>")]
    public string Title { get; set; } = string.Empty;
    [CommandOption("-p|--priority")]
    [DefaultValue(0)]
    public int Priority { get; set; }
    [CommandOption("-t|--tags")]
    public string[]? Tags { get; set; }
    [CommandOption("-r|--repeat", IsHidden = true)]
    [DefaultValue(true)]
    public bool IsRepeat { get; set; }
    [CommandOption("-s|--start")]
    public string? StartAt { get; set; }
    [CommandOption("-e|--end")]
    public string? EndAt { get; set; }
    [CommandOption("-n|--notify")]
    public int? Notify { get; set; }
    [CommandOption("-c|--comment")]
    public string Note { get; set; } = string.Empty;
}

