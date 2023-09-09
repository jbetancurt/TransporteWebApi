using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class DestinosServicios : IDestinosServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public DestinosServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(Destinos destinos)
        {
            _dbcontext.TDestinos.Add(destinos);
            await _dbcontext.SaveChangesAsync();
            return destinos.idDestino;
            
        }

        public async Task Borrar(long idDestino)
        {
            var obj = await _dbcontext.TDestinos.FirstOrDefaultAsync(x => x.idDestino == idDestino);
            _dbcontext.TDestinos.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Destinos> ConsultarPorId(long idDestino)
        {
            var obj = await _dbcontext.TDestinos.FirstOrDefaultAsync(x => x.idDestino == idDestino);
            return obj == null ? new Destinos() : obj;
        }

        public async Task<object?> ConsultarTodos()
        {
            return await _dbcontext.TDestinos.ToListAsync();
        }

        public async Task<bool> Editar(long idDestino, Destinos destinos)
        {
            _dbcontext.TDestinos.Add(destinos);
            _dbcontext.Entry(destinos).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IDestinosServicios
    {
        Task<long> Agregar(Destinos destinos);
        Task<bool> Editar(long idDestino, Destinos destinos);
        Task<Destinos> ConsultarPorId(long idDestino);
        Task<object?> ConsultarTodos();
        Task Borrar(long idDestino);
    }
}
