using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Sport.Core.Domain
{
    public class User
    {
        private ISet<Event> myEvents = new HashSet<Event>();
        private ISet<UserEvent> _enrolledTo = new HashSet<UserEvent>();
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public Role Role { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public IEnumerable<Event> MyEvents => myEvents;
        public IEnumerable<UserEvent> EnrolledTo => _enrolledTo;

        public User(Guid id, string username, string email, string firstName, string lastName)
        {
            Id = id;
            Username = username.ToLowerInvariant();
            Email = email.ToLowerInvariant();
            FirstName = firstName;
            LastName = lastName;
            Role = Role.User;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password, IPasswordHasher<User> passwordHasher)
        {
            if (String.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Invalid password format", nameof(password));
            }

            Password = passwordHasher.HashPassword(this, password);
        }

        public bool VerifyPassword(string password, IPasswordHasher<User> passwordHasher)
        {
            var result = passwordHasher.VerifyHashedPassword(this, Password, password);
            return result != PasswordVerificationResult.Failed;
        }

        public void AddEvent(Guid id, Discipline discipline, string description, int slots, double price, DateTime date,
            TimeSpan approximateDuration, string place)
        {
            var newEvent = new Event(id, this, discipline, description, slots, price, date, approximateDuration, place);
            myEvents.Add(newEvent);
        }

        public void JoinToEvent(Event @event)
        {
            @event.JoinUser(this);
            //_enrolledTo.Add(@event);
            _enrolledTo.Add(new UserEvent
            {
                Event = @event,
                EventId = @event.Id,
                User = this,
                UserId = Id
            });
        }
    }
}