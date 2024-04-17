using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;

public sealed class TemplateShowCommand : AsyncCommand<TemplateShowCommandSettings>
{
    private ITemplateService templateService;

    public TemplateShowCommand(ITemplateService service) : base()
    {
        this.templateService = service;
    }


    public override async Task<int> ExecuteAsync([NotNull] CommandContext context, [NotNull] TemplateShowCommandSettings settings)
    {
        var templates = await this.templateService.GetAllTemplates();
        var grid = new Grid();

        grid.AddColumn();
        grid.AddColumn();
        grid.AddColumn();

        grid.AddRow(new Text[]{
            new Text("Id", new Style(Color.Red, Color.Black)).Centered(),
            new Text("Title", new Style(Color.Green, Color.Black)).Centered(),
            new Text("Periods", new Style(Color.Blue, Color.Black)).Centered(),
        });

        foreach (var task in templates)
        {
            grid.AddRow(new Text[]{
                new Text(task.Id.ToString()).LeftJustified(),
                new Text(task.Title).Centered(),
                new Text(task.Periods[0]).Centered(),
            });
        }

        AnsiConsole.Write(grid);
        return 1;
    }
}


