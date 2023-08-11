using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Plantillas_OfertasController : ControllerBase
    {
        private readonly IPlantillas_OfertasServicios _plantillas_OfertasServicios;
        public Plantillas_OfertasController(IPlantillas_OfertasServicios plantillas_OfertasServicios)
        {

            _plantillas_OfertasServicios = plantillas_OfertasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _plantillas_OfertasServicios.ConsultarPorId(id));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Plantillas_Ofertas obj)
        {

            return Ok(await _plantillas_OfertasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] Plantillas_Ofertas obj)
        {

            return Ok(await _plantillas_OfertasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _plantillas_OfertasServicios.Borrar(id);
            return Ok();
        }
    }
}
