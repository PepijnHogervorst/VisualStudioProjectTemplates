using Console.Services.Initialization;
using Console.Services.Sample;
using Console.Services.Utility;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        services.ConfigureServices();
    })
    .UseSerilog()
    .Build();

Log.Logger.Information("Application starting");

var startup = ActivatorUtilities.CreateInstance<Startup>(host.Services);
await startup.InitializeAsync();

var svc = ActivatorUtilities.CreateInstance<GreetingService>(host.Services);
svc.Run();
