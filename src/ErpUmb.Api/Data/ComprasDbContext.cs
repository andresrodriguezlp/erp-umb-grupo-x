using Microsoft.EntityFrameworkCore;
using ErpUmb.Api.Models;

namespace ErpUmb.Api.Data
{
    public class ComprasDbContext : DbContext
    {
        public ComprasDbContext(DbContextOptions<ComprasDbContext> options) : base(options) { }

        public DbSet<Proveedor> Proveedores => Set<Proveedor>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Proveedor>()
                .HasIndex(p => p.Nit)
                .IsUnique();
        }
    }
}