using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Interface
{
    public interface IProductoRepository : IRepositoryBase<Producto>
    {
        IEnumerable<Producto> GetByCategoria(int categoriaId);
        Producto? GetByNombre(string nombre);
    }
}
