using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposOrientacionesDeLaOfertaController : ControllerBase
    {
        private readonly ITiposOrientacionesDeLaOfertaServicios _tiposOrientacionesDeLaOfertaServicios;
        public TiposOrientacionesDeLaOfertaController(ITiposOrientacionesDeLaOfertaServicios tiposOrientacionesDeLaOfertaServicios)
        {

            _tiposOrientacionesDeLaOfertaServicios = tiposOrientacionesDeLaOfertaServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _tiposOrientacionesDeLaOfertaServicios.ConsultarPorId(id));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TiposOrientacionesDeLaOferta obj)
        {

            return Ok(await _tiposOrientacionesDeLaOfertaServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] TiposOrientacionesDeLaOferta obj)
        {

            return Ok(await _tiposOrientacionesDeLaOfertaServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tiposOrientacionesDeLaOfertaServicios.Borrar(id);
            return Ok();
        }

    }
}
