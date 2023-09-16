using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostuladosXOfertasController : ControllerBase
    {
        private readonly IPostuladosXOfertasServicios _postuladosXOfertasServicios;
        public PostuladosXOfertasController(IPostuladosXOfertasServicios postuladosXOfertasServicios)
        {

            _postuladosXOfertasServicios = postuladosXOfertasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _postuladosXOfertasServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _postuladosXOfertasServicios.ConsultarTodos());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PostuladosXOfertas obj)
        {

            return Ok(await _postuladosXOfertasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] PostuladosXOfertas obj)
        {

            return Ok(await _postuladosXOfertasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _postuladosXOfertasServicios.Borrar(id);
            return Ok();
        }
    }
}
