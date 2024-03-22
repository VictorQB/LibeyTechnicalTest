using AutoMapper;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class LibeyUserAggregate : ILibeyUserAggregate
    {
        private readonly ILibeyUserRepository _repository;
        private readonly IMapper _mapper;
        public LibeyUserAggregate(ILibeyUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<LibeyUserResponse> FindResponse(string documentNumber)
        {
            return await _repository.FindResponse(documentNumber);
        }
        public async Task Create(LibeyUserCommands command)
        {
            await _repository.Create(_mapper.Map<LibeyUser>(command));
        }
        public async Task Update(LibeyUserCommands command)
        {
            var user = _mapper.Map<LibeyUser>(command);
            await _repository.Update(user);
        }
        public async Task Delete(string document)
        {
            await _repository.Delete(document);
        }

        public async Task<IEnumerable<LibeyUserResponse>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<IEnumerable<DocumentType>> GetDocumentType()
        {
            return await _repository.GetDocumentType();
        }
    }
}