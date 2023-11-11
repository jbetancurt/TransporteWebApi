using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LugaresXOfertasController : ControllerBase
    {
        private readonly ILugaresXOfertasServicios _lugaresXOfertasServicios;
        public LugaresXOfertasController(ILugaresXOfertasServicios lugaresXOfertasServicios)
        {

            _lugaresXOfertasServicios = lugaresXOfertasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _lugaresXOfertasServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _lugaresXOfertasServicios.ConsultarTodos());
        }

        [HttpGet]
        [Route("consultarxoferta/{idOferta}/{idTipoDeLugarXOferta}")]
        public async Task<IActionResult> ConsultarXOferta(long idOferta, long idTipoDeLugarXOferta)
        {

            return Ok(await _lugaresXOfertasServicios.ConsultarXOferta(idOferta, idTipoDeLugarXOferta));
        }



        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] LugaresXOfertas obj)
        {

            return Ok(await _lugaresXOfertasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] LugaresXOfertas obj)
        {

            return Ok(await _lugaresXOfertasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _lugaresXOfertasServicios.Borrar(id);
            return Ok();
        }

        [HttpDelete]
        [Route("borrarporidoferta/{idOferta}")]
        public async Task<IActionResult> BorrarPorIdOferta(long idOferta)
        {
            await _lugaresXOfertasServicios.BorrarPorIdOferta(idOferta);
            return Ok();
        }

    }
}
