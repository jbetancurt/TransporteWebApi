using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposDeCarroceriasController : ControllerBase
    {
        private readonly ITiposDeCarroceriasServicios _tiposDeCarroceriasServicios;
        public TiposDeCarroceriasController(ITiposDeCarroceriasServicios tiposDeCarroceriasServicios)
        {

            _tiposDeCarroceriasServicios = tiposDeCarroceriasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _tiposDeCarroceriasServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _tiposDeCarroceriasServicios.ConsultarTodos());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TiposDeCarrocerias obj)
        {

            return Ok(await _tiposDeCarroceriasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] TiposDeCarrocerias obj)
        {

            return Ok(await _tiposDeCarroceriasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tiposDeCarroceriasServicios.Borrar(id);
            return Ok();
        }

    }
}
