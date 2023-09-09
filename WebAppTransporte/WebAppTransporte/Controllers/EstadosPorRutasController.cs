using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosPorRutasController : ControllerBase
    {
        private readonly IEstadosPorRutasServicios _estadosPorRutasServicios;
        public EstadosPorRutasController(IEstadosPorRutasServicios estadosPorRutasServicios)
        {

            _estadosPorRutasServicios = estadosPorRutasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _estadosPorRutasServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _estadosPorRutasServicios.ConsultarTodos());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EstadosPorRutas obj)
        {

            return Ok(await _estadosPorRutasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] EstadosPorRutas obj)
        {

            return Ok(await _estadosPorRutasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _estadosPorRutasServicios.Borrar(id);
            return Ok();
        }
    }
}
