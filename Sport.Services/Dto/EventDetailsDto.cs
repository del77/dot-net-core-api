using System.Collections.Generic;

namespace Sport.Services.Dto
{
    public class EventDetailsDto : EventDto
    {
        public IEnumerable<UserDto> EnrolledUsers { get; set; }
        public UserDto Creator { get; set; }
    }
}