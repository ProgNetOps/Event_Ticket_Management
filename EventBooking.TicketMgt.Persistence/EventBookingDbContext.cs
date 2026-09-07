
using EventBooking.TicketMgt.Domain.Common;
using EventBooking.TicketMgt.Domain.Entities;

namespace EventBooking.TicketMgt.Persistence;

public class EventBookingDbContext(DbContextOptions<EventBookingDbContext> options)
    : DbContext(options)
{
    public DbSet<Event> Events { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventBookingDbContext).Assembly);

        //SEED DATA, ADDED THROUGH MIGRATIONS
        Guid concertGuid = Guid.NewGuid();
        Guid musicalGuid = Guid.NewGuid();
        Guid playGuid = Guid.NewGuid();
        Guid conferenceGuid = Guid.NewGuid();

        List<Category> categories = new()
        {
            new Category
            {
                CategoryId = concertGuid,
                Name = "Concerts"
            },
            new Category
            {
                CategoryId = musicalGuid,
                Name = "Musicals"
            },
            new Category
            {
                CategoryId = playGuid,
                Name = "Plays"
            },
            new Category
            {
                CategoryId = conferenceGuid,
                Name = "Conferences"
            },
        };

        List<Event> events = new()
        {
            new Event
            {
                EventId = Guid.NewGuid(),
                Name="Wale Davis Live!",
                Price=45,
                Artist="Wale Davis",
                Date=DateTime.Now.AddMonths(7),
                Description="Join Wale for his farewell tour across 26 continents",
                ImageUrl="https://unsplash.com/photos/man-playing-electric-guitar-iIWDt0fXa84",
                CategoryId=concertGuid
            },
            new Event
            {
                EventId = Guid.NewGuid(),
                Name="The State of the Nation",
                Price=34,
                Artist="Joe Joel",
                Date=DateTime.Now.AddMonths(4),
                Description="The president of the prestigious organization will reveal the  strategies that should be adopted to have a viable economy",
                ImageUrl="https://unsplash.com/photos/skyscrapers-and-highway-interchange-in-vancouver-tivSfDwDoq4",
                CategoryId=conferenceGuid
            },
            new Event
            {
                EventId = Guid.NewGuid(),
                Name="Sue Job: The One and Only ",
                Price=92,
                Artist="Sue Job",
                Date=DateTime.Now.AddMonths(5),
                Description="Sue Job needs no introduction; his performances are testament to his musical genius. Come have a taste!",
                ImageUrl="https://unsplash.com/photos/man-with-jump-rope-in-park-R3nbNkzPeNM",
                CategoryId=musicalGuid
            }
        };

        modelBuilder.Entity<Category>().HasData(categories);
        modelBuilder.Entity<Event>().HasData(events);

    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach(var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
