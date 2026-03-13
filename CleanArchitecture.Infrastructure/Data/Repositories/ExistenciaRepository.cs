using CleanArchitecture.Application.Interface;
using CleanArchitecture.Domain.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Data.Repositories
{
    public class ExistenciaRepository : RepositoryBase<Existencia>, IExistenciaRepository
    {
        public ExistenciaRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Existencia? GetByProductoAlmacen(int productoId, int almacenId)
        {
            return _dbSet.FirstOrDefault(e => EF.Property<int>(e, "ProductoId") == productoId && EF.Property<int>(e, "AlmacenId") == almacenId);
        }
    }
}
