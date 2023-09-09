using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class AdjuntosServicios : IAdjuntosServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public AdjuntosServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(Adjuntos adjuntos)
        {
            _dbcontext.TAdjuntos.Add(adjuntos);
            await _dbcontext.SaveChangesAsync();
            return adjuntos.idAdjunto;
            
        }

        public async Task Borrar(long idAdjunto)
        {
            var obj = await _dbcontext.TAdjuntos.FirstOrDefaultAsync(x => x.idAdjunto == idAdjunto);
            _dbcontext.TAdjuntos.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Adjuntos> ConsultarPorId(long idAdjunto)
        {
            var obj = await _dbcontext.TAdjuntos.FirstOrDefaultAsync(x => x.idAdjunto == idAdjunto);
            return obj == null ? new Adjuntos() : obj;
        }

        public async Task<object?> ConsultarTodos()
        {
            return await _dbcontext.TAdjuntos.ToListAsync();
        }

        public async Task<bool> Editar(long idAdjunto, Adjuntos adjuntos)
        {
            _dbcontext.TAdjuntos.Add(adjuntos);
            _dbcontext.Entry(adjuntos).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IAdjuntosServicios
    {
        Task<long> Agregar(Adjuntos adjuntos);
        Task<bool> Editar(long idAdjunto, Adjuntos adjuntos);
        Task<Adjuntos> ConsultarPorId(long idAdjunto);
        Task<object?> ConsultarTodos();
        Task Borrar(long idAdjunto);
    }
}
