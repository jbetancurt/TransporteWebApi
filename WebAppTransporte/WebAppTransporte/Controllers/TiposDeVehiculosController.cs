using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposDeVehiculosController : ControllerBase
    {
        private readonly ITiposDeVehiculosServicios _tiposDeVehiculosServicios;
        public TiposDeVehiculosController(ITiposDeVehiculosServicios tiposDeVehiculosServicios)
        {

            _tiposDeVehiculosServicios = tiposDeVehiculosServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _tiposDeVehiculosServicios.ConsultarPorId(id));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TiposDeVehiculos obj)
        {

            return Ok(await _tiposDeVehiculosServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] TiposDeVehiculos obj)
        {

            return Ok(await _tiposDeVehiculosServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tiposDeVehiculosServicios.Borrar(id);
            return Ok();
        }

    }
}
