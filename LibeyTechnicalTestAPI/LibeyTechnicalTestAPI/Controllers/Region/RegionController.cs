using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.Region
{
    [Route("[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionAggregate _aggregate;
        public RegionController(IRegionAggregate aggregate)
        {
            _aggregate = aggregate;
        }

        [HttpGet]
        public async Task<IActionResult> GetRegion()
        {
            return Ok(await _aggregate.GetRegion());
        }

        [HttpGet("province/code/{code}")]
        public async Task<IActionResult> GetProvince(string code)
        {
            return Ok(await _aggregate.GetProvince(code));
        }

        [HttpGet("ubigeo/code/{code}")]
        public async Task<IActionResult> GetUbigeo(string code)
        {
            return Ok(await _aggregate.GetUbigeo(code));
        }
    }
}
