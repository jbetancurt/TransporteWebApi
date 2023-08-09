using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class TiposDeRolesServicios : ITiposDeRolesServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public TiposDeRolesServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(TiposDeRoles tiposDeRoles)
        {
            _dbcontext.TTiposDeRoles.Add(tiposDeRoles);
            await _dbcontext.SaveChangesAsync();
            return tiposDeRoles.idTipoDeRol;
            
        }

        public async Task Borrar(long idTipoDeRol)
        {
            var obj = await _dbcontext.TTiposDeRoles.FirstOrDefaultAsync(x => x.idTipoDeRol == idTipoDeRol);
            _dbcontext.TTiposDeRoles.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<TiposDeRoles> ConsultarPorId(long idTipoDeRol)
        {
            var obj = await _dbcontext.TTiposDeRoles.FirstOrDefaultAsync(x => x.idTipoDeRol == idTipoDeRol);
            return obj == null ? new TiposDeRoles() : obj;
        }

        public async Task<bool> Editar(long idTipoDeRol, TiposDeRoles tiposDeRoles)
        {
            _dbcontext.TTiposDeRoles.Add(tiposDeRoles);
            _dbcontext.Entry(tiposDeRoles).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface ITiposDeRolesServicios
    {
        Task<long> Agregar(TiposDeRoles tiposDeRoles);
        Task<bool> Editar(long idTipoDeRol, TiposDeRoles tiposDeRoles);
        Task<TiposDeRoles> ConsultarPorId(long idTipoDeRol);
        Task Borrar(long idTipoDeRol);
    }
}
