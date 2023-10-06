using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class RolesServicios : IRolesServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public RolesServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(Roles roles)
        {
            _dbcontext.TRoles.Add(roles);
            await _dbcontext.SaveChangesAsync();
            return roles.idRol;
            
        }

        public async Task Borrar(long idRol)
        {
            var obj = await _dbcontext.TRoles.FirstOrDefaultAsync(x => x.idRol == idRol);
            _dbcontext.TRoles.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Roles> ConsultarPorId(long idRol)
        {
            var obj = await _dbcontext.TRoles.FirstOrDefaultAsync(x => x.idRol == idRol);
            return obj == null ? new Roles() : obj;
        }

        public async Task<bool> Editar(long idRol, Roles roles)
        {
            _dbcontext.TRoles.Add(roles);
            _dbcontext.Entry(roles).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Roles>> ConsultarTodos()
        {
            return await _dbcontext.TRoles.ToListAsync();
        }
    }
    public interface IRolesServicios
    {
        Task<long> Agregar(Roles roles);
        Task<bool> Editar(long idRol, Roles roles);
        Task<Roles> ConsultarPorId(long idRol);
        Task Borrar(long idRol);
        Task<List<Roles>> ConsultarTodos();
    }
}
