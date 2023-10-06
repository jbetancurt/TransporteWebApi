
using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class HistorialesDeLasOfertasServicios : IHistorialesDeLasOfertasServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public HistorialesDeLasOfertasServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(HistorialesDeLasOfertas historialesDeLasOfertas)
        {
            _dbcontext.THistorialesDeLasOfertas.Add(historialesDeLasOfertas);
            await _dbcontext.SaveChangesAsync();
            return historialesDeLasOfertas.idHistorialDeLaOferta;

        }

        public async Task Borrar(long idHistorialDeLaOferta)
        {
            var obj = await _dbcontext.THistorialesDeLasOfertas.FirstOrDefaultAsync(x => x.idHistorialDeLaOferta == idHistorialDeLaOferta);
            _dbcontext.THistorialesDeLasOfertas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<HistorialesDeLasOfertas> ConsultarPorId(long idHistorialDeLaOferta)
        {
            var obj = await _dbcontext.THistorialesDeLasOfertas.FirstOrDefaultAsync(x => x.idHistorialDeLaOferta == idHistorialDeLaOferta);
            return obj == null ? new HistorialesDeLasOfertas() : obj;
        }

        public async Task<List<HistorialesDeLasOfertas>> ConsultarTodos()
        {
            return await _dbcontext.THistorialesDeLasOfertas.ToListAsync();
        }

        public async Task<bool> Editar(long idHistorialDeLaOferta, HistorialesDeLasOfertas historialesDeLasOfertas)
        {
            _dbcontext.THistorialesDeLasOfertas.Add(historialesDeLasOfertas);
            _dbcontext.Entry(historialesDeLasOfertas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IHistorialesDeLasOfertasServicios
    {
        Task<long> Agregar(HistorialesDeLasOfertas historialesDeLasOfertas);
        Task<bool> Editar(long idHistorialDeLaOferta, HistorialesDeLasOfertas historialesDeLasOfertas);
        Task<HistorialesDeLasOfertas> ConsultarPorId(long idHistorialDeLaOferta);
        Task<List<HistorialesDeLasOfertas>> ConsultarTodos();
        Task Borrar(long idHistorialDeLaOferta);
    }
}
