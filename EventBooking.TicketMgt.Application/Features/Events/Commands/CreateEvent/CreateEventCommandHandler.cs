using EventBooking.TicketMgt.Application.Contracts.Persistence;

namespace EventBooking.TicketMgt.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommandHandler (
    IEventRepository eventRepository,
    IMapper mapper)
    : IRequestHandler<CreateEventCommand, Guid>
{
    private readonly IEventRepository _eventRepository = eventRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var @event = _mapper.Map<Event>(request);

        //Instantiate the validator instance
        CreateEventCommandValidator validator = new(_eventRepository);

        //Results of the validaton is kept in the variable
        var validationResult = await validator.ValidateAsync(request);
       
        //Check for error counts
        if(validationResult.Errors.Count > 0)
        {
            //This will throw the validation error in our custom validation class
            throw new Exceptions.ValidationException(validationResult);
        }


        @event = await _eventRepository.AddAsync(@event);
        return @event.EventId;
    }
}
