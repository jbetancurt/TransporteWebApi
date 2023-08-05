using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class TiposDeDocumentosServicios : ITiposDeDocumentosServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public TiposDeDocumentosServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(TiposDeDocumentos tiposDeDocumentos)
        {
            _dbcontext.TTiposDeDocumentos.Add(tiposDeDocumentos);
            await _dbcontext.SaveChangesAsync();
            return tiposDeDocumentos.idTipoDeDocumento;
            
        }

        public async Task Borrar(long idTipoDeDocumento)
        {
            var obj = await _dbcontext.TTiposDeDocumentos.FirstOrDefaultAsync(x => x.idTipoDeDocumento == idTipoDeDocumento);
            _dbcontext.TTiposDeDocumentos.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<TiposDeDocumentos> ConsultarPorId(long idTipoDeDocumento)
        {
            var obj = await _dbcontext.TTiposDeDocumentos.FirstOrDefaultAsync(x => x.idTipoDeDocumento == idTipoDeDocumento);
            return obj == null ? new TiposDeDocumentos() : obj;
        }

        public async Task<bool> Editar(long idTipoDeDocumento, TiposDeDocumentos tiposDeDocumentos)
        {
            _dbcontext.TTiposDeDocumentos.Add(tiposDeDocumentos);
            _dbcontext.Entry(tiposDeDocumentos).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface ITiposDeDocumentosServicios
    {
        Task<long> Agregar(TiposDeDocumentos tiposDeDocumentos);
        Task<bool> Editar(long idTipoDeDocumento, TiposDeDocumentos tiposDeDocumentos);
        Task<TiposDeDocumentos> ConsultarPorId(long idTipoDeDocumento);
        Task Borrar(long idTipoDeDocumento);
    }
}
