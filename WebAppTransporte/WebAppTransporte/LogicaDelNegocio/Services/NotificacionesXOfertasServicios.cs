

using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;


namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class NotificacionesXOfertasServicios : INotificacionesXOfertasServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public NotificacionesXOfertasServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(NotificacionesXOfertas notificacionesXOfertas)
        {
            _dbcontext.TNotificacionesXOfertas.Add(notificacionesXOfertas);
            await _dbcontext.SaveChangesAsync();
            return notificacionesXOfertas.idNotificacionXOferta;

        }

        public async Task Borrar(long idNotificacionXOferta)
        {
            var obj = await _dbcontext.TNotificacionesXOfertas.FirstOrDefaultAsync(x => x.idNotificacionXOferta == idNotificacionXOferta);
            _dbcontext.TNotificacionesXOfertas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<NotificacionesXOfertas> ConsultarPorId(long idNotificacionXOferta)
        {
            var obj = await _dbcontext.TNotificacionesXOfertas.FirstOrDefaultAsync(x => x.idNotificacionXOferta == idNotificacionXOferta);
            return obj == null ? new NotificacionesXOfertas() : obj;
        }

        public async Task<object?> ConsultarTodos()
        {
            return await _dbcontext.TNotificacionesXOfertas.ToListAsync();
        }

        public async Task<bool> Editar(long idNotificacionXOferta, NotificacionesXOfertas notificacionesXOfertas)
        {
            _dbcontext.TNotificacionesXOfertas.Add(notificacionesXOfertas);
            _dbcontext.Entry(notificacionesXOfertas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface INotificacionesXOfertasServicios
    {
        Task<long> Agregar(NotificacionesXOfertas notificacionesXOfertas);
        Task<bool> Editar(long idNotificacionXOferta, NotificacionesXOfertas notificacionesXOfertas);
        Task<NotificacionesXOfertas> ConsultarPorId(long idNotificacionXOferta);
        Task<object?> ConsultarTodos();
        Task Borrar(long idLugar);
    }
}