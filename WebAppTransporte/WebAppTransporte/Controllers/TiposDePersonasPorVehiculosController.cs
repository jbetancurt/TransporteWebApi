using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposDePersonasPorVehiculosController : ControllerBase
    {
        private readonly ITiposDePersonasPorVehiculosServicios _tiposDePersonasPorVehiculosServicios;
        public TiposDePersonasPorVehiculosController(ITiposDePersonasPorVehiculosServicios tiposDePersonasPorVehiculosServicios)
        {

            _tiposDePersonasPorVehiculosServicios = tiposDePersonasPorVehiculosServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _tiposDePersonasPorVehiculosServicios.ConsultarPorId(id));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TiposDePersonasPorVehiculos obj)
        {

            return Ok(await _tiposDePersonasPorVehiculosServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] TiposDePersonasPorVehiculos obj)
        {

            return Ok(await _tiposDePersonasPorVehiculosServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tiposDePersonasPorVehiculosServicios.Borrar(id);
            return Ok();
        }

    }
}
