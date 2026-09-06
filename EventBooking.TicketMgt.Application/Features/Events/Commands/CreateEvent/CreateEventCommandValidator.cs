using EventBooking.TicketMgt.Application.Contracts.Persistence;
using FluentValidation;
using System.Data;

namespace EventBooking.TicketMgt.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
{
    private readonly IEventRepository _eventRepository;
    public CreateEventCommandValidator(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

        RuleFor(p => p.Date)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .GreaterThan(DateTime.Now);

        RuleFor(p => p.Price)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .GreaterThan(0);

        /*Validate if the combination of event name and date
        is still unique in the database, so we bring in the eventRepository*/
        RuleFor(e => e)
            .MustAsync(EventNameAndDateUnique)
            .WithMessage("An event with the same name and date already exists");
            
    }

    //Custom validation rule to trigger
    private async Task<bool> EventNameAndDateUnique(CreateEventCommand e, CancellationToken cancellationToken)
    {
        return (await _eventRepository.IsEventNameAndDateUnuque(e.Name, e.Date) is false);
    }
}