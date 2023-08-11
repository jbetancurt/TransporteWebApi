using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinosXEmpresasController : ControllerBase
    {
        private readonly IDestinosXEmpresasServicios _destinosXEmpresasServicios;
        public DestinosXEmpresasController(IDestinosXEmpresasServicios destinosXEmpresasServicios)
        {

            _destinosXEmpresasServicios = destinosXEmpresasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _destinosXEmpresasServicios.ConsultarPorId(id));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DestinosXEmpresas obj)
        {

            return Ok(await _destinosXEmpresasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] DestinosXEmpresas obj)
        {

            return Ok(await _destinosXEmpresasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _destinosXEmpresasServicios.Borrar(id);
            return Ok();
        }
    }
}
