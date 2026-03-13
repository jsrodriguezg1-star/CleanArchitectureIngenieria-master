using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Data.Repositories;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CleanArchitecture.Tests
{
    public class ExistenciaRepositoryTests
    {
        private ApplicationDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_Existencia")
                .Options;
            return new ApplicationDbContext(options);
        }

        [Fact]
        public void GetByProductoAlmacen_ReturnsExistencia()
        {
            using var context = CreateContext();
            var repo = new ExistenciaRepository(context);

            var almacen = new Almacen { Nombre = "A1" };
            var producto = new Producto { Nombre = "P1", CategoriaId = 0, UnidadMedidaId = 0, Costo = 0, PrecioVenta = 0 };
            context.Almacen.Add(almacen);
            context.Producto.Add(producto);
            context.SaveChanges();

            var existencia = new Existencia { AlmacenId = almacen.Id, ProductoId = producto.Id, CantidadDisponible = 5 };
            repo.Add(existencia);
            repo.Save();

            var found = repo.GetByProductoAlmacen(producto.Id, almacen.Id);
            Assert.NotNull(found);
            Assert.Equal(5, found!.CantidadDisponible);
        }
    }
}
