

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Plantillas_CargasXOfertasController : ControllerBase
    {
        private readonly IPlantillas_CargasXOfertasServicios _plantillas_CargasXOfertasServicios;
        public Plantillas_CargasXOfertasController(IPlantillas_CargasXOfertasServicios plantillas_CargasXOfertasServicios)
        {

            _plantillas_CargasXOfertasServicios = plantillas_CargasXOfertasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _plantillas_CargasXOfertasServicios.ConsultarPorId(id));
        }
       
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _plantillas_CargasXOfertasServicios.ConsultarTodos());
        }
        
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Plantillas_CargasXOfertas obj)
        {

            return Ok(await _plantillas_CargasXOfertasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] Plantillas_CargasXOfertas obj)
        {

            return Ok(await _plantillas_CargasXOfertasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _plantillas_CargasXOfertasServicios.Borrar(id);
            return Ok();
        }
    }
}
