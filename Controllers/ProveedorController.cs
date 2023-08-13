using MediatR;
using Microservicios.Domain;
using Microservicios.Proveedor.Aplicacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Microservicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProveedorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProveedorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Proveedores>>> GetProveedores()
        {
            return await _mediator.Send(new Consulta.ListaAutor());
        }
    }
}
