using EventBooking.TicketMgt.Application.Contracts.Persistence;

namespace EventBooking.TicketMgt.Application.Features.Events.Commands.DeleteEvent;

public class DeleteEventCommandHandler(
    IEventRepository eventRepository,
    IMapper mapper)
    : IRequestHandler<DeleteEventCommand>
{
    private readonly IEventRepository _eventRepository = eventRepository;
    private readonly IMapper _mapper = mapper;
    public async Task Handle(DeleteEventCommand request, CancellationToken cancellationToken)
    {
        var eventToDelete = await _eventRepository.GetByIdAsync(request.EventId);
        await _eventRepository.DeleteAsync(eventToDelete);
    }
}
