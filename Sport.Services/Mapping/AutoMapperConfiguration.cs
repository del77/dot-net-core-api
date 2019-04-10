using System.Linq;
using AutoMapper;
using Sport.Core.Domain;
using Sport.Services.Dto;

namespace Sport.Services.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static IMapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<User, UserDto>();
                    cfg.CreateMap<User, UserDetailsDto>().ForMember(dest => dest.EnrolledTo, s => s.MapFrom(e => e.EnrolledTo.Select(x => x.Event)));
                    cfg.CreateMap<Event, EventDto>();
                    cfg.CreateMap<Event, EventDetailsDto>().ForMember(dest => dest.EnrolledUsers,
                        s => s.MapFrom(e => e.EnrolledUsers.Select(x => x.User)));
                });
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}