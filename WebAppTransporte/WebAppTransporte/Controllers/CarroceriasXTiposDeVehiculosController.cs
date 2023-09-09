using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroceriasXTiposDeVehiculosController : ControllerBase
    {
        private readonly ICarroceriasXTiposDeVehiculosServicios _carroceriasXTiposDeVehiculosServicios;
        public CarroceriasXTiposDeVehiculosController(ICarroceriasXTiposDeVehiculosServicios carroceriasXTiposDeVehiculosServicios)
        {

            _carroceriasXTiposDeVehiculosServicios = carroceriasXTiposDeVehiculosServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _carroceriasXTiposDeVehiculosServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _carroceriasXTiposDeVehiculosServicios.ConsultarTodos());
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CarroceriasXTiposDeVehiculos obj)
        {

            return Ok(await _carroceriasXTiposDeVehiculosServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] CarroceriasXTiposDeVehiculos obj)
        {

            return Ok(await _carroceriasXTiposDeVehiculosServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _carroceriasXTiposDeVehiculosServicios.Borrar(id);
            return Ok();
        }

    }
}
