using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposDeEmpresasController : ControllerBase
    {
        private readonly ITiposDeEmpresasServicios _tiposDeEmpresasServicios;
        public TiposDeEmpresasController(ITiposDeEmpresasServicios tiposDeEmpresasServicios)
        {

            _tiposDeEmpresasServicios = tiposDeEmpresasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _tiposDeEmpresasServicios.ConsultarPorId(id));
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TiposDeEmpresas obj)
        {

            return Ok(await _tiposDeEmpresasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] TiposDeEmpresas obj)
        {

            return Ok(await _tiposDeEmpresasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tiposDeEmpresasServicios.Borrar(id);
            return Ok();
        }

    }
}
