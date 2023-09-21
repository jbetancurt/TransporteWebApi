
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosDeLasNotificacionesController : ControllerBase
    {
        private readonly IEstadosDeLasNotificacionesServicios _estadosDeLasNotificacionesServicios;
        public EstadosDeLasNotificacionesController(IEstadosDeLasNotificacionesServicios estadosDeLasNotificacionesServicios)
        {

            _estadosDeLasNotificacionesServicios = estadosDeLasNotificacionesServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _estadosDeLasNotificacionesServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _estadosDeLasNotificacionesServicios.ConsultarTodos());
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EstadosDeLasNotificaciones obj)
        {

            return Ok(await _estadosDeLasNotificacionesServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] EstadosDeLasNotificaciones obj)
        {

            return Ok(await _estadosDeLasNotificacionesServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _estadosDeLasNotificacionesServicios.Borrar(id);
            return Ok();
        }

    }
}
