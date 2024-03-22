using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace LibeyTechnicalTestAPI.Controllers.LibeyUser
{
    [ApiController]
    [Route("[controller]")]
    public class LibeyUserController : Controller
    {
        private readonly ILibeyUserAggregate _aggregate;
        public LibeyUserController(ILibeyUserAggregate aggregate)
        {
            _aggregate = aggregate;
        }
        [HttpGet]
        [Route("{documentNumber}")]
        public async Task<IActionResult> FindResponse(string documentNumber)
        {
            return Ok(await _aggregate.FindResponse(documentNumber));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _aggregate.GetAll());
        }

        [HttpPost]       
        public async Task Create(LibeyUserCommands command)
        {
            await _aggregate.Create(command);       
        }
        
        [HttpPut]
        public async Task Update(LibeyUserCommands command)
        {
            await _aggregate.Update(command);
        }

        [HttpDelete("{document}")]
        public async Task Delete(string document)
        {
            await _aggregate.Delete(document);
        }

        [HttpGet("documentType")]
        public async Task<IActionResult> GetDocumentType()
        {
            return Ok(await _aggregate.GetDocumentType());
        }
    }
}