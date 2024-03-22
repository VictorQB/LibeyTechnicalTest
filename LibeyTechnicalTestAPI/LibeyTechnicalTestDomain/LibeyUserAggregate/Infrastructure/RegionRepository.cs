using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class RegionRepository : IRegionRepository
    {
        private readonly Context _context;

        public RegionRepository(Context context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Region>> GetRegion()
        {
            return await _context.Region.ToListAsync();
        }

        public async Task<IEnumerable<Province>> GetProvince(string code)
        {
            var province = _context.Province.Where(x => x.RegionCode.Equals(code));
            return await province.ToListAsync();
        }

        public async Task<IEnumerable<Ubigeo>> GetUbigeo(string code)
        {
            var ubigeo = _context.Ubigeo.Where(x => x.ProvinceCode.Equals(code));
            return await ubigeo.ToListAsync();
        }
    }
}
