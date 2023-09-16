using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequisitosXOfertasController : ControllerBase
    {
        private readonly IRequisitosXOfertasServicios _requisitosXOfertasServicios;
        public RequisitosXOfertasController(IRequisitosXOfertasServicios requisitosXOfertasServicios)
        {

            _requisitosXOfertasServicios = requisitosXOfertasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _requisitosXOfertasServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _requisitosXOfertasServicios.ConsultarTodos());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RequisitosXOfertas obj)
        {

            return Ok(await _requisitosXOfertasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] RequisitosXOfertas obj)
        {

            return Ok(await _requisitosXOfertasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _requisitosXOfertasServicios.Borrar(id);
            return Ok();
        }
    }
}
