
namespace EventBooking.TicketMgt.Application.Features.Events.Commands.CreateEvent;
/// <summary>
/// The command returns a GUID that represents the ID of the created Event
/// </summary>
public class CreateEventCommand:IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }
    public string? Artist { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public Guid CategoryId { get; set; }

    public override string ToString()
    {
        return $"Event Name: {Name}; Price:{Price}; By: {Artist};" +
            $" On: {Date.ToShortDateString()}; Description: {Description}";
    }

}
