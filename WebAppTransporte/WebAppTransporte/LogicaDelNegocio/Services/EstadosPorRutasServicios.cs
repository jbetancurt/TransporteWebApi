using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class EstadosPorRutasServicios : IEstadosPorRutasServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public EstadosPorRutasServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(EstadosPorRutas estadosporrutas)
        {
            _dbcontext.TEstadosPorRutas.Add(estadosporrutas);
            await _dbcontext.SaveChangesAsync();
            return estadosporrutas.idEstadoPorRuta;
            
        }

        public async Task Borrar(long idEstadoPorRuta)
        {
            var obj = await _dbcontext.TEstadosPorRutas.FirstOrDefaultAsync(x => x.idEstadoPorRuta == idEstadoPorRuta);
            _dbcontext.TEstadosPorRutas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<EstadosPorRutas> ConsultarPorId(long idEstadoPorRuta)
        {
            var obj = await _dbcontext.TEstadosPorRutas.FirstOrDefaultAsync(x => x.idEstadoPorRuta == idEstadoPorRuta);
            return obj == null ? new EstadosPorRutas() : obj;
        }

        public async Task<bool> Editar(long idEstadoPorRuta, EstadosPorRutas estadosporrutas)
        {
            _dbcontext.TEstadosPorRutas.Add(estadosporrutas);
            _dbcontext.Entry(estadosporrutas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public  interface IEstadosPorRutasServicios
    {
        Task<long> Agregar(EstadosPorRutas estadosporrutas);
        Task<bool> Editar(long idEstadoPorRuta, EstadosPorRutas estadosporrutas);
        Task<EstadosPorRutas> ConsultarPorId(long idEstadoPorRuta);
        Task Borrar(long idEstadoPorRuta);
    }
}
