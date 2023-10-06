
using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class EstadosDeLasOfertasServicios : IEstadosDeLasOfertasServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public EstadosDeLasOfertasServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(EstadosDeLasOfertas estadosDeLasOfertas)
        {
            _dbcontext.TEstadosDeLasOfertas.Add(estadosDeLasOfertas);
            await _dbcontext.SaveChangesAsync();
            return estadosDeLasOfertas.idEstadoDeLaOferta;

        }

        public async Task Borrar(long idEstadoDeLaOferta)
        {
            var obj = await _dbcontext.TEstadosDeLasOfertas.FirstOrDefaultAsync(x => x.idEstadoDeLaOferta == idEstadoDeLaOferta);
            _dbcontext.TEstadosDeLasOfertas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<EstadosDeLasOfertas> ConsultarPorId(long idEstadoDeLaOferta)
        {
            var obj = await _dbcontext.TEstadosDeLasOfertas.FirstOrDefaultAsync(x => x.idEstadoDeLaOferta == idEstadoDeLaOferta);
            return obj == null ? new EstadosDeLasOfertas() : obj;
        }

        public async Task<List<EstadosDeLasOfertas>> ConsultarTodos()
        {
            return await _dbcontext.TEstadosDeLasOfertas.ToListAsync();
        }

        public async Task<bool> Editar(long idEstadoDeLaOferta, EstadosDeLasOfertas estadosDeLasOfertas)
        {
            _dbcontext.TEstadosDeLasOfertas.Add(estadosDeLasOfertas);
            _dbcontext.Entry(estadosDeLasOfertas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IEstadosDeLasOfertasServicios
    {
        Task<long> Agregar(EstadosDeLasOfertas estadosDeLasOfertas);
        Task<bool> Editar(long idEstadoDeLaOferta, EstadosDeLasOfertas estadosDeLasOfertas);
        Task<EstadosDeLasOfertas> ConsultarPorId(long idEstadoDeLaOferta);
        Task<List<EstadosDeLasOfertas>> ConsultarTodos();
        Task Borrar(long idEstadoDeLaOferta);
    }
}
