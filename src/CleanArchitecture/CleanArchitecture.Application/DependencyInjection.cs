using CleanArchitecture.Application.Abstractions.Behaviors;
using CleanArchitecture.Domain.Alquileres;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly);

            //con la coma en LogginBehaviors<,> le indico que tiene dos parametros genericos a inyectarse
            configuration.AddOpenBehavior(typeof(LoggingBehaviors<,>));
        });

        services.AddTransient<PrecioService>();

        return services;
    }
}
