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
collection.AddScoped<ITemplateService, TemplateService>();

var registrar = new TypeRegistrar(collection);

var app = new CommandApp(registrar);

app.Configure(config =>
{
    config.AddBranch<TaskSetting>("task|t", task =>
    {
        task.AddCommand<TaskCreateCommand>("create");
        task.AddCommand<TaskShowCommand>("show");
        task.AddCommand<TaskEditCommand>("edit");
        task.AddCommand<TaskDeleteCommand>("delete");
    });
    config.AddCommand<TemplateCreateCommand>("template add");
    config.AddCommand<TemplateShowCommand>("template show");
    config.AddCommand<TemplateEditCommand>("template edit");
    config.AddCommand<TemplateDeleteCommand>("template delete");

});
return app.Run(args);
