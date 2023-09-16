using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class RolesXEmpresasServicios : IRolesXEmpresasServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public RolesXEmpresasServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(RolesXEmpresas rolesXEmpresas)
        {
            _dbcontext.TRolesXEmpresas.Add(rolesXEmpresas);
            await _dbcontext.SaveChangesAsync();
            return rolesXEmpresas.idRolXEmpresa;
            
        }

        public async Task Borrar(long idRolXEmpresa)
        {
            var obj = await _dbcontext.TRolesXEmpresas.FirstOrDefaultAsync(x => x.idRolXEmpresa == idRolXEmpresa);
            _dbcontext.TRolesXEmpresas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<RolesXEmpresas> ConsultarPorId(long idRolXEmpresa)
        {
            var obj = await _dbcontext.TRolesXEmpresas.FirstOrDefaultAsync(x => x.idRolXEmpresa == idRolXEmpresa);
            return obj == null ? new RolesXEmpresas() : obj;
        }

        public async Task<object?> ConsultarTodos()
        {
            return await _dbcontext.TRolesXEmpresas.ToListAsync();
        }

        public async Task<bool> Editar(long idRolXEmpresa, RolesXEmpresas rolesXEmpresas)
        {
            _dbcontext.TRolesXEmpresas.Add(rolesXEmpresas);
            _dbcontext.Entry(rolesXEmpresas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IRolesXEmpresasServicios
    {
        Task<long> Agregar(RolesXEmpresas rolesXEmpresas);
        Task<bool> Editar(long idRolXEmpresa, RolesXEmpresas rolesXEmpresas);
        Task<RolesXEmpresas> ConsultarPorId(long idRolXEmpresa);
        Task<object?> ConsultarTodos();
        Task Borrar(long idRolXEmpresa);
    }
}
