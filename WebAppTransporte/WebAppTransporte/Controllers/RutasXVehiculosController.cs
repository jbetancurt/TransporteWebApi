using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutasXVehiculosController : ControllerBase
    {
        private readonly IRutasXVehiculosServicios _rutasXVehiculosServicios;
        public RutasXVehiculosController(IRutasXVehiculosServicios rutasXVehiculosServicios)
        {

            _rutasXVehiculosServicios = rutasXVehiculosServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _rutasXVehiculosServicios.ConsultarPorId(id));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RutasXVehiculos obj)
        {

            return Ok(await _rutasXVehiculosServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] RutasXVehiculos obj)
        {

            return Ok(await _rutasXVehiculosServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _rutasXVehiculosServicios.Borrar(id);
            return Ok();
        }
    }
}
