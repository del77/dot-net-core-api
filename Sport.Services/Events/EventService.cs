using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Sport.Core.Domain;
using Sport.Core.Repositories;
using Sport.Services.Dto;
using Sport.Services.Interfaces;

namespace Sport.Services.Events
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public EventService(IEventRepository eventRepository, IUserRepository userRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<EventDto> GetAsync(Guid id)
        {
            var @event = await _eventRepository.GetAsync(id);
            return _mapper.Map<EventDto>(@event);
        }

        public async Task<IEnumerable<EventDto>> GetAllAsync()
        {
            var events = await _eventRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EventDto>>(events);
        }

        public async Task AddAsync(Guid id, Guid creatorId, Discipline discipline, string description, int slots, double price,
            DateTime date, TimeSpan approximateDuration, string place)
        {
            var user = await _userRepository.GetAsync(creatorId);
            var newEvent = new Event(id, user, discipline, description, slots, price, date, approximateDuration, place);
            user.JoinToEvent(newEvent);

            await _userRepository.UpdateAsync(user);
            await _eventRepository.AddAsync(newEvent);
        }

        public Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}