using EventBooking.TicketMgt.Application.Contracts.Persistence;

namespace EventBooking.TicketMgt.Application.Features.Events.Commands.UpdateEvent;

public class UpdateEventCommandHandler(
    IEventRepository eventRepository,
    IMapper mapper)
    :IRequestHandler<UpdateEventCommand>
{
    private readonly IEventRepository _eventRepository=eventRepository;
    private readonly IMapper _mapper=mapper;

    public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
        var eventToUpdate = await _eventRepository.GetByIdAsync(request.EventId);
        
        _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));
        await _eventRepository.UpdateAsync(eventToUpdate);        
    }

   
}
