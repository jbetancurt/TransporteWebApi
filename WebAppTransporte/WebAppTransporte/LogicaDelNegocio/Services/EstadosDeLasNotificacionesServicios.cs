
using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;


namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class EstadosDeLasNotificacionesServicios : IEstadosDeLasNotificacionesServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public EstadosDeLasNotificacionesServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(EstadosDeLasNotificaciones estadosDeLasNotificaciones)
        {
            _dbcontext.TEstadosDeLasNotificaciones.Add(estadosDeLasNotificaciones);
            await _dbcontext.SaveChangesAsync();
            return estadosDeLasNotificaciones.idEstadoDeLaNotificacion;

        }

        public async Task Borrar(long idEstadoDeLaNotificacion)
        {
            var obj = await _dbcontext.TEstadosDeLasNotificaciones.FirstOrDefaultAsync(x => x.idEstadoDeLaNotificacion == idEstadoDeLaNotificacion);
            _dbcontext.TEstadosDeLasNotificaciones.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<EstadosDeLasNotificaciones> ConsultarPorId(long idEstadoDeLaNotificacion)
        {
            var obj = await _dbcontext.TEstadosDeLasNotificaciones.FirstOrDefaultAsync(x => x.idEstadoDeLaNotificacion == idEstadoDeLaNotificacion);
            return obj == null ? new EstadosDeLasNotificaciones() : obj;
        }

        public async Task<object?> ConsultarTodos()
        {
            return await _dbcontext.TEstadosDeLasNotificaciones.ToListAsync();
        }

        public async Task<bool> Editar(long idEstadoDeLaNotificacion, EstadosDeLasNotificaciones estadosDeLasNotificaciones)
        {
            _dbcontext.TEstadosDeLasNotificaciones.Add(estadosDeLasNotificaciones);
            _dbcontext.Entry(estadosDeLasNotificaciones).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IEstadosDeLasNotificacionesServicios
    {
        Task<long> Agregar(EstadosDeLasNotificaciones estadosDeLasNotificaciones);
        Task<bool> Editar(long idEstadoDeLaNotificacion, EstadosDeLasNotificaciones estadosDeLasNotificaciones);
        Task<EstadosDeLasNotificaciones> ConsultarPorId(long idEstadoDeLaNotificacion);
        Task<object?> ConsultarTodos();
        Task Borrar(long idLugar);
    }
}