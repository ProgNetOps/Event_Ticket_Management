using EventBooking.TicketMgt.Application.Contracts.Persistence;
using EventBooking.TicketMgt.Domain.Entities;

namespace EventBooking.TicketMgt.Persistence.Repositories;

public class EventRepository : BaseRepository<Event>, IEventRepository
{
    public EventRepository(EventBookingDbContext dbContext):base(dbContext)
    {
        
    }
    public Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
    {
        var matches = _dbContext.Events.Any(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase)&&
        e.Date.Date.Equals(eventDate.Date));

        return Task.FromResult(matches);
    }
}
