using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfertasController : ControllerBase
    {
        private readonly IOfertasServicios _ofertasServicios;
        public OfertasController(IOfertasServicios ofertasServicios)
        {

            _ofertasServicios = ofertasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _ofertasServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ofertasServicios.ConsultarTodos());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Ofertas obj)
        {

            return Ok(await _ofertasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] Ofertas obj)
        {

            return Ok(await _ofertasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _ofertasServicios.Borrar(id);
            return Ok();
        }
    }
}
