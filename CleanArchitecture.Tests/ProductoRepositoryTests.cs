using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Data.Repositories;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace CleanArchitecture.Tests
{
    public class ProductoRepositoryTests
    {
        private ApplicationDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_Producto")
                .Options;
            return new ApplicationDbContext(options);
        }

        [Fact]
        public void GetByCategoria_ReturnsProductos()
        {
            using var context = CreateContext();
            var repo = new ProductoRepository(context);

            var categoria = new Categoria { Name = "Cat1" };
            context.Categoria.Add(categoria);
            context.SaveChanges();

            var p1 = new Producto { Nombre = "P1", CategoriaId = categoria.Id, UnidadMedidaId = 0, Costo = 0, PrecioVenta = 0 };
            var p2 = new Producto { Nombre = "P2", CategoriaId = categoria.Id, UnidadMedidaId = 0, Costo = 0, PrecioVenta = 0 };
            repo.Add(p1);
            repo.Add(p2);
            repo.Save();

            var result = repo.GetByCategoria(categoria.Id).ToList();
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetByNombre_ReturnsProducto()
        {
            using var context = CreateContext();
            var repo = new ProductoRepository(context);

            var producto = new Producto { Nombre = "UniqueName", CategoriaId = 0, UnidadMedidaId = 0, Costo = 0, PrecioVenta = 0 };
            repo.Add(producto);
            repo.Save();

            var found = repo.GetByNombre("UniqueName");
            Assert.NotNull(found);
            Assert.Equal("UniqueName", found!.Nombre);
        }
    }
}
