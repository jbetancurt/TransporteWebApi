using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposDeRolesController : ControllerBase
    {
        private readonly ITiposDeRolesServicios _tiposDeRolesServicios;
        public TiposDeRolesController(ITiposDeRolesServicios tiposDeRolesServicios)
        {

            _tiposDeRolesServicios = tiposDeRolesServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _tiposDeRolesServicios.ConsultarPorId(id));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TiposDeRoles obj)
        {

            return Ok(await _tiposDeRolesServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] TiposDeRoles obj)
        {

            return Ok(await _tiposDeRolesServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tiposDeRolesServicios.Borrar(id);
            return Ok();
        }

    }
}
