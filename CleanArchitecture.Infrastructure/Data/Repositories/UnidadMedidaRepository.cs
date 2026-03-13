using CleanArchitecture.Application.Interface;
using CleanArchitecture.Domain.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Data.Repositories
{
    public class UnidadMedidaRepository : RepositoryBase<UnidadMedida>, IUnidadMedidaRepository
    {
        public UnidadMedidaRepository(ApplicationDbContext context) : base(context)
        {
        }

        public UnidadMedida? GetByCodigo(string codigo)
        {
            return _dbSet.FirstOrDefault(u => EF.Property<string>(u, "Codigo") == codigo);
        }
    }
}
