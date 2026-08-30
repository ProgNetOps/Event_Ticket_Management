
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EventBooking.TicketMgt.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly()));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}
