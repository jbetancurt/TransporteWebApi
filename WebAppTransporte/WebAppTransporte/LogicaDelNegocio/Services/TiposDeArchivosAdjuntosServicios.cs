using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class TiposDeArchivosAdjuntosServicios : ITiposDeArchivosAdjuntosServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public TiposDeArchivosAdjuntosServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(TiposDeArchivosAdjuntos tiposDeArchivosAdjuntos)
        {
            _dbcontext.TTiposDeArchivosAdjuntos.Add(tiposDeArchivosAdjuntos);
            await _dbcontext.SaveChangesAsync();
            return tiposDeArchivosAdjuntos.idTipoDeArchivoAdjunto;

        }

        public async Task Borrar(long idTipoDeArchivoAdjunto)
        {
            var obj = await _dbcontext.TTiposDeArchivosAdjuntos.FirstOrDefaultAsync(x => x.idTipoDeArchivoAdjunto == idTipoDeArchivoAdjunto);
            _dbcontext.TTiposDeArchivosAdjuntos.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<TiposDeArchivosAdjuntos> ConsultarPorId(long idTipoDeArchivoAdjunto)
        {
            var obj = await _dbcontext.TTiposDeArchivosAdjuntos.FirstOrDefaultAsync(x => x.idTipoDeArchivoAdjunto == idTipoDeArchivoAdjunto);
            return obj == null ? new TiposDeArchivosAdjuntos() : obj;
        }

        public async Task<bool> Editar(long idTipoDeArchivoAdjunto, TiposDeArchivosAdjuntos tiposDeArchivosAdjuntos)
        {
            _dbcontext.TTiposDeArchivosAdjuntos.Add(tiposDeArchivosAdjuntos);
            _dbcontext.Entry(tiposDeArchivosAdjuntos).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
        public async Task<List<TiposDeArchivosAdjuntos>> ConsultarTodos()
        {
            return await _dbcontext.TTiposDeArchivosAdjuntos.ToListAsync();
        }
                
    }
    public interface ITiposDeArchivosAdjuntosServicios
    {
        Task<long> Agregar(TiposDeArchivosAdjuntos tiposDeArchivosAdjuntos);
        Task<bool> Editar(long idTipoDeArchivoAdjunto, TiposDeArchivosAdjuntos tiposDeArchivosAdjuntos);
        Task<TiposDeArchivosAdjuntos> ConsultarPorId(long idTipoDeArchivoAdjunto);
        Task Borrar(long idTipoDeArchivoAdjunto);
        Task<List<TiposDeArchivosAdjuntos>> ConsultarTodos();
    }
}
