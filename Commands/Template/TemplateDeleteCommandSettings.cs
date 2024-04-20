using Spectre.Console.Cli;

public class TemplateDeleteCommandSettings : TemplateSettings
{
    [CommandArgument(0, "[id]")]
    public int Id { get; set; }
}



