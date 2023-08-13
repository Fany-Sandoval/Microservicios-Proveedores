using Microservicios.Domain;
using Microsoft.EntityFrameworkCore;

namespace Microservicios.Persistencia
{
    public class ProveedoresContext : DbContext
    {
        public ProveedoresContext(DbContextOptions<ProveedoresContext> options) : base(options)
        {
        }
        public DbSet<Proveedores> proveedor { get; set; }

        // Otros DbSets para otras entidades de dominio

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuraciones de mapeo de entidades
            modelBuilder.Entity<Proveedores>()
               .HasKey(p => p.Id_proveedor); // Aquí defines la clave primaria (suponiendo que hay una propiedad 'Id' en la entidad 'Proveedores')

            // Otros mapeos y configuraciones de entidades

            base.OnModelCreating(modelBuilder);
        }

    }
}

