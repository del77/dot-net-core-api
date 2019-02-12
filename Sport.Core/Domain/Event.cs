using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sport.Core.Domain
{
    public class Event
    {
        private ISet<UserEvent> enrolledUsers = new HashSet<UserEvent>();
        public Guid Id { get; private set; }
        public User Creator { get; private set; }
        public IEnumerable<UserEvent> EnrolledUsers => enrolledUsers;
        public Discipline Discipline { get; private set; }
        public string Description { get; private set; }
        public int Slots { get; private set; }

        public int EnrolledUsersCount
        {
            get => enrolledUsers.Count() + 1;
            private set { }
        }
        public double Price { get; private set; }
        public DateTime Date { get; private set; }
        public TimeSpan ApproximateDuration { get; private set; }
        public string Place { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Event() { }
        public Event(Guid id, User creator, Discipline discipline, string description, int slots, double price, DateTime date, TimeSpan approximateDuration, string place)
        {
            Id = id;
            Creator = creator;
            Discipline = discipline;
            SetDescription(description);
            SetSlots(slots);
            Price = price;
            Date = date;
            SetApproximateDuration(approximateDuration);
            Place = place;
            CreatedAt = DateTime.Now;
        }

        public void SetApproximateDuration(TimeSpan approximateDuration)
        {
            if (approximateDuration <= TimeSpan.FromSeconds(0))
            {
                throw new ArgumentException("Approximate duration must be positive.");
            }

            ApproximateDuration = approximateDuration;
        }

        public void SetSlots(int slots)
        {
            if (slots < 2)
            {
                throw new ArgumentException("Slots number must be greater than 1.");
            }

            if (EnrolledUsersCount > slots)
            {
                throw new ArgumentException("Slots number mustn't be lower than enrolled number.");
            }

            Slots = slots;
        }

        public void SetDescription(string description)
        {
            if (Description.Length > 5000)
            {
                throw new ArgumentException("Description length mustn't be greater than 5000.");
            }

            Description = description;
        }

        public void JoinUser(User user)
        {
            if (EnrolledUsersCount + 1 > Slots)
            {
                throw new Exception("Not enough slots");
            }
            enrolledUsers.Add(new UserEvent
            {
                Event = this,
                EventId = Id,
                User = user,
                UserId = user.Id
            });
        }
    }
}