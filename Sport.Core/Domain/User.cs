using System;

namespace Sport.Core.Domain
{
    public class User
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public Role Role { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public User(Guid id, string username, string email, string firstName, string lastName)
        {
            Id = id;
            Username = username;
            Email = email.ToLowerInvariant();
            FirstName = firstName;
            LastName = lastName;
            Role = Role.User;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password)
        {
            Password = password;
        }
    }
}