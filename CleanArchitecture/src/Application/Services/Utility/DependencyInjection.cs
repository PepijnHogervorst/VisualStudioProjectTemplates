using Microsoft.Extensions.DependencyInjection;

namespace Application.Services.Utility;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}