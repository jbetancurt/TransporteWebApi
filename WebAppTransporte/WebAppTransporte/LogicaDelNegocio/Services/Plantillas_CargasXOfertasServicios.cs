
using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class Plantillas_CargasXOfertasServicios : IPlantillas_CargasXOfertasServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public Plantillas_CargasXOfertasServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(Plantillas_CargasXOfertas plantillas_CargasXOfertas)
        {
            _dbcontext.TPlantillas_CargasXOfertas.Add(plantillas_CargasXOfertas);
            await _dbcontext.SaveChangesAsync();
            return plantillas_CargasXOfertas.idCargaXOferta;

        }

        public async Task Borrar(long idCargaXOferta)
        {
            var obj = await _dbcontext.TPlantillas_CargasXOfertas.FirstOrDefaultAsync(x => x.idCargaXOferta == idCargaXOferta);
            _dbcontext.TPlantillas_CargasXOfertas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Plantillas_CargasXOfertas> ConsultarPorId(long idCargaXOferta)
        {
            var obj = await _dbcontext.TPlantillas_CargasXOfertas.FirstOrDefaultAsync(x => x.idCargaXOferta == idCargaXOferta);
            return obj == null ? new Plantillas_CargasXOfertas() : obj;
        }

        public async Task<object?> ConsultarTodos()
        {
            return await _dbcontext.TPlantillas_CargasXOfertas.ToListAsync();
        }

        public async Task<bool> Editar(long idCargaXOferta, Plantillas_CargasXOfertas plantillas_CargasXOfertas)
        {
            _dbcontext.TPlantillas_CargasXOfertas.Add(plantillas_CargasXOfertas);
            _dbcontext.Entry(plantillas_CargasXOfertas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IPlantillas_CargasXOfertasServicios
    {
        Task<long> Agregar(Plantillas_CargasXOfertas plantillas_CargasXOfertas);
        Task<bool> Editar(long idCargaXOferta, Plantillas_CargasXOfertas plantillas_CargasXOfertas);
        Task<Plantillas_CargasXOfertas> ConsultarPorId(long idCargaXOferta);
        Task<object?> ConsultarTodos();
        Task Borrar(long idCargaXOferta);
    }
}
