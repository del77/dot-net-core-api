using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sport.Core.Domain;
using Sport.Services.Dto;

namespace Sport.Services.Interfaces
{
    public interface IEventService
    {
        Task<EventDto> GetAsync(Guid id);
        Task<IEnumerable<EventDto>> GetAllAsync();
        Task AddAsync(Guid id, Guid creatorId, Discipline discipline, string description, int slots, double price, DateTime date, TimeSpan approximateDuration, string place);
        Task RemoveAsync(Guid id);
        Task JoinEventAsync(Guid eventId, Guid userId);
    }
}