using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolXUsuariosController : ControllerBase
    {
        private readonly IRolXUsuariosServicios _rolXUsuariosServicios;
        public RolXUsuariosController(IRolXUsuariosServicios rolXUsuariosServicios)
        {

            _rolXUsuariosServicios = rolXUsuariosServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _rolXUsuariosServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _rolXUsuariosServicios.ConsultarTodos());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RolXUsuarios obj)
        {

            return Ok(await _rolXUsuariosServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] RolXUsuarios obj)
        {

            return Ok(await _rolXUsuariosServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _rolXUsuariosServicios.Borrar(id);
            return Ok();
        }
    }
}
