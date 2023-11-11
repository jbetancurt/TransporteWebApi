using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

namespace WebAppTransporte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposDePlantillasOfertasController : ControllerBase
    {
        private readonly ITiposDePlantillasOfertasServicios _tiposDePlantillasOfertasServicios;
        public TiposDePlantillasOfertasController(ITiposDePlantillasOfertasServicios tiposDePlantillasOfertasServicios)
        {

            _tiposDePlantillasOfertasServicios = tiposDePlantillasOfertasServicios;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            return Ok(await _tiposDePlantillasOfertasServicios.ConsultarPorId(id));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _tiposDePlantillasOfertasServicios.ConsultarTodos());
        }

        [HttpGet]
        [Route("ConsultarPorEnum/{enumerador}")]
        public async Task<IActionResult> ConsultarPorEnum(string enumerador)
        {

            return Ok(await _tiposDePlantillasOfertasServicios.ConsultarPorEnum(enumerador));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TiposDePlantillasOfertas obj)
        {

            return Ok(await _tiposDePlantillasOfertasServicios.Editar(id, obj));
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] TiposDePlantillasOfertas obj)
        {

            return Ok(await _tiposDePlantillasOfertasServicios.Agregar(obj));
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tiposDePlantillasOfertasServicios.Borrar(id);
            return Ok();
        }

    }
}
