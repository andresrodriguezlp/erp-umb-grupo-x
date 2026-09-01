using Microsoft.EntityFrameworkCore;
using ErpUmb.Api.Data;
using ErpUmb.Api.Interfaces;
using ErpUmb.Api.Models;

namespace ErpUmb.Api.Repositories
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly ComprasDbContext _context;

        public ProveedorRepository(ComprasDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Proveedor>> ObtenerTodosAsync()
        {
            return await _context.Proveedores.AsNoTracking().ToListAsync();
        }

        public async Task<Proveedor?> ObtenerPorNitAsync(string nit)
        {
            return await _context.Proveedores.FirstOrDefaultAsync(p => p.Nit == nit);
        }

        public async Task<Proveedor> CrearAsync(Proveedor proveedor)
        {
            await _context.Proveedores.AddAsync(proveedor);
            await _context.SaveChangesAsync();
            return proveedor;
        }
    }
}