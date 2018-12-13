using AutoMapper;
using LicenseManager.Infrastructure.DTO;
using LicenseManagerCore.Domain;

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