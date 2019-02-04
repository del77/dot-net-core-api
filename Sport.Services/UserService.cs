using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Sport.Core.Domain;
using Sport.Core.Repositories;
using Sport.Services.Dto;
using Sport.Services.Interfaces;

namespace Sport.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDto> GetAsync(Guid id)
        {
            var user = await _userRepository.GetAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public Task RegisterAsync(Guid id, string username, string email, string firstName, string lastName, string password)
        {
            throw new NotImplementedException();
        }

        public Task LoginAsync(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}