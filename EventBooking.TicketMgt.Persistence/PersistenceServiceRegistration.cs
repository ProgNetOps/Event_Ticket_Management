using EventBooking.TicketMgt.Application.Contracts.Persistence;
using EventBooking.TicketMgt.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventBooking.TicketMgt.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<EventBookingDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(
                "EventBookingConnectionString"));
        });

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
        services.AddScoped<ICategoryRepository,CategoryRepository>();
        services.AddScoped<IOrderRepository,OrderRepository>();


        return services;
    }
}
