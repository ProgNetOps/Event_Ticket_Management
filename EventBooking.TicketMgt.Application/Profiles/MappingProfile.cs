using AutoMapper;
using EventBooking.TicketMgt.Application.Features.Categories.Queries.GetCategoriesList;
using EventBooking.TicketMgt.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using EventBooking.TicketMgt.Application.Features.Events.Queries.GetEventDetail;
using EventBooking.TicketMgt.Application.Features.Events.Queries.GetEventsList;

namespace EventBooking.TicketMgt.Application.Profiles;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Event, EventListVm>().ReverseMap();
        CreateMap<Event, EventDetailVm>().ReverseMap();
        CreateMap<Category, CategoryDto>();
        CreateMap<Category, CategoryListVm>();
        CreateMap<Category, CategoryEventListVm>();
    }
}
