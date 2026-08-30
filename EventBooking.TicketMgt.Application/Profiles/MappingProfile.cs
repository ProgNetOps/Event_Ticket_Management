using AutoMapper;
using EventBooking.TicketMgt.Application.Features.Events;

namespace EventBooking.TicketMgt.Application.Profiles;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Event, EventListVm>().ReverseMap();
        CreateMap<Event, EventDetailVm>().ReverseMap();
        CreateMap<Category, CategoryDto>();
    }
}
