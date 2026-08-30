using EventBooking.TicketMgt.Application.Contracts.Persistence;

namespace EventBooking.TicketMgt.Application.Features.Events.Queries.GetEventDetail;

public class GetEventDetailQueryHandler(
    IEventRepository eventRepository,
    ICategoryRepository categoryRepository,
    IMapper mapper) 
    : IRequestHandler<GetEventDetailQuery, EventDetailVm>
{
    private readonly IEventRepository _eventRepository = eventRepository;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<EventDetailVm> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
    {
        var @event = await _eventRepository.GetByIdAsync(request.Id);
        var eventDetailDto = _mapper.Map<EventDetailVm>(@event);

        var category = await _categoryRepository.GetByIdAsync(@event.CategoryId);

        eventDetailDto.Category = _mapper.Map<CategoryDto>(category);

        return eventDetailDto;
    
    }
}
