using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdjuntosController : ControllerBase
    {
        private readonly IAdjuntosServicios _adjuntosServicios;
        public AdjuntosController(IAdjuntosServicios adjuntosServicios)
        {

            _adjuntosServicios = adjuntosServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _adjuntosServicios.ConsultarPorId(id));
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _adjuntosServicios.ConsultarTodos());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Adjuntos obj)
        {

            return Ok(await _adjuntosServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] Adjuntos obj)
        {

            return Ok(await _adjuntosServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _adjuntosServicios.Borrar(id);
            return Ok();
        }
    }
}
