using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequisitosAdjuntosController : ControllerBase
    {
        private readonly IRequisitosAdjuntosServicios _requisitosAdjuntosServicios;
        public RequisitosAdjuntosController(IRequisitosAdjuntosServicios requisitosAdjuntosServicios)
        {

            _requisitosAdjuntosServicios = requisitosAdjuntosServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _requisitosAdjuntosServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _requisitosAdjuntosServicios.ConsultarTodos());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RequisitosAdjuntos obj)
        {

            return Ok(await _requisitosAdjuntosServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] RequisitosAdjuntos obj)
        {

            return Ok(await _requisitosAdjuntosServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _requisitosAdjuntosServicios.Borrar(id);
            return Ok();
        }
    }
}
