using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposDeLugaresXOfertasController : ControllerBase
    {
        private readonly ITiposDeLugaresXOfertasServicios _tiposDeLugaresXOfertasServicios;
        public TiposDeLugaresXOfertasController(ITiposDeLugaresXOfertasServicios tiposDeLugaresXOfertasServicios)
        {

            _tiposDeLugaresXOfertasServicios = tiposDeLugaresXOfertasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _tiposDeLugaresXOfertasServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _tiposDeLugaresXOfertasServicios.ConsultarTodos());
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TiposDeLugaresXOfertas obj)
        {

            return Ok(await _tiposDeLugaresXOfertasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] TiposDeLugaresXOfertas obj)
        {

            return Ok(await _tiposDeLugaresXOfertasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tiposDeLugaresXOfertasServicios.Borrar(id);
            return Ok();
        }

    }
}
