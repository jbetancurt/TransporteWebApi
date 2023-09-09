using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class RolXUsuariosServicios : IRolXUsuariosServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public RolXUsuariosServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(RolXUsuarios rolXUsuarios)
        {
            _dbcontext.TRolXUsuarios.Add(rolXUsuarios);
            await _dbcontext.SaveChangesAsync();
            return rolXUsuarios.idRolXUsuario;
            
        }

        public async Task Borrar(long idRolXUsuario)
        {
            var obj = await _dbcontext.TRolXUsuarios.FirstOrDefaultAsync(x => x.idRolXUsuario == idRolXUsuario);
            _dbcontext.TRolXUsuarios.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<RolXUsuarios> ConsultarPorId(long idRolXUsuario)
        {
            var obj = await _dbcontext.TRolXUsuarios.FirstOrDefaultAsync(x => x.idRolXUsuario == idRolXUsuario);
            return obj == null ? new RolXUsuarios() : obj;
        }

        public async Task<object?> ConsultarTodos()
        {
            return await _dbcontext.TRolXUsuarios.ToListAsync();
        }

        public async Task<bool> Editar(long idRolXUsuario, RolXUsuarios rolXUsuarios)
        {
            _dbcontext.TRolXUsuarios.Add(rolXUsuarios);
            _dbcontext.Entry(rolXUsuarios).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IRolXUsuariosServicios
    {
        Task<long> Agregar(RolXUsuarios rolXUsuarios);
        Task<bool> Editar(long idRolXUsuario, RolXUsuarios rolXUsuarios);
        Task<RolXUsuarios> ConsultarPorId(long idRolXUsuario);
        Task<object?> ConsultarTodos();
        Task Borrar(long idRolXUsuario);
    }
}
