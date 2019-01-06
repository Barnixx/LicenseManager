using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LicenseManager.Core.Domain.Licenses;
using LicenseManager.Core.Domain.Licenses.Repositories;
using LicenseManager.Core.Types;
using LicenseManager.Infrastructure.Types;
using LicenseManager.Services.Licenses.DTOs;
using LicenseManager.Services.Licenses.Queries;

namespace LicenseManager.Services.Licenses
{
    public class LicenseService : ILicenseService
    {
        private readonly ILicenseRepository _licenseRepository;
        private readonly IMapper _mapper;

        public LicenseService(ILicenseRepository licenseRepository, IMapper mapper)
        {
            _licenseRepository = licenseRepository;
            _mapper = mapper;
        }

        public async Task<LicenseDto> GetAsync(Guid id)
        {
            var license = await _licenseRepository.GetAsync(id);
            if (license == null)
            {
                throw new ServiceException("license_not_found",
                    $"License: '{id}' was not found. ");
            }
            return _mapper.Map<License, LicenseDto>(license);
        }

        public async Task<License> GetAsync(Guid id, Guid customerId)
        {
            var license = await _licenseRepository.GetAsync(id, customerId);
            if (license == null)
            {
                throw new ServiceException("license_not_found",
                    $"License: '{id}' was not found. ");
            }

            return license;
        }

        public async Task<IPagedResult<LicenseDto>> BrowseAsync(Guid customerId, BrowseLicenses query)
        {
            var licenses = await _licenseRepository.BrowseAsync(customerId, query);
            return PagedResult<LicenseDto>.From(
                (PagedResultBase)licenses, 
                _mapper.Map<IEnumerable<License>, IEnumerable<LicenseDto>>(licenses.Items));
        }

        public async Task CreateAsync(Guid id, Guid customerId, string ip, string hwid, string key)
            => await _licenseRepository.CreateAsync(new License(id, customerId, ip, hwid, key));

        public async Task UpdateAsync(License license)
            => await _licenseRepository.UpdateAsync(license);
    }
}