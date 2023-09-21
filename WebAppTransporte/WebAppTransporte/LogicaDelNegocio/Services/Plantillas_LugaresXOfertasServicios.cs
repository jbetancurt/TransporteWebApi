

using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;


namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class Plantillas_LugaresXOfertasServicios : IPlantillas_LugaresXOfertasServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public Plantillas_LugaresXOfertasServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(Plantillas_LugaresXOfertas plantillas_LugaresXOfertas)
        {
            _dbcontext.TPlantillas_LugaresXOfertas.Add(plantillas_LugaresXOfertas);
            await _dbcontext.SaveChangesAsync();
            return plantillas_LugaresXOfertas.idLugarXOferta;

        }

        public async Task Borrar(long idLugarXOferta)
        {
            var obj = await _dbcontext.TPlantillas_LugaresXOfertas.FirstOrDefaultAsync(x => x.idLugarXOferta == idLugarXOferta);
            _dbcontext.TPlantillas_LugaresXOfertas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Plantillas_LugaresXOfertas> ConsultarPorId(long idLugarXOferta)
        {
            var obj = await _dbcontext.TPlantillas_LugaresXOfertas.FirstOrDefaultAsync(x => x.idLugarXOferta == idLugarXOferta);
            return obj == null ? new Plantillas_LugaresXOfertas() : obj;
        }

        public async Task<object?> ConsultarTodos()
        {
            return await _dbcontext.TPlantillas_LugaresXOfertas.ToListAsync();
        }

        public async Task<bool> Editar(long idLugarXOferta, Plantillas_LugaresXOfertas plantillas_LugaresXOfertas)
        {
            _dbcontext.TPlantillas_LugaresXOfertas.Add(plantillas_LugaresXOfertas);
            _dbcontext.Entry(plantillas_LugaresXOfertas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IPlantillas_LugaresXOfertasServicios
    {
        Task<long> Agregar(Plantillas_LugaresXOfertas plantillas_LugaresXOfertas);
        Task<bool> Editar(long idLugarXOferta, Plantillas_LugaresXOfertas plantillas_LugaresXOfertas);
        Task<Plantillas_LugaresXOfertas> ConsultarPorId(long idLugarXOferta);
        Task<object?> ConsultarTodos();
        Task Borrar(long idLugar);
    }
}