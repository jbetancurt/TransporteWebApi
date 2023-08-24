using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class TiposDeRequisitosServicios : ITiposDeRequisitosServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public TiposDeRequisitosServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(TiposDeRequisitos tiposderequisitos)
        {
            _dbcontext.TTiposDeRequisitos.Add(tiposderequisitos);
            await _dbcontext.SaveChangesAsync();
            return tiposderequisitos.idTipoDeRequisito;
            
        }

        public async Task Borrar(long idTipoDeRequisito)
        {
            var obj = await _dbcontext.TTiposDeRequisitos.FirstOrDefaultAsync(x => x.idTipoDeRequisito == idTipoDeRequisito);
            _dbcontext.TTiposDeRequisitos.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<TiposDeRequisitos> ConsultarPorId(long idTipoDeRequisito)
        {
            var obj = await _dbcontext.TTiposDeRequisitos.FirstOrDefaultAsync(x => x.idTipoDeRequisito == idTipoDeRequisito);
            return obj == null ? new TiposDeRequisitos() : obj;
        }

        public async Task<bool> Editar(long idTipoDeRequisito, TiposDeRequisitos tiposderequisitos)
        {
            _dbcontext.TTiposDeRequisitos.Add(tiposderequisitos);
            _dbcontext.Entry(tiposderequisitos).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<object?> ConsultarTodos()
        {
            return await _dbcontext.TTiposDeRequisitos.ToListAsync();
        }

    }
    public interface ITiposDeRequisitosServicios
    {
        Task<long> Agregar(TiposDeRequisitos tiposderequisitos);
        Task<bool> Editar(long idTipoDeRequisito, TiposDeRequisitos tiposderequisitos);
        Task<TiposDeRequisitos> ConsultarPorId(long idTipoDeRequisito);
        Task Borrar(long idTipoDeRequisito);
        Task<object?> ConsultarTodos();
    }
}
