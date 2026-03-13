using CleanArchitecture.Domain.Entities;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Interface
{
    public interface IProveedorRepository : IRepositoryBase<Proveedor>
    {
        Proveedor? GetByIdentificacion(string identificacion);
    }
}
