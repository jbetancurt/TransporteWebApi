using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccesosControlXPuntosController : ControllerBase
    {
        private readonly IAccesosControlXPuntosServicios _accesosControlXPuntosServicios;
        public AccesosControlXPuntosController(IAccesosControlXPuntosServicios accesosControlXPuntosServicios)
        {

            _accesosControlXPuntosServicios = accesosControlXPuntosServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _accesosControlXPuntosServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _accesosControlXPuntosServicios.ConsultarTodos());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AccesosControlXPuntos obj)
        {

            return Ok(await _accesosControlXPuntosServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] AccesosControlXPuntos obj)
        {

            return Ok(await _accesosControlXPuntosServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _accesosControlXPuntosServicios.Borrar(id);
            return Ok();
        }
    }
}
