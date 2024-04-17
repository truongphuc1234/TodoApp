using Spectre.Console.Cli;

public class TemplateWorkDeleteCommandSettings : TemplateSettings
{
    [CommandArgument(0, "[id]")]
    public int Id { get; set; }
}



