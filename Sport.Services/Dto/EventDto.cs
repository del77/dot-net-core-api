using System;

namespace Sport.Services.Dto
{
    public class EventDto
    {
        public Guid Id { get; private set; }
        public UserDto Creator { get; private set; }
        //enrolled users
        public DisciplineDto Discipline { get; private set; }
        public string Description { get; private set; }
        public int Slots { get; private set; }

        //enrolled count
        public double Price { get; private set; }
        public DateTime Date { get; private set; }
        public TimeSpan ApproximateDuration { get; private set; }
        public string Place { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}