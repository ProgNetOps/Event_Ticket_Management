using EventBooking.TicketMgt.Application.Contracts.Persistence;

namespace EventBooking.TicketMgt.Application.Features.Events.Queries.GetEventsList;

public class GetEventsListQueryHandler(
    IEventRepository eventRepository,
    IMapper mapper) 
    : IRequestHandler<GetEventsListQuery, List<EventListVm>>
{
    private readonly IEventRepository _eventRepository =eventRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<List<EventListVm>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
    {
        var allEvents = (await _eventRepository.ListAllAsync()).
            OrderBy(x => x.Date);
        return _mapper.Map<List<EventListVm>>(allEvents);
     }
}
