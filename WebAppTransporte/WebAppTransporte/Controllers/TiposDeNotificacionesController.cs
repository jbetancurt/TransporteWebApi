
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposDeNotificacionesController : ControllerBase
    {
        private readonly ITiposDeNotificacionesServicios _tiposDeNotificacionesServicios;
        public TiposDeNotificacionesController(ITiposDeNotificacionesServicios tiposDeNotificacionesServicios)
        {

            _tiposDeNotificacionesServicios = tiposDeNotificacionesServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _tiposDeNotificacionesServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _tiposDeNotificacionesServicios.ConsultarTodos());
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TiposDeNotificaciones obj)
        {

            return Ok(await _tiposDeNotificacionesServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] TiposDeNotificaciones obj)
        {

            return Ok(await _tiposDeNotificacionesServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tiposDeNotificacionesServicios.Borrar(id);
            return Ok();
        }

    }
}
