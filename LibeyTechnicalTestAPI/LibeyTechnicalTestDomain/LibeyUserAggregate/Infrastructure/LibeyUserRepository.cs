using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class LibeyUserRepository : ILibeyUserRepository
    {
        private readonly Context _context;
        public LibeyUserRepository(Context context)
        {
            _context = context;
        }

        public async Task<LibeyUserResponse> FindResponse(string documentNumber)
        {
            var list = from libeyUser in _context.LibeyUsers.Where(x => x.DocumentNumber.Equals(documentNumber))
                    select new LibeyUserResponse()
                    {
                        DocumentNumber = libeyUser.DocumentNumber,
                        Active = libeyUser.Active,
                        Address = libeyUser.Address,
                        DocumentTypeId = libeyUser.DocumentTypeId,
                        Email = libeyUser.Email,
                        FathersLastName = libeyUser.FathersLastName,
                        MothersLastName = libeyUser.MothersLastName,
                        Name = libeyUser.Name,
                        Password = libeyUser.Password,
                        Phone = libeyUser.Phone,
                        UbigeoCode = libeyUser.UbigeoCode,
                        ProvinceCode = (from province in _context.Ubigeo
                                        where province.UbigeoCode == libeyUser.UbigeoCode
                                        select province.ProvinceCode).First().ToString(),
                        RegionCode = (from region in _context.Ubigeo
                                      where region.UbigeoCode == libeyUser.UbigeoCode
                                      select region.RegionCode).First().ToString()
                    };
            return await list.FirstAsync();
        }

        public async Task Create(LibeyUser libeyUser)
        {
            _context.LibeyUsers.Add(libeyUser);
            await _context.SaveChangesAsync();
        }

        public async Task Update(LibeyUser libeyUser)
        {
            _context.LibeyUsers.Update(libeyUser);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string document)
        {
            var user = _context.LibeyUsers.Where(x => x.DocumentNumber.Equals(document)).FirstOrDefault();
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LibeyUserResponse>> GetAll()
        {
            var list = from libeyUser in _context.LibeyUsers.ToList()
                       select new LibeyUserResponse()
                       {
                           DocumentNumber = libeyUser.DocumentNumber,
                           Active = libeyUser.Active,
                           Address = libeyUser.Address,
                           DocumentTypeId = libeyUser.DocumentTypeId,
                           Email = libeyUser.Email,
                           FathersLastName = libeyUser.FathersLastName,
                           MothersLastName = libeyUser.MothersLastName,
                           Name = libeyUser.Name,
                           Password = libeyUser.Password,
                           Phone = libeyUser.Phone
                       };
            return list;
        }

        public async Task<IEnumerable<DocumentType>> GetDocumentType()
        {
            return await _context.DocumentType.ToListAsync();
        }
    }
}