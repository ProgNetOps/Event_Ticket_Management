
namespace EventBooking.TicketMgt.Application.Contracts.Persistence;

public interface IEventRepository:IAsyncRepository<Event> 
{
    Task<bool> IsEventNameAndDateUnuque(string name, DateTime eventDate);
}
