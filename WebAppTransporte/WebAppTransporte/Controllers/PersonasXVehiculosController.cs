using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasXVehiculosController : ControllerBase
    {
        private readonly IPersonasXVehiculosServicios _personasXVehiculosServicios;
        public PersonasXVehiculosController(IPersonasXVehiculosServicios personasXVehiculosServicios)
        {

            _personasXVehiculosServicios = personasXVehiculosServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _personasXVehiculosServicios.ConsultarPorId(id));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PersonasXVehiculos obj)
        {

            return Ok(await _personasXVehiculosServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] PersonasXVehiculos obj)
        {

            return Ok(await _personasXVehiculosServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _personasXVehiculosServicios.Borrar(id);
            return Ok();
        }
    }
}
