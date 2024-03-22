using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface ILibeyUserAggregate
    {
        Task<LibeyUserResponse> FindResponse(string documentNumber);
        Task<IEnumerable<LibeyUserResponse>> GetAll();
        Task Create(LibeyUserCommands command);
        Task Update(LibeyUserCommands command);
        Task Delete(string document);
        Task<IEnumerable<DocumentType>> GetDocumentType();
    }
}