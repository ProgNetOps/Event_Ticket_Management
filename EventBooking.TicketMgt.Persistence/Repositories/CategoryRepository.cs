using EventBooking.TicketMgt.Application.Contracts.Persistence;
using EventBooking.TicketMgt.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventBooking.TicketMgt.Persistence.Repositories;

public class CategoryRepository(EventBookingDbContext dbContext) :
    BaseRepository<Category>(dbContext),
    ICategoryRepository
{
    public async Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents)
    {

        var allCategories = await _dbContext.Categories
            .Include(x=>x.Events)
            .ToListAsync();

        if(includePassedEvents is false)
        {
            allCategories.ForEach(p => p.Events.ToList().RemoveAll(c => c.Date < DateTime.Today));
        }
        return allCategories;
    }
}
