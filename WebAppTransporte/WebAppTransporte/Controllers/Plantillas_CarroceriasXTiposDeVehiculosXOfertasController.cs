

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Plantillas_CarroceriasXTiposDeVehiculosXOfertasController : ControllerBase
    {
        private readonly IPlantillas_CarroceriasXTiposDeVehiculosXOfertasServicios _plantillas_CarroceriasXTiposDeVehiculosXOfertasServicios;
        public Plantillas_CarroceriasXTiposDeVehiculosXOfertasController(IPlantillas_CarroceriasXTiposDeVehiculosXOfertasServicios plantillas_CarroceriasXTiposDeVehiculosXOfertasServicios)
        {

            _plantillas_CarroceriasXTiposDeVehiculosXOfertasServicios = plantillas_CarroceriasXTiposDeVehiculosXOfertasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _plantillas_CarroceriasXTiposDeVehiculosXOfertasServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _plantillas_CarroceriasXTiposDeVehiculosXOfertasServicios.ConsultarTodos());
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Plantillas_CarroceriasXTiposDeVehiculosXOfertas obj)
        {

            return Ok(await _plantillas_CarroceriasXTiposDeVehiculosXOfertasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] Plantillas_CarroceriasXTiposDeVehiculosXOfertas obj)
        {

            return Ok(await _plantillas_CarroceriasXTiposDeVehiculosXOfertasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _plantillas_CarroceriasXTiposDeVehiculosXOfertasServicios.Borrar(id);
            return Ok();
        }

    }
}
