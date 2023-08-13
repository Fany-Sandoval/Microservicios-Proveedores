using AutoMapper;
using MediatR;
using Microservicios.Domain;
using Microservicios.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Microservicios.Proveedor.Aplicacion
{
    public class Consulta
    {
        //devuekve la clase
        public class ListaAutor : IRequest<List<Proveedores>>
        {

        }
        //recibe ListaAutor y regresa una lista de Proveedores
        public class Manejador : IRequestHandler<ListaAutor, List<Proveedores>>
        {
            private readonly ProveedoresContext _context;
           

            public Manejador(ProveedoresContext context)
            {
                this._context = context;
              
            }
            public async Task<List<Proveedores>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                var autores = await _context.proveedor.ToListAsync();
                //var autoresDto = _mapper.Map<List<Proveedores>, List<Proveedores>>(autores);
                return autores;
            }

        }
    }
}
