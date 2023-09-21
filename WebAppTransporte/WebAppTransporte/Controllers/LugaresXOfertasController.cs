using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LugaresXOfertasController : ControllerBase
    {
        private readonly ILugaresXOfertasServicios _lugaresXOfertasServicios;
        public LugaresXOfertasController(ILugaresXOfertasServicios lugaresXOfertasServicios)
        {

            _lugaresXOfertasServicios = lugaresXOfertasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _lugaresXOfertasServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _lugaresXOfertasServicios.ConsultarTodos());
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] LugaresXOfertas obj)
        {

            return Ok(await _lugaresXOfertasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] LugaresXOfertas obj)
        {

            return Ok(await _lugaresXOfertasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _lugaresXOfertasServicios.Borrar(id);
            return Ok();
        }

    }
}
