using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

var folder = Environment.SpecialFolder.LocalApplicationData;
var path = Environment.GetFolderPath(folder);
var dbpath = Path.Join(path, "blogging.db");
var collection = new ServiceCollection();
collection.AddDbContext<AppDbContext>(
        options => options.UseSqlite($"Data Source={dbpath}"));
collection.AddScoped<ITaskService, TaskService>();

var registrar = new TypeRegistrar(collection);

var app = new CommandApp(registrar);

app.Configure(config =>
{
    config.AddCommand<TaskCreateCommand>("task create");
    config.AddCommand<TaskShowCommand>("task show");
    config.AddCommand<TaskEditCommand>("task edit");
    config.AddCommand<TaskDeleteCommand>("task delete");
    config.AddCommand<TemplateWorkAddCommand>("template add");
    config.AddCommand<TemplateWorkShowCommand>("template show");
    config.AddCommand<TemplateWorkEditCommand>("template edit");
    config.AddCommand<TemplateWorkDeleteCommand>("template delete");

});
return app.Run(args);
