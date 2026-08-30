namespace EventBooking.TicketMgt.Application.Contracts.Persistence;
/// <summary>
/// Base interface for specific interfaces that handle interactions with the database
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IAsyncRepository<T> where T : class
{
    Task<T> GetByIdAsync(Guid id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
