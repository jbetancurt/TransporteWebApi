
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionesXOfertasController : ControllerBase
    {
        private readonly INotificacionesXOfertasServicios _notificacionesXOfertasServicios;
        public NotificacionesXOfertasController(INotificacionesXOfertasServicios notificacionesXOfertasServicios)
        {

            _notificacionesXOfertasServicios = notificacionesXOfertasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _notificacionesXOfertasServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _notificacionesXOfertasServicios.ConsultarTodos());
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] NotificacionesXOfertas obj)
        {

            return Ok(await _notificacionesXOfertasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] NotificacionesXOfertas obj)
        {

            return Ok(await _notificacionesXOfertasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _notificacionesXOfertasServicios.Borrar(id);
            return Ok();
        }

    }
}
