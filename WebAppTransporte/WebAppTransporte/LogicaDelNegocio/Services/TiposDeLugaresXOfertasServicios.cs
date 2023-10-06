
using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class TiposDeLugaresXOfertasServicios : ITiposDeLugaresXOfertasServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public TiposDeLugaresXOfertasServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(TiposDeLugaresXOfertas tiposDeLugaresXOfertas)
        {
            _dbcontext.TTiposDeLugaresXOfertas.Add(tiposDeLugaresXOfertas);
            await _dbcontext.SaveChangesAsync();
            return tiposDeLugaresXOfertas.idTipoDeLugarXOferta;

        }

        public async Task Borrar(long idTipoDeLugarXOferta)
        {
            var obj = await _dbcontext.TTiposDeLugaresXOfertas.FirstOrDefaultAsync(x => x.idTipoDeLugarXOferta == idTipoDeLugarXOferta);
            _dbcontext.TTiposDeLugaresXOfertas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<TiposDeLugaresXOfertas> ConsultarPorId(long idTipoDeLugarXOferta)
        {
            var obj = await _dbcontext.TTiposDeLugaresXOfertas.FirstOrDefaultAsync(x => x.idTipoDeLugarXOferta == idTipoDeLugarXOferta);
            return obj == null ? new TiposDeLugaresXOfertas() : obj;
        }

        public async Task<bool> Editar(long idTipoDeLugarXOferta, TiposDeLugaresXOfertas tiposDeLugaresXOfertas)
        {
            _dbcontext.TTiposDeLugaresXOfertas.Add(tiposDeLugaresXOfertas);
            _dbcontext.Entry(tiposDeLugaresXOfertas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<List<TiposDeLugaresXOfertas>> ConsultarTodos()
        {
            return await _dbcontext.TTiposDeLugaresXOfertas.ToListAsync();
        }

        public async Task<TiposDeLugaresXOfertas> ConsultarPorEnum(string enumerador)
        {
            var obj = await _dbcontext.TTiposDeLugaresXOfertas.Where(x => x.enumerador == enumerador).FirstOrDefaultAsync();
            return obj == null ? new TiposDeLugaresXOfertas() : obj;
        }
    }
    public interface ITiposDeLugaresXOfertasServicios
    {
        Task<long> Agregar(TiposDeLugaresXOfertas tiposDeLugaresXOfertas);
        Task<bool> Editar(long idTipoDeLugarXOferta, TiposDeLugaresXOfertas tiposDeLugaresXOfertas);
        Task<TiposDeLugaresXOfertas> ConsultarPorId(long idTipoDeLugarXOferta);
        Task Borrar(long idTipoDeLugarXOferta);
        Task<List<TiposDeLugaresXOfertas>> ConsultarTodos();
        Task<TiposDeLugaresXOfertas> ConsultarPorEnum(string enumerador);
    }
}
