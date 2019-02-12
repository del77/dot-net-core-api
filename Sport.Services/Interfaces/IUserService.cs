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
        Task<UserDto> GetAsync(Guid id);
        Task<UserDto> GetAsync(string username);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task RegisterAsync(Guid id, string username, string email, string firstName, string lastName, string password);
        Task LoginAsync(string username, string password);
    }
}
