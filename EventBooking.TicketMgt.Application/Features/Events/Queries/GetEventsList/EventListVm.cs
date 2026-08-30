namespace EventBooking.TicketMgt.Application.Features.Events.Queries.GetEventsList;
/// <summary>
/// A class containing just the properties of event returned in a list
/// </summary>
public class EventListVm
{
    public Guid EventId { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string ImageUrl { get; set; }
}
