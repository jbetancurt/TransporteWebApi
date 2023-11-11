using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Plantillas_RequisitosXOfertasController : ControllerBase
    {
        private readonly IPlantillas_RequisitosXOfertasServicios _plantillas_RequisitosXOfertasServicios;
        public Plantillas_RequisitosXOfertasController(IPlantillas_RequisitosXOfertasServicios plantillas_RequisitosXOfertasServicios)
        {

            _plantillas_RequisitosXOfertasServicios = plantillas_RequisitosXOfertasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _plantillas_RequisitosXOfertasServicios.ConsultarPorId(id));
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _plantillas_RequisitosXOfertasServicios.ConsultarTodos());
        }
        [HttpGet]
        [Route("consultarxoferta/{idOferta}")]
        public async Task<IActionResult> ConsultarXOferta(long idOferta)
        {

            return Ok(await _plantillas_RequisitosXOfertasServicios.ConsultarXOferta(idOferta));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Plantillas_RequisitosXOfertas obj)
        {

            return Ok(await _plantillas_RequisitosXOfertasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] Plantillas_RequisitosXOfertas obj)
        {

            return Ok(await _plantillas_RequisitosXOfertasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _plantillas_RequisitosXOfertasServicios.Borrar(id);
            return Ok();
        }

        [HttpDelete]
        [Route("borrarporidoferta/{idOferta}")]
        public async Task<IActionResult> BorrarPorIdOferta(long idOferta)
        {
            await _plantillas_RequisitosXOfertasServicios.BorrarPorIdOferta(idOferta);
            return Ok();
        }

    }
}
