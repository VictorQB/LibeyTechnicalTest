using LibeyTechnicalTestDomain.EFCore.Configuration;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Microsoft.EntityFrameworkCore;
namespace LibeyTechnicalTestDomain.EFCore
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<LibeyUser> LibeyUsers { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<Ubigeo> Ubigeo { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LibeyUserConfiguration());
            modelBuilder.Entity<Region>().HasKey(region => new
            {
                region.RegionCode
            });

            modelBuilder.Entity<Province>().HasKey(province => new
            {
                province.ProvinceCode
            }); 
            
            modelBuilder.Entity<Ubigeo>().HasKey(ubigeo => new
            {
                ubigeo.UbigeoCode
            }); 
            
            modelBuilder.Entity<DocumentType>().HasKey(documentType => new
            {
                documentType.DocumentTypeId
            });
        }
    }
}