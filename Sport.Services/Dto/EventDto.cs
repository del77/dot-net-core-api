﻿using System;

namespace Sport.Services.Dto
{
    public class EventDto
    {
        public Guid Id { get; set; }
        public DisciplineDto Discipline { get; set; }
        public string Description { get; set; }
        public int Slots { get; set; }
        public int EnrolledUsersCount { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan ApproximateDuration { get; set; }
        public string Place { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}