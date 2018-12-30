using AutoMapper;
using LicenseManager.Core.Domain.Customers;
using LicenseManager.Services.Customers.DTOs;

namespace LicenseManager.Services.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDto>(); 
                
            });

            return configuration.CreateMapper();
        }
    }
}