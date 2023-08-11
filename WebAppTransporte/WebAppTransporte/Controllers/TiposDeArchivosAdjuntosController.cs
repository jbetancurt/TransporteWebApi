using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposDeArchivosAdjuntosController : ControllerBase
    {
        private readonly ITiposDeArchivosAdjuntosServicios _tiposDeArchivosAdjuntosServicios;
        public TiposDeArchivosAdjuntosController(ITiposDeArchivosAdjuntosServicios tiposDeArchivosAdjuntosServicios)
        {

            _tiposDeArchivosAdjuntosServicios = tiposDeArchivosAdjuntosServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _tiposDeArchivosAdjuntosServicios.ConsultarPorId(id));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TiposDeArchivosAdjuntos obj)
        {

            return Ok(await _tiposDeArchivosAdjuntosServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] TiposDeArchivosAdjuntos obj)
        {

            return Ok(await _tiposDeArchivosAdjuntosServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tiposDeArchivosAdjuntosServicios.Borrar(id);
            return Ok();
        }
    }
}
