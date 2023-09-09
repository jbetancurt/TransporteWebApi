using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadesController : ControllerBase
    {
        private readonly ICiudadesServicios _ciudadesServicios;
        public CiudadesController(ICiudadesServicios ciudadesServicios)
        {

            _ciudadesServicios = ciudadesServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _ciudadesServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ciudadesServicios.ConsultarTodos());
        }

        [HttpGet]
        [Route("ListarCiudades/{idDepartamento}")]
        public async Task<IActionResult> ListarCiudades(int idDepartamento)
        {

            return Ok(await _ciudadesServicios.ListarCiudades(idDepartamento));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Ciudades obj)
        {

            return Ok(await _ciudadesServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] Ciudades obj)
        {

            return Ok(await _ciudadesServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _ciudadesServicios.Borrar(id);
            return Ok();
        }
    }
}
