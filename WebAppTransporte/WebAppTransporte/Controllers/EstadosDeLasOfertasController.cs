
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosDeLasOfertasController : ControllerBase
    {
        private readonly IEstadosDeLasOfertasServicios _estadosDeLasOfertasServicios;
        public EstadosDeLasOfertasController(IEstadosDeLasOfertasServicios estadosDeLasOfertasServicios)
        {

            _estadosDeLasOfertasServicios = estadosDeLasOfertasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _estadosDeLasOfertasServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _estadosDeLasOfertasServicios.ConsultarTodos());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EstadosDeLasOfertas obj)
        {

            return Ok(await _estadosDeLasOfertasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] EstadosDeLasOfertas obj)
        {

            return Ok(await _estadosDeLasOfertasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _estadosDeLasOfertasServicios.Borrar(id);
            return Ok();
        }
    }
}
