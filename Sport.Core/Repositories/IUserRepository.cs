using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sport.Core.Domain;

namespace Sport.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(User user);
    }
}
