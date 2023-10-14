
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Plantillas_LugaresXOfertasController : ControllerBase
    {
        private readonly IPlantillas_LugaresXOfertasServicios _plantillas_LugaresXOfertasServicios;
        public Plantillas_LugaresXOfertasController(IPlantillas_LugaresXOfertasServicios plantillas_LugaresXOfertasServicios)
        {

            _plantillas_LugaresXOfertasServicios = plantillas_LugaresXOfertasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _plantillas_LugaresXOfertasServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _plantillas_LugaresXOfertasServicios.ConsultarTodos());
        }

        [HttpGet]
        [Route("consultarxoferta/{idOferta}/{idTipoDeLugarXOferta}")]
        public async Task<IActionResult> ConsultarXOferta(long idOferta, long idTipoDeLugarXOferta)
        {

            return Ok(await _plantillas_LugaresXOfertasServicios.ConsultarXOferta(idOferta, idTipoDeLugarXOferta));
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Plantillas_LugaresXOfertas obj)
        {

            return Ok(await _plantillas_LugaresXOfertasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] Plantillas_LugaresXOfertas obj)
        {

            return Ok(await _plantillas_LugaresXOfertasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _plantillas_LugaresXOfertasServicios.Borrar(id);
            return Ok();
        }

    }
}
