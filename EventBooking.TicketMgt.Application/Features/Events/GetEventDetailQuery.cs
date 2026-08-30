namespace EventBooking.TicketMgt.Application.Features.Events;

public class GetEventDetailQuery:IRequest<EventDetailVm>
{
    public Guid Id { get; set; }
}
