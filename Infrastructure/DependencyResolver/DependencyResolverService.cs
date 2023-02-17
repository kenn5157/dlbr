using Application.Interfaces;
using Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyResolver;

public class DependencyResolverService
{
    public static void RegisterInfrastructureLayer(IServiceCollection services)
    {
        services.AddScoped<IFieldRepository, FieldRepository>();
        services.AddScoped<IDatabaseRepo, DatabaseRepository>();
    }
}