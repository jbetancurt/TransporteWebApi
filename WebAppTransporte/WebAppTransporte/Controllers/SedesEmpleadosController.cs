using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SedesEmpleadosController : ControllerBase
    {
        private readonly ISedesEmpleadosServicios _sedesEmpleadosServicios;
        public SedesEmpleadosController(ISedesEmpleadosServicios sedesEmpleadosServicios)
        {

            _sedesEmpleadosServicios = sedesEmpleadosServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _sedesEmpleadosServicios.ConsultarPorId(id));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SedesEmpleados obj)
        {

            return Ok(await _sedesEmpleadosServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] SedesEmpleados obj)
        {

            return Ok(await _sedesEmpleadosServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _sedesEmpleadosServicios.Borrar(id);
            return Ok();
        }
    }
}
