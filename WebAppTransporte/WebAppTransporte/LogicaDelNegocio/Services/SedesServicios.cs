using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class SedesServicios : ISedesServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public SedesServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(Sedes sedes)
        {
            _dbcontext.TSedes.Add(sedes);
            await _dbcontext.SaveChangesAsync();
            return sedes.idSede;
            
        }

        public async Task Borrar(long idSede)
        {
            var obj = await _dbcontext.TSedes.FirstOrDefaultAsync(x => x.idSede == idSede);
            _dbcontext.TSedes.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Sedes> ConsultarPorId(long idSede)
        {
            var obj = await _dbcontext.TSedes.FirstOrDefaultAsync(x => x.idSede == idSede);
            return obj == null ? new Sedes() : obj;
        }

        public async Task<object?> ConsultarTodos()
        {
            return await _dbcontext.TSedes.ToListAsync();
        }

        public async Task<bool> Editar(long idSede, Sedes sedes)
        {
            _dbcontext.TSedes.Add(sedes);
            _dbcontext.Entry(sedes).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface ISedesServicios
    {
        Task<long> Agregar(Sedes sedes);
        Task<bool> Editar(long idSede, Sedes sedes);
        Task<Sedes> ConsultarPorId(long idSede);
        Task<object?> ConsultarTodos();
        Task Borrar(long idSede);
    }
}
