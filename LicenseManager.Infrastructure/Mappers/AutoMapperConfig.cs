using AutoMapper;
using LicenseManager.Core.Domain;
using LicenseManager.Infrastructure.DTO;

namespace LicenseManager.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>(); 
                
            });

            return configuration.CreateMapper();
        }
    }
}