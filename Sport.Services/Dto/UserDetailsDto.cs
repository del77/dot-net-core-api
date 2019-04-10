using System.Collections.Generic;

namespace Sport.Services.Dto
{
    public class UserDetailsDto : UserDto
    {
        public IEnumerable<EventDto> EnrolledTo { get; set; }
        public IEnumerable<EventDto> MyEvents { get; set; }
    }
}