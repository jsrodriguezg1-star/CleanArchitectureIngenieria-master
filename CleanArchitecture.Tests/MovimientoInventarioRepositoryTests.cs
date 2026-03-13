using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Data.Repositories;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Linq;

namespace CleanArchitecture.Tests
{
    public class MovimientoInventarioRepositoryTests
    {
        private ApplicationDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_Movimiento")
                .Options;
            return new ApplicationDbContext(options);
        }

        [Fact]
        public void GetByProducto_ReturnsMovimientos()
        {
            using var context = CreateContext();
            var repo = new MovimientoInventarioRepository(context);

            var producto = new Producto { Nombre = "P1", CategoriaId = 0, UnidadMedidaId = 0, Costo = 0, PrecioVenta = 0 };
            context.Producto.Add(producto);
            context.SaveChanges();

            var m1 = new MovimientoInventario { ProductoId = producto.Id, AlmacenId = 0, Cantidad = 1 };
            var m2 = new MovimientoInventario { ProductoId = producto.Id, AlmacenId = 0, Cantidad = -1 };
            repo.Add(m1);
            repo.Add(m2);
            repo.Save();

            var result = repo.GetByProducto(producto.Id).ToList();
            Assert.Equal(2, result.Count);
        }
    }
}
