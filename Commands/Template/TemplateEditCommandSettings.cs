using Spectre.Console.Cli;

public sealed class TemplateEditCommandSettings : TaskSetting
{
    [CommandArgument(0, "[id]")]
    public int Id { get; set; }
}

