using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetRegion();
        Task<IEnumerable<Province>> GetProvince(string code);
        Task<IEnumerable<Ubigeo>> GetUbigeo(string code);
    }
}
