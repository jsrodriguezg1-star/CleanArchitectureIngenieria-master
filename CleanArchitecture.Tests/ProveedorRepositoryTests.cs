using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Data.Repositories;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CleanArchitecture.Tests
{
    public class ProveedorRepositoryTests
    {
        private ApplicationDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_Proveedor")
                .Options;
            return new ApplicationDbContext(options);
        }

        [Fact]
        public void GetByIdentificacion_ReturnsProveedor()
        {
            using var context = CreateContext();
            var repo = new ProveedorRepository(context);

            var prov = new Proveedor { Nombre = "Prov1", IdentificacionFiscal = "ABC123" };
            repo.Add(prov);
            repo.Save();

            var found = repo.GetByIdentificacion("ABC123");
            Assert.NotNull(found);
            Assert.Equal("ABC123", found!.IdentificacionFiscal);
        }
    }
}
