using Microsoft.AspNetCore.Mvc;
using ErpUmb.Api.Interfaces;
using ErpUmb.Api.Models;

namespace ErpUmb.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProveedoresController : ControllerBase
    {
        private readonly IProveedorRepository _repository;

        public ProveedoresController(IProveedorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var proveedores = await _repository.ObtenerTodosAsync();
            return Ok(proveedores);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Proveedor model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existe = await _repository.ObtenerPorNitAsync(model.Nit);
            if (existe != null)
                return Conflict(new { mensaje = "El NIT ingresado ya se encuentra registrado." });

            var nuevo = await _repository.CrearAsync(model);
            return StatusCode(StatusCodes.Status201Created, nuevo);
        }
    }
}