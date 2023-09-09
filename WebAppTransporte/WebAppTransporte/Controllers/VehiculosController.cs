using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly IVehiculosServicios _vehiculosServicios;
        public VehiculosController(IVehiculosServicios vehiculosServicios)
        {

            _vehiculosServicios = vehiculosServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _vehiculosServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _vehiculosServicios.ConsultarTodos());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Vehiculos obj)
        {

            return Ok(await _vehiculosServicios.Editar(id, obj));
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] Vehiculos obj)
        {

            return Ok(await _vehiculosServicios.Agregar(obj));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _vehiculosServicios.Borrar(id);
            return Ok();
        }
    }
}
