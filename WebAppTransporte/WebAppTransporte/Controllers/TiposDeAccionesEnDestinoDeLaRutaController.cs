using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposDeAccionesEnDestinoDeLaRutaController : ControllerBase
    {
        private readonly ITiposDeAccionesEnDestinoDeLaRutaServicios _tiposDeAccionesEnDestinoDeLaRutaServicios;
        public TiposDeAccionesEnDestinoDeLaRutaController(ITiposDeAccionesEnDestinoDeLaRutaServicios tiposDeAccionesEnDestinoDeLaRutaServicios)
        {

            _tiposDeAccionesEnDestinoDeLaRutaServicios = tiposDeAccionesEnDestinoDeLaRutaServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _tiposDeAccionesEnDestinoDeLaRutaServicios.ConsultarPorId(id));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TiposDeAccionesEnDestinoDeLaRuta obj)
        {

            return Ok(await _tiposDeAccionesEnDestinoDeLaRutaServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] TiposDeAccionesEnDestinoDeLaRuta obj)
        {

            return Ok(await _tiposDeAccionesEnDestinoDeLaRutaServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tiposDeAccionesEnDestinoDeLaRutaServicios.Borrar(id);
            return Ok();
        }
    }
}
