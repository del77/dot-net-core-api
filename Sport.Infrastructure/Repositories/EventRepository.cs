using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sport.Core.Domain;
using Sport.Core.Repositories;

namespace Sport.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly DatabaseContext _context;

        public EventRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<Event> GetAsync(Guid id)
        {
            return await _context.Events.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await _context.Events.Include(x => x.Creator).ToListAsync();
        }

        public async Task AddAsync(Event @event)
        {
            await _context.Events.AddAsync(@event);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var @event = await GetAsync(id);
            _context.Remove(@event);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Event @event)
        {
            _context.Update(@event);
            await _context.SaveChangesAsync();
        }
    }
}