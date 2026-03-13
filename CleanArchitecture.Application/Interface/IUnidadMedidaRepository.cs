using CleanArchitecture.Domain.Entities;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Interface
{
    public interface IUnidadMedidaRepository : IRepositoryBase<UnidadMedida>
    {
        UnidadMedida? GetByCodigo(string codigo);
    }
}
