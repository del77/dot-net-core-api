using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sport.Core.Domain;
using Sport.Services.Dto;

namespace Sport.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDetailsDto> GetAsync(Guid id);
        Task<UserDetailsDto> GetAsync(string username);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task RemoveAsync(Guid id);
        Task RegisterAsync(Guid id, string username, string email, string firstName, string lastName, string password, string street, string city, string country, string postalCode);
        Task LoginAsync(string username, string password);
        Task ChangePasswordAsync(Guid userId, string password, string newPassword);
    }
}
