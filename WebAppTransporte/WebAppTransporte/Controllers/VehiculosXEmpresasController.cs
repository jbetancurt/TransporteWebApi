using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosXEmpresasController : ControllerBase
    {
        private readonly IVehiculosXEmpresasServicios _vehiculosXEmpresasServicios;
        public VehiculosXEmpresasController(IVehiculosXEmpresasServicios vehiculosXEmpresasServicios)
        {

            _vehiculosXEmpresasServicios = vehiculosXEmpresasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _vehiculosXEmpresasServicios.ConsultarPorId(id));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] VehiculosXEmpresas obj)
        {

            return Ok(await _vehiculosXEmpresasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] VehiculosXEmpresas obj)
        {

            return Ok(await _vehiculosXEmpresasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _vehiculosXEmpresasServicios.Borrar(id);
            return Ok();
        }
    }
}
