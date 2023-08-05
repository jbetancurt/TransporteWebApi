using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class UsuariosServicios : IUsuariosServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public UsuariosServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(Usuarios usuarios)
        {
            _dbcontext.TUsuarios.Add(usuarios);
            await _dbcontext.SaveChangesAsync();
            return usuarios.idUsuario;
            
        }

        public async Task Borrar(long idUsuario)
        {
            var obj = await _dbcontext.TUsuarios.FirstOrDefaultAsync(x => x.idUsuario == idUsuario);
            _dbcontext.TUsuarios.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Usuarios> ConsultarPorId(long idUsuario)
        {
            var obj = await _dbcontext.TUsuarios.FirstOrDefaultAsync(x => x.idUsuario == idUsuario);
            return obj == null ? new Usuarios() : obj;
        }

        public async Task<bool> Editar(long idUsuario, Usuarios usuarios)
        {
            _dbcontext.TUsuarios.Add(usuarios);
            _dbcontext.Entry(usuarios).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IUsuariosServicios
    {
        Task<long> Agregar(Usuarios usuarios);
        Task<bool> Editar(long idUsuario, Usuarios usuarios);
        Task<Usuarios> ConsultarPorId(long idUsuario);
        Task Borrar(long idUsuario);
    }
    {
    }
}
