using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class RequisitosAdjuntosServicios : IRequisitosAdjuntosServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public RequisitosAdjuntosServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(RequisitosAdjuntos requisitosAdjuntos)
        {
            _dbcontext.TRequisitosAdjuntos.Add(requisitosAdjuntos);
            await _dbcontext.SaveChangesAsync();
            return requisitosAdjuntos.idRequisitoAdjunto;
            
        }

        public async Task Borrar(long idRequisitoAdjunto)
        {
            var obj = await _dbcontext.TRequisitosAdjuntos.FirstOrDefaultAsync(x => x.idRequisitoAdjunto == idRequisitoAdjunto);
            _dbcontext.TRequisitosAdjuntos.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<RequisitosAdjuntos> ConsultarPorId(long idRequisitoAdjunto)
        {
            var obj = await _dbcontext.TRequisitosAdjuntos.FirstOrDefaultAsync(x => x.idRequisitoAdjunto == idRequisitoAdjunto);
            return obj == null ? new RequisitosAdjuntos() : obj;
        }

        public async Task<List<RequisitosAdjuntos>> ConsultarTodos()
        {
            return await _dbcontext.TRequisitosAdjuntos.ToListAsync();
        }

        public async Task<bool> Editar(long idRequisitoAdjunto, RequisitosAdjuntos requisitosAdjuntos)
        {
            _dbcontext.TRequisitosAdjuntos.Add(requisitosAdjuntos);
            _dbcontext.Entry(requisitosAdjuntos).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IRequisitosAdjuntosServicios
    {
        Task<long> Agregar(RequisitosAdjuntos requisitosAdjuntos);
        Task<bool> Editar(long idRequisitoAdjunto, RequisitosAdjuntos requisitosAdjuntos);
        Task<RequisitosAdjuntos> ConsultarPorId(long idRequisitoAdjunto);
        Task<List<RequisitosAdjuntos>> ConsultarTodos();
        Task Borrar(long idRequisitoAdjunto);
    }
}
