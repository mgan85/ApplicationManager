namespace BusinessLogic;

using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IApplicationService, ApplicationService>();

        return services;
    }
}
