
namespace EventBooking.TicketMgt.Application.Features.Categories.Commands.CreateCategory;
/// <summary>
/// The command returns an object, CreateCategoryCommandResponse, not just an id
/// </summary>
public class CreateCategoryCommand:IRequest<CreateCategoryCommandResponse>
{
    public string Name { get; set; } = string.Empty;
}
