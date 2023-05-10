using Application.Services.Utility;
using Console.Services.Initialization;
using Console.Services.Sample;
using Domain.Common.Extensions;
using Domain.Common.Interfaces;
using Infrastructure.Services.Utility;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Reflection;

namespace Console.Services.Utility;

internal static class DependencyInjection
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddApplicationLogging();

        services.AddApplication();
        services.AddInfrastructure();
        services.AddFrontend();

        return services;
    }

    public static IServiceCollection AddFrontend(this IServiceCollection services)
    {
        services.AddStores();
        services.AddServices();
        return services;
    }

    public static IServiceCollection AddStores(this IServiceCollection services)
    {
        return services;
    }

    #region Add services
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddInitializationServices();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

        services.AddSingleton<IGreetingService, GreetingService>();

        return services;
    }

    private static IServiceCollection AddInitializationServices(this IServiceCollection services)
    {
        services.AddSingleton<Startup>();
        services.AddTypesFromAssemblies<IStartupInitializer>(ServiceLifetime.Transient, Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly());
        return services;
    }
    #endregion

    private static IServiceCollection AddApplicationLogging(this IServiceCollection services)
    {
        InitializeLogger.Initialize();

        services.AddLogging(builder => builder.AddSerilog(dispose: true));
        return services;
    }
}
