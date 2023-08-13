using Microservicios.Domain;
using Microservicios.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Microservicios.Infraestructura
{
    public class ProveedorRepository : IProvedorRepository
    {
        private readonly ProveedoresContext _dbContext;
        public ProveedorRepository(ProveedoresContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Proveedores>> GetAllProveedores()
        {
           return await _dbContext.proveedor.ToListAsync();
        }
    }
}
