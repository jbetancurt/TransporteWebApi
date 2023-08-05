using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class Plantillas_RequisitosXOfertasServicios : IPlantillas_RequisitosXOfertasServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public Plantillas_RequisitosXOfertasServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(Plantillas_RequisitosXOfertas plantillas_RequisitosXOfertas)
        {
            _dbcontext.TPlantillas_RequisitosXOfertas.Add(plantillas_RequisitosXOfertas);
            await _dbcontext.SaveChangesAsync();
            return plantillas_RequisitosXOfertas.idRequisito;
            
        }

        public async Task Borrar(long idRequisito)
        {
            var obj = await _dbcontext.TPlantillas_RequisitosXOfertas.FirstOrDefaultAsync(x => x.idRequisito == idRequisito);
            _dbcontext.TPlantillas_RequisitosXOfertas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Plantillas_RequisitosXOfertas> ConsultarPorId(long idRequisito)
        {
            var obj = await _dbcontext.TPlantillas_RequisitosXOfertas.FirstOrDefaultAsync(x => x.idRequisito == idRequisito);
            return obj == null ? new Plantillas_RequisitosXOfertas() : obj;
        }

        public async Task<bool> Editar(long idRequisito, Plantillas_RequisitosXOfertas plantillas_RequisitosXOfertas)
        {
            _dbcontext.TPlantillas_RequisitosXOfertas.Add(plantillas_RequisitosXOfertas);
            _dbcontext.Entry(plantillas_RequisitosXOfertas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IPlantillas_RequisitosXOfertasServicios
    {
        Task<long> Agregar(Plantillas_RequisitosXOfertas plantillas_RequisitosXOfertas);
        Task<bool> Editar(long idRequisito, Plantillas_RequisitosXOfertas plantillas_RequisitosXOfertas);
        Task<Plantillas_RequisitosXOfertas> ConsultarPorId(long idRequisito);
        Task Borrar(long idRequisito);
    }
}
