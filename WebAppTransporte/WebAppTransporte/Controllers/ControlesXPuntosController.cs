using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControlesXPuntosController : ControllerBase
    {
        private readonly IControlesXPuntosServicios _controlesXPuntosServicios;
        public ControlesXPuntosController(IControlesXPuntosServicios controlesXPuntosServicios)
        {

            _controlesXPuntosServicios = controlesXPuntosServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _controlesXPuntosServicios.ConsultarPorId(id));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ControlesXPuntos obj)
        {

            return Ok(await _controlesXPuntosServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] ControlesXPuntos obj)
        {

            return Ok(await _controlesXPuntosServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _controlesXPuntosServicios.Borrar(id);
            return Ok();
        }
    }
}
