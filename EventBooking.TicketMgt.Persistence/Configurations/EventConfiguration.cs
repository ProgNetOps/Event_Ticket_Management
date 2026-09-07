using EventBooking.TicketMgt.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventBooking.TicketMgt.Persistence.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}
