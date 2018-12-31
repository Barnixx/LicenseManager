using AutoMapper;
using LicenseManager.Core.Domain.Customers;
using LicenseManager.Core.Domain.Licenses;
using LicenseManager.Services.Customers.DTOs;
using LicenseManager.Services.Licenses.DTOs;

namespace LicenseManager.Services.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDto>();
                cfg.CreateMap<License, LicenseDto>()
                    .ForMember(x => x.Status, m => m.MapFrom(e => e.Status.ToString()));

            });

            return configuration.CreateMapper();
        }
    }
}