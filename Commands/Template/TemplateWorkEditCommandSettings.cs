using Spectre.Console.Cli;

public class TemplateWorkEditCommandSettings : TemplateSettings
{
    [CommandArgument(0, "[id]")]
    public int Id { get; set; }
}



