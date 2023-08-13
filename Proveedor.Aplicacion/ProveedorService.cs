using Microservicios.Domain;
using Microservicios.Infraestructura;

namespace Microservicios.Proveedor.Aplicacion
{
    public class ProveedorService
    {
        private readonly IProvedorRepository _proveedorRepository;

        public ProveedorService(IProvedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }
        public async Task<List<Proveedores>> GetAllProveedores()
        {
            return await _proveedorRepository.GetAllProveedores();
        }
    }
}
