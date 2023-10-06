

using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class TiposDeNotificacionesServicios : ITiposDeNotificacionesServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public TiposDeNotificacionesServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(TiposDeNotificaciones tiposDeNotificaciones)
        {
            _dbcontext.TTiposDeNotificaciones.Add(tiposDeNotificaciones);
            await _dbcontext.SaveChangesAsync();
            return tiposDeNotificaciones.idTipoDeNotificacion;

        }

        public async Task Borrar(long idTipoDeNotificacion)
        {
            var obj = await _dbcontext.TTiposDeNotificaciones.FirstOrDefaultAsync(x => x.idTipoDeNotificacion == idTipoDeNotificacion);
            _dbcontext.TTiposDeNotificaciones.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<TiposDeNotificaciones> ConsultarPorId(long idTipoDeNotificacion)
        {
            var obj = await _dbcontext.TTiposDeNotificaciones.FirstOrDefaultAsync(x => x.idTipoDeNotificacion == idTipoDeNotificacion);
            return obj == null ? new TiposDeNotificaciones() : obj;
        }

        public async Task<bool> Editar(long idTipoDeNotificacion, TiposDeNotificaciones tiposDeNotificaciones)
        {
            _dbcontext.TTiposDeNotificaciones.Add(tiposDeNotificaciones);
            _dbcontext.Entry(tiposDeNotificaciones).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<List<TiposDeNotificaciones>> ConsultarTodos()
        {
            return await _dbcontext.TTiposDeNotificaciones.ToListAsync();
        }
    }
    public interface ITiposDeNotificacionesServicios
    {
        Task<long> Agregar(TiposDeNotificaciones tiposDeNotificaciones);
        Task<bool> Editar(long idTipoDeNotificacion, TiposDeNotificaciones tiposDeNotificaciones);
        Task<TiposDeNotificaciones> ConsultarPorId(long idTipoDeNotificacion);
        Task Borrar(long idTipoDeNotificacion);
        Task<List<TiposDeNotificaciones>> ConsultarTodos();
    }
}
