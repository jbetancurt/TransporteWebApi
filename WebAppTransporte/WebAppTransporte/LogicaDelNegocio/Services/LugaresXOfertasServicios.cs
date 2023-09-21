using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;


namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class LugaresXOfertasServicios : ILugaresXOfertasServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public LugaresXOfertasServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(LugaresXOfertas lugaresXOfertas)
        {
            _dbcontext.TLugaresXOfertas.Add(lugaresXOfertas);
            await _dbcontext.SaveChangesAsync();
            return lugaresXOfertas.idLugarXOferta;

        }

        public async Task Borrar(long idLugarXOferta)
        {
            var obj = await _dbcontext.TLugaresXOfertas.FirstOrDefaultAsync(x => x.idLugarXOferta == idLugarXOferta);
            _dbcontext.TLugaresXOfertas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<LugaresXOfertas> ConsultarPorId(long idLugarXOferta)
        {
            var obj = await _dbcontext.TLugaresXOfertas.FirstOrDefaultAsync(x => x.idLugarXOferta == idLugarXOferta);
            return obj == null ? new LugaresXOfertas() : obj;
        }

        public async Task<object?> ConsultarTodos()
        {
            return await _dbcontext.TLugaresXOfertas.ToListAsync();
        }

        public async Task<bool> Editar(long idLugarXOferta, LugaresXOfertas lugaresXOfertas)
        {
            _dbcontext.TLugaresXOfertas.Add(lugaresXOfertas);
            _dbcontext.Entry(lugaresXOfertas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface ILugaresXOfertasServicios
    {
        Task<long> Agregar(LugaresXOfertas lugaresXOfertas);
        Task<bool> Editar(long idLugarXOferta, LugaresXOfertas lugaresXOfertas);
        Task<LugaresXOfertas> ConsultarPorId(long idLugarXOferta);
        Task<object?> ConsultarTodos();
        Task Borrar(long idLugar);
    }
}