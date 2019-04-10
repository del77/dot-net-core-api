using System;
using Sport.Services.Dto;
using Sport.Services.Interfaces;

namespace Sport.Services.Events.Commands
{
    public class CreateEvent : AuthenticatedCommand
    {
        public Guid Id { get; set; }
        public int Discipline { get; set; }
        public string Description { get; set; }
        public int Slots { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan ApproximateDuration { get; set; }
        public string Place { get; set; } 
    }
}