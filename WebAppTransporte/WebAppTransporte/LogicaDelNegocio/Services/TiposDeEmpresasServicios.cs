using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class TiposDeEmpresasServicios : ITiposDeEmpresasServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public TiposDeEmpresasServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(TiposDeEmpresas tiposDeEmpresas)
        {
            _dbcontext.TTiposDeEmpresas.Add(tiposDeEmpresas);
            await _dbcontext.SaveChangesAsync();
            return tiposDeEmpresas.idTipoDeEmpresa;
            
        }

        public async Task Borrar(long idTipoDeEmpresa)
        {
            var obj = await _dbcontext.TTiposDeEmpresas.FirstOrDefaultAsync(x => x.idTipoDeEmpresa == idTipoDeEmpresa);
            _dbcontext.TTiposDeEmpresas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<TiposDeEmpresas> ConsultarPorId(long idTipoDeEmpresa)
        {
            var obj = await _dbcontext.TTiposDeEmpresas.FirstOrDefaultAsync(x => x.idTipoDeEmpresa == idTipoDeEmpresa);
            return obj == null ? new TiposDeEmpresas() : obj;
        }

        public async Task<bool> Editar(long idTipoDeEmpresa, TiposDeEmpresas tiposDeEmpresas)
        {
            _dbcontext.TTiposDeEmpresas.Add(tiposDeEmpresas);
            _dbcontext.Entry(tiposDeEmpresas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface ITiposDeEmpresasServicios
    {
        Task<long> Agregar(TiposDeEmpresas tiposDeEmpresas);
        Task<bool> Editar(long idTipoDeEmpresa, TiposDeEmpresas tiposDeEmpresas);
        Task<TiposDeEmpresas> ConsultarPorId(long idTipoDeEmpresa);
        Task Borrar(long idTipoDeEmpresa);
    }
}
