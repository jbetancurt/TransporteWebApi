using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinosXRutasXVehiculosController : ControllerBase
    {
        private readonly IDestinosXRutasXVehiculosServicios _destinosXRutasXVehiculosServicios;
        public DestinosXRutasXVehiculosController(IDestinosXRutasXVehiculosServicios destinosXRutasXVehiculosServicios)
        {

            _destinosXRutasXVehiculosServicios = destinosXRutasXVehiculosServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _destinosXRutasXVehiculosServicios.ConsultarPorId(id));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DestinosXRutasXVehiculos obj)
        {

            return Ok(await _destinosXRutasXVehiculosServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] DestinosXRutasXVehiculos obj)
        {

            return Ok(await _destinosXRutasXVehiculosServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _destinosXRutasXVehiculosServicios.Borrar(id);
            return Ok();
        }

    }
}
