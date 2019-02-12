using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sport.Core.Domain;
using Sport.Core.Repositories;

namespace Sport.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static readonly ISet<User> users = new HashSet<User>
        {
            new User(Guid.NewGuid(), "user1", "user1@email.com", "firstName1", "lastName1"),
            new User(Guid.NewGuid(), "user2", "user2@email.com", "firstName2", "lastName2"),
            new User(Guid.NewGuid(), "user3", "user3@email.com", "firstName3", "lastName3"),
        };

        public async Task<User> GetAsync(Guid id)
        {
            var user = await Task.FromResult(users.SingleOrDefault(x => x.Id == id));
            return user;
        }

        public async Task<User> GetAsync(string username)
        {
            var user = await Task.FromResult(users.SingleOrDefault(x => x.Username == username.ToLowerInvariant()));
            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await Task.FromResult(users);
        }

        public async Task AddAsync(User user)
        {
            await Task.FromResult(users.Add(user));
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await GetAsync(id);
            await Task.FromResult(users.Remove(user));
        }

        public async Task UpdateAsync(User user)
        {
            var existingUser = await GetAsync(user.Id);
            await Task.FromResult(existingUser = user);
        }
    }
}
