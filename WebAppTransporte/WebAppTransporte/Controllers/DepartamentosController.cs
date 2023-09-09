using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly IDepartamentosServicios _departamentosServicios;
        public DepartamentosController(IDepartamentosServicios departamentosServicios)
        {

            _departamentosServicios = departamentosServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _departamentosServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("ListarDepartamentos/{idPais}")]
        public async Task<IActionResult> ListarDepartamentos(int idPais)
        {

            return Ok(await _departamentosServicios.ListarDepartamentos(idPais));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _departamentosServicios.ConsultarTodos());
        }
        
        [HttpGet]
        [Route("listarporpais/{idPais}")]
        public async Task<IActionResult> ListarPorPais(long idPais)
        {

            return Ok(await _departamentosServicios.ListarDepartamentos(idPais));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Departamentos obj)
        {

            return Ok(await _departamentosServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] Departamentos obj)
        {

            return Ok(await _departamentosServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _departamentosServicios.Borrar(id);
            return Ok();
        }
    }
}
