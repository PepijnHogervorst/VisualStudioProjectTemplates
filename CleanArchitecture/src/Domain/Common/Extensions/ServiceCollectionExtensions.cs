using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace Domain.Common.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterAssemblyTypes<T>(this IServiceCollection services, ServiceLifetime lifetime, List<Func<TypeInfo, bool>>? predicates = null)
    {
        var scanAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
        scanAssemblies.SelectMany(x => x.GetReferencedAssemblies())
                      .Where(t => !scanAssemblies.Any(a => a.FullName == t.FullName))
                      .Distinct()
                      .ToList()
                      .ForEach(x => scanAssemblies.Add(AppDomain.CurrentDomain.Load(x)));

        var interfaces = scanAssemblies.SelectMany(o => o.DefinedTypes
                                       .Where(x => x.IsInterface)
                                       .Where(x => x != typeof(T))
                                       .Where(x => typeof(T).IsAssignableFrom(x)));

        foreach (var foundInterface in interfaces)
        {
            var types = scanAssemblies.SelectMany(o => o.DefinedTypes
                                      .Where(x => x.IsClass)
                                      .Where(x => foundInterface.IsAssignableFrom(x)));

            if (predicates?.Count > 0)
            {
                foreach (var predict in predicates)
                {
                    types = types.Where(predict);
                }
            }

            foreach (var type in types)
            {
                services.TryAdd(new ServiceDescriptor(
                    foundInterface,
                    type,
                    lifetime));
            }
        }

        return services;
    }

    public static void AddTypesFromAssemblyContaining<TSearch, TMarker>(this IServiceCollection services)
    {
        services.AddTypesFromAssembliesContaining<TSearch>(typeof(TMarker));
    }

    public static void AddTypesFromAssembliesContaining<TSearch>(
        this IServiceCollection services, params Type[] assemblyMarkers)
    {
        var assemblies = assemblyMarkers.Select(x => x.Assembly).ToArray();
        AddTypesFromAssemblies<TSearch>(services, ServiceLifetime.Transient, assemblies);
    }

    public static void AddTypesFromAssemblies<TSearch>(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Transient, params Assembly[] assemblies)
    {
        foreach (var assembly in assemblies)
        {
            var types = assembly.DefinedTypes.Where(x =>
                typeof(TSearch).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            foreach (var type in types)
            {
                services.Add(new ServiceDescriptor(typeof(TSearch), type, lifetime));
            }
        }
    }
}
