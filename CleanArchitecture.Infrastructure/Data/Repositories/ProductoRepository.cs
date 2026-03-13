using CleanArchitecture.Application.Interface;
using CleanArchitecture.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Data.Repositories
{
    public class ProductoRepository : RepositoryBase<Producto>, IProductoRepository
    {
        public ProductoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Producto> GetByCategoria(int categoriaId)
        {
            return _dbSet.Where(p => EF.Property<int>(p, "CategoriaId") == categoriaId).ToList();
        }

        public Producto? GetByNombre(string nombre)
        {
            return _dbSet.FirstOrDefault(p => EF.Property<string>(p, "Nombre") == nombre);
        }
    }
}
