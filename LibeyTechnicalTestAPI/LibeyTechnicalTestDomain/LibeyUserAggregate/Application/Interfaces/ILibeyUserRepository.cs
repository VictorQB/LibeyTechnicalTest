using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface ILibeyUserRepository
    {
        Task<LibeyUserResponse> FindResponse(string documentNumber);
        Task<IEnumerable<LibeyUserResponse>> GetAll();
        Task Create(LibeyUser libeyUser);
        Task Update(LibeyUser libeyUser);
        Task Delete(string document);
        Task<IEnumerable<DocumentType>> GetDocumentType();

    }
}
