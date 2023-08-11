using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesplazamientosXRutasXVehiculosController : ControllerBase
    {
        private readonly IDesplazamientosXRutasXVehiculosServicios _desplazamientosXRutasXVehiculosServicios;
        public DesplazamientosXRutasXVehiculosController(IDesplazamientosXRutasXVehiculosServicios desplazamientosXRutasXVehiculosServicios)
        {

            _desplazamientosXRutasXVehiculosServicios = desplazamientosXRutasXVehiculosServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _desplazamientosXRutasXVehiculosServicios.ConsultarPorId(id));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DesplazamientosXRutasXVehiculos obj)
        {

            return Ok(await _desplazamientosXRutasXVehiculosServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] DesplazamientosXRutasXVehiculos obj)
        {

            return Ok(await _desplazamientosXRutasXVehiculosServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _desplazamientosXRutasXVehiculosServicios.Borrar(id);
            return Ok();
        }
    }
}
