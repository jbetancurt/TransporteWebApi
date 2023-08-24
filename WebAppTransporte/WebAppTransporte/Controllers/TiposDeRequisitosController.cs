using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposDeRequisitosController : ControllerBase
    {
        private readonly ITiposDeRequisitosServicios _tiposDeRequisitosServicios;
        public TiposDeRequisitosController(ITiposDeRequisitosServicios tiposDeRequisitosServicios)
        {

            _tiposDeRequisitosServicios = tiposDeRequisitosServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _tiposDeRequisitosServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _tiposDeRequisitosServicios.ConsultarTodos());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TiposDeRequisitos obj)
        {

            return Ok(await _tiposDeRequisitosServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] TiposDeRequisitos obj)
        {

            return Ok(await _tiposDeRequisitosServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tiposDeRequisitosServicios.Borrar(id);
            return Ok();
        }

    }
}
