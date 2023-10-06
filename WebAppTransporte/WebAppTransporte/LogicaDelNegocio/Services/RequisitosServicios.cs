using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class RequisitosServicios : IRequisitosServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public RequisitosServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(Requisitos requisitos)
        {
            _dbcontext.TRequisitos.Add(requisitos);
            await _dbcontext.SaveChangesAsync();
            return requisitos.idRequisito;
            
        }

        public async Task Borrar(long idRequisito)
        {
            var obj = await _dbcontext.TRequisitos.FirstOrDefaultAsync(x => x.idRequisito == idRequisito);
            _dbcontext.TRequisitos.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Requisitos> ConsultarPorId(long idRequisito)
        {
            var obj = await _dbcontext.TRequisitos.FirstOrDefaultAsync(x => x.idRequisito == idRequisito);
            return obj == null ? new Requisitos() : obj;
        }

        public async Task<List<Requisitos>> ConsultarTodos()
        {
            return await _dbcontext.TRequisitos.ToListAsync();
        }

        public async Task<bool> Editar(long idRequisito, Requisitos requisitos)
        {
            _dbcontext.TRequisitos.Add(requisitos);
            _dbcontext.Entry(requisitos).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IRequisitosServicios
    {
        Task<long> Agregar(Requisitos requisitos);
        Task<bool> Editar(long idRequisito, Requisitos requisitos);
        Task<Requisitos> ConsultarPorId(long idRequisito);
        Task<List<Requisitos>> ConsultarTodos();
        Task Borrar(long idRequisito);
    }
}
