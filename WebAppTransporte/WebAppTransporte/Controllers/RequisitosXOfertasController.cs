using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequisitosXOfertasController : ControllerBase
    {
        private readonly IRequisitosXOfertasServicios _requisitosXOfertasServicios;
        public RequisitosXOfertasController(IRequisitosXOfertasServicios requisitosXOfertasServicios)
        {

            _requisitosXOfertasServicios = requisitosXOfertasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _requisitosXOfertasServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _requisitosXOfertasServicios.ConsultarTodos());
        }

        [HttpGet]
        [Route("consultarxoferta/{idOferta}")]
        public async Task<IActionResult> ConsultarXOferta(long idOferta)
        {

            return Ok(await _requisitosXOfertasServicios.ConsultarXOferta(idOferta));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RequisitosXOfertas obj)
        {

            return Ok(await _requisitosXOfertasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] RequisitosXOfertas obj)
        {

            return Ok(await _requisitosXOfertasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _requisitosXOfertasServicios.Borrar(id);
            return Ok();
        }

        [HttpDelete]
        [Route("borrarporidoferta/{idOferta}")]
        public async Task<IActionResult> BorrarPorIdOferta(long idOferta)
        {
            await _requisitosXOfertasServicios.BorrarPorIdOferta(idOferta);
            return Ok();
        }

    }
}
