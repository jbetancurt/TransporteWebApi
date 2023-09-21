using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroceriasXTiposDeVehiculosXOfertasController : ControllerBase
    {
        private readonly ICarroceriasXTiposDeVehiculosXOfertasServicios _carroceriasXTiposDeVehiculosXOfertasServicios;
        public CarroceriasXTiposDeVehiculosXOfertasController(ICarroceriasXTiposDeVehiculosXOfertasServicios carroceriasXTiposDeVehiculosXOfertasServicios)
        {

            _carroceriasXTiposDeVehiculosXOfertasServicios = carroceriasXTiposDeVehiculosXOfertasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _carroceriasXTiposDeVehiculosXOfertasServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _carroceriasXTiposDeVehiculosXOfertasServicios.ConsultarTodos());
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CarroceriasXTiposDeVehiculosXOfertas obj)
        {

            return Ok(await _carroceriasXTiposDeVehiculosXOfertasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] CarroceriasXTiposDeVehiculosXOfertas obj)
        {

            return Ok(await _carroceriasXTiposDeVehiculosXOfertasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _carroceriasXTiposDeVehiculosXOfertasServicios.Borrar(id);
            return Ok();
        }

    }
}
