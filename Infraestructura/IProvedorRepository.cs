using Microservicios.Domain;

namespace Microservicios.Infraestructura
{
    public interface IProvedorRepository
    {
        Task<List<Proveedores>> GetAllProveedores();
    }
}
