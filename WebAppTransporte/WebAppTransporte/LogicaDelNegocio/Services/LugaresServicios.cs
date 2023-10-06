
using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class LugaresServicios : ILugaresServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public LugaresServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(Lugares lugares)
        {
            _dbcontext.TLugares.Add(lugares);
            await _dbcontext.SaveChangesAsync();
            return lugares.idLugar;

        }

        public async Task Borrar(long idLugar)
        {
            var obj = await _dbcontext.TLugares.FirstOrDefaultAsync(x => x.idLugar == idLugar);
            _dbcontext.TLugares.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Lugares> ConsultarPorId(long idLugar)
        {
            var obj = await _dbcontext.TLugares.FirstOrDefaultAsync(x => x.idLugar == idLugar);
            return obj == null ? new Lugares() : obj;
        }

        public async Task<List<Lugares>> ConsultarTodos()
        {
            return await _dbcontext.TLugares.ToListAsync();
        }

        public async Task<bool> Editar(long idLugar, Lugares lugares)
        {
            _dbcontext.TLugares.Add(lugares);
            _dbcontext.Entry(lugares).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface ILugaresServicios
    {
        Task<long> Agregar(Lugares lugares);
        Task<bool> Editar(long idLugar, Lugares lugares);
        Task<Lugares> ConsultarPorId(long idLugar);
        Task<List<Lugares>> ConsultarTodos();
        Task Borrar(long idLugar);
    }
}
