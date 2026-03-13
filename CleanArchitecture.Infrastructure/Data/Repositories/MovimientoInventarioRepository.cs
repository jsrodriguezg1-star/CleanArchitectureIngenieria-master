using CleanArchitecture.Application.Interface;
using CleanArchitecture.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Data.Repositories
{
    public class MovimientoInventarioRepository : RepositoryBase<MovimientoInventario>, IMovimientoInventarioRepository
    {
        public MovimientoInventarioRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<MovimientoInventario> GetByProducto(int productoId)
        {
            return _dbSet.Where(m => EF.Property<int>(m, "ProductoId") == productoId).ToList();
        }

        public IEnumerable<MovimientoInventario> GetByAlmacen(int almacenId)
        {
            return _dbSet.Where(m => EF.Property<int>(m, "AlmacenId") == almacenId).ToList();
        }
    }
}
