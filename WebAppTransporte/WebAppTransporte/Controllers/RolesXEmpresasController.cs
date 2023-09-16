using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesXEmpresasController : ControllerBase
    {
        private readonly IRolesXEmpresasServicios _rolesXEmpresasServicios;
        public RolesXEmpresasController(IRolesXEmpresasServicios rolesXEmpresasServicios)
        {

            _rolesXEmpresasServicios = rolesXEmpresasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _rolesXEmpresasServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _rolesXEmpresasServicios.ConsultarTodos());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RolesXEmpresas obj)
        {

            return Ok(await _rolesXEmpresasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] RolesXEmpresas obj)
        {

            return Ok(await _rolesXEmpresasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _rolesXEmpresasServicios.Borrar(id);
            return Ok();
        }
    }
}
