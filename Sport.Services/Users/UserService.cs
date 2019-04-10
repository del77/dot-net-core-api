using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Sport.Core.Domain;
using Sport.Core.Repositories;
using Sport.Services.Dto;
using Sport.Services.Interfaces;

namespace Sport.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(IUserRepository userRepository, IMapper mapper, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }
        public async Task<UserDetailsDto> GetAsync(Guid id)
        {
             var user = await _userRepository.GetAsync(id);
            return _mapper.Map<UserDetailsDto>(user);
        }

        public async Task<UserDetailsDto> GetAsync(string username)
        {
            var user = await _userRepository.GetAsync(username);
            return _mapper.Map<UserDetailsDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task RemoveAsync(Guid id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task RegisterAsync(Guid id, string username, string email, string firstName, string lastName, string password, string street, string city, string country, string postalCode)
        {
            User user = await _userRepository.GetAsync(username);
            if (user != null)
            {
                throw new Exception($"User with username '{username}' already exists");
            }
            var address = new Address(street, city, country, postalCode);
            user = new User(id, username, email, firstName, lastName, address);
            user.SetPassword(password, _passwordHasher);
            await _userRepository.AddAsync(user);
        }

        public async Task LoginAsync(string username, string password)
        {
            var user = await _userRepository.GetAsync(username);
            if (user == null || !user.VerifyPassword(password, _passwordHasher))
            {
                throw new Exception("Invalid username or password");
            }

        }

        public async Task ChangePasswordAsync(Guid userId, string password, string newPassword)
        {
            var user = await _userRepository.GetAsync(userId);
            if (user == null || !user.VerifyPassword(password, _passwordHasher))
            {
                throw new Exception("Incorrect password");
            }
            user.SetPassword(newPassword, _passwordHasher);
        }
    }
}