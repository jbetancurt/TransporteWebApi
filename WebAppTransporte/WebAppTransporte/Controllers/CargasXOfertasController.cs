using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargasXOfertasController : ControllerBase
    {
        private readonly ICargasXOfertasServicios _cargasXOfertasServicios;
        public CargasXOfertasController(ICargasXOfertasServicios cargasXOfertasServicios)
        {

            _cargasXOfertasServicios = cargasXOfertasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _cargasXOfertasServicios.ConsultarPorId(id));
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _cargasXOfertasServicios.ConsultarTodos());
        }
        [HttpGet]
        [Route("consultarxoferta/{idOferta}")]
        public async Task<IActionResult> ConsultarXOferta(long idOferta)
        {

            return Ok(await _cargasXOfertasServicios.ConsultarXOferta(idOferta));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CargasXOfertas obj)
        {

            return Ok(await _cargasXOfertasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] CargasXOfertas obj)
        {

            return Ok(await _cargasXOfertasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _cargasXOfertasServicios.Borrar(id);
            return Ok();
        }
    }
}
