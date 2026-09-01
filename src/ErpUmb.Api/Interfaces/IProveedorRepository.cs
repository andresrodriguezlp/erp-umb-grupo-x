using ErpUmb.Api.Models;

namespace ErpUmb.Api.Interfaces
{
    public interface IProveedorRepository
    {
        Task<IEnumerable<Proveedor>> ObtenerTodosAsync();
        Task<Proveedor?> ObtenerPorNitAsync(string nit);
        Task<Proveedor> CrearAsync(Proveedor proveedor);
    }
}