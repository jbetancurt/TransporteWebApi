using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialesDeLasOfertasController : ControllerBase
    {
        private readonly IHistorialesDeLasOfertasServicios _historialesDeLasOfertasServicios;
        public HistorialesDeLasOfertasController(IHistorialesDeLasOfertasServicios historialesDeLasOfertasServicios)
        {

            _historialesDeLasOfertasServicios = historialesDeLasOfertasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _historialesDeLasOfertasServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _historialesDeLasOfertasServicios.ConsultarTodos());
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] HistorialesDeLasOfertas obj)
        {

            return Ok(await _historialesDeLasOfertasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] HistorialesDeLasOfertas obj)
        {

            return Ok(await _historialesDeLasOfertasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _historialesDeLasOfertasServicios.Borrar(id);
            return Ok();
        }

    }
}
