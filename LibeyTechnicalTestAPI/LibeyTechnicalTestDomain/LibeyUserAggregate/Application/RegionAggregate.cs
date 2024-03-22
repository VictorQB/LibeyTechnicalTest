using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class RegionAggregate : IRegionAggregate
    {
        private readonly IRegionRepository _repository;

        public RegionAggregate(IRegionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Region>> GetRegion()
        {
            return await _repository.GetRegion();
        }

        public async Task<IEnumerable<Province>> GetProvince(string code)
        {
            return await _repository.GetProvince(code);
        }

        public async Task<IEnumerable<Ubigeo>> GetUbigeo(string code)
        {
            return await _repository.GetUbigeo(code);
        }

    }
}
