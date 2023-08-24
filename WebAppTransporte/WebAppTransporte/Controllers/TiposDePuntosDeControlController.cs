using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposDePuntosDeControlController : ControllerBase
    {
        private readonly ITiposDePuntosDeControlServicios _tiposDePuntosDeControlServicios;
        public TiposDePuntosDeControlController(ITiposDePuntosDeControlServicios tiposDePuntosDeControlServicios)
        {

            _tiposDePuntosDeControlServicios = tiposDePuntosDeControlServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _tiposDePuntosDeControlServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _tiposDePuntosDeControlServicios.ConsultarTodos());
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TiposDePuntosDeControl obj)
        {

            return Ok(await _tiposDePuntosDeControlServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] TiposDePuntosDeControl obj)
        {

            return Ok(await _tiposDePuntosDeControlServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tiposDePuntosDeControlServicios.Borrar(id);
            return Ok();
        }

    }
}
