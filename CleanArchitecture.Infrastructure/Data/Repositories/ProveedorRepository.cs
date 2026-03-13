using CleanArchitecture.Application.Interface;
using CleanArchitecture.Domain.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Data.Repositories
{
    public class ProveedorRepository : RepositoryBase<Proveedor>, IProveedorRepository
    {
        public ProveedorRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Proveedor? GetByIdentificacion(string identificacion)
        {
            return _dbSet.FirstOrDefault(p => EF.Property<string>(p, "IdentificacionFiscal") == identificacion);
        }
    }
}
