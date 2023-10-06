using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class Plantillas_OfertasServicios : IPlantillas_OfertasServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public Plantillas_OfertasServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(Plantillas_Ofertas plantillas_Ofertas)
        {
            _dbcontext.TPlantillas_Ofertas.Add(plantillas_Ofertas);
            await _dbcontext.SaveChangesAsync();
            return plantillas_Ofertas.idOferta;
            
        }

        public async Task Borrar(long idOferta)
        {
            var obj = await _dbcontext.TPlantillas_Ofertas.FirstOrDefaultAsync(x => x.idOferta == idOferta);
            _dbcontext.TPlantillas_Ofertas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Plantillas_Ofertas> ConsultarPorId(long idOferta)
        {
            var obj = await _dbcontext.TPlantillas_Ofertas.FirstOrDefaultAsync(x => x.idOferta == idOferta);
            return obj == null ? new Plantillas_Ofertas() : obj;
        }

        public async Task<List<Plantillas_Ofertas>> ConsultarTodos()
        {
            return await _dbcontext.TPlantillas_Ofertas.ToListAsync();
        }


        public async Task<bool> Editar(long idOferta, Plantillas_Ofertas plantillas_Ofertas)
        {
            _dbcontext.TPlantillas_Ofertas.Add(plantillas_Ofertas);
            _dbcontext.Entry(plantillas_Ofertas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IPlantillas_OfertasServicios
    {
        Task<long> Agregar(Plantillas_Ofertas plantillas_Ofertas);
        Task<bool> Editar(long idOferta, Plantillas_Ofertas plantillas_Ofertas);
        Task<Plantillas_Ofertas> ConsultarPorId(long idOferta);
        Task<List<Plantillas_Ofertas>> ConsultarTodos();
        Task Borrar(long idOferta);
    }
}
