using AutoMapper;
using EventBooking.TicketMgt.Application.Contracts.Persistence;

namespace EventBooking.TicketMgt.Application.Features.Events;

public class GetEventsListQueryHandler(
    IAsyncRepository<Event> eventRepository,
    IMapper mapper) 
    : IRequestHandler<GetEventsListQuery, List<EventListVm>>
{
    private readonly IAsyncRepository<Event> _eventRepository=eventRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<List<EventListVm>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
    {
        var allEvents = (await _eventRepository.ListAllAsync()).
            OrderBy(x => x.Date);
        return _mapper.Map<List<EventListVm>>(allEvents);
     }
}
