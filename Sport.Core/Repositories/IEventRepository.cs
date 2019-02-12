using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sport.Core.Domain;

namespace Sport.Core.Repositories
{
    public interface IEventRepository
    {
        Task<Event> GetAsync(Guid id);
        Task<IEnumerable<Event>> GetAllAsync();
        Task AddAsync(Event @event);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Event @event);
    }
}