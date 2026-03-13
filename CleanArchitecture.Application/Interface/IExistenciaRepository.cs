using CleanArchitecture.Domain.Entities;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Interface
{
    public interface IExistenciaRepository : IRepositoryBase<Existencia>
    {
        Existencia? GetByProductoAlmacen(int productoId, int almacenId);
    }
}
