using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposDeDocumentosController : ControllerBase
    {
        private readonly ITiposDeDocumentosServicios _tiposDeDocumentosServicios;
        public TiposDeDocumentosController(ITiposDeDocumentosServicios tiposDeDocumentosServicios)
        {

            _tiposDeDocumentosServicios = tiposDeDocumentosServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _tiposDeDocumentosServicios.ConsultarPorId(id));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TiposDeDocumentos obj)
        {

            return Ok(await _tiposDeDocumentosServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] TiposDeDocumentos obj)
        {

            return Ok(await _tiposDeDocumentosServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tiposDeDocumentosServicios.Borrar(id);
            return Ok();
        }
    }
}
