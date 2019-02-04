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
                });
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}