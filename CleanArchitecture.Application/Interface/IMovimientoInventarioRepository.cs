using CleanArchitecture.Domain.Entities;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Interface
{
    public interface IMovimientoInventarioRepository : IRepositoryBase<MovimientoInventario>
    {
        IEnumerable<MovimientoInventario> GetByProducto(int productoId);
        IEnumerable<MovimientoInventario> GetByAlmacen(int almacenId);
    }
}
