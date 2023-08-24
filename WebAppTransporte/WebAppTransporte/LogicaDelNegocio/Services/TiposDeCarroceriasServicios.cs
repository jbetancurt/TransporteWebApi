using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class TiposDeCarroceriasServicios : ITiposDeCarroceriasServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public TiposDeCarroceriasServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(TiposDeCarrocerias tiposDeCarrocerias)
        {
            _dbcontext.TTiposDeCarrocerias.Add(tiposDeCarrocerias);
            await _dbcontext.SaveChangesAsync();
            return tiposDeCarrocerias.idTipoDeCarroceria;

        }

        public async Task Borrar(long idTipoDeCarroceria)
        {
            var obj = await _dbcontext.TTiposDeCarrocerias.FirstOrDefaultAsync(x => x.idTipoDeCarroceria == idTipoDeCarroceria);
            _dbcontext.TTiposDeCarrocerias.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<TiposDeCarrocerias> ConsultarPorId(long idTipoDeCarroceria)
        {
            var obj = await _dbcontext.TTiposDeCarrocerias.FirstOrDefaultAsync(x => x.idTipoDeCarroceria == idTipoDeCarroceria);
            return obj == null ? new TiposDeCarrocerias() : obj;
        }

        public async Task<bool> Editar(long idTipoDeCarroceria, TiposDeCarrocerias tiposDeCarrocerias)
        {
            _dbcontext.TTiposDeCarrocerias.Add(tiposDeCarrocerias);
            _dbcontext.Entry(tiposDeCarrocerias).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<object?> ConsultarTodos()
        {
            return await _dbcontext.TTiposDeCarrocerias.ToListAsync();
        }
    }
    public interface ITiposDeCarroceriasServicios
    {
        Task<long> Agregar(TiposDeCarrocerias tiposDeCarrocerias);
        Task<bool> Editar(long idTipoDeCarroceria, TiposDeCarrocerias tiposDeCarrocerias);
        Task<TiposDeCarrocerias> ConsultarPorId(long idTipoDeCarroceria);
        Task Borrar(long idTipoDeCarroceria);
        Task<object?> ConsultarTodos();
    }
}
