using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class RutasXVehiculosServicios : IRutasXVehiculosServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public RutasXVehiculosServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(RutasXVehiculos rutasXVehiculos)
        {
            _dbcontext.TRutasXVehiculos.Add(rutasXVehiculos);
            await _dbcontext.SaveChangesAsync();
            return rutasXVehiculos.idRutaXVehiculo;
            
        }

        public async Task Borrar(long idRutaXVehiculo)
        {
            var obj = await _dbcontext.TRutasXVehiculos.FirstOrDefaultAsync(x => x.idRutaXVehiculo == idRutaXVehiculo);
            _dbcontext.TRutasXVehiculos.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<RutasXVehiculos> ConsultarPorId(long idRutaXVehiculo)
        {
            var obj = await _dbcontext.TRutasXVehiculos.FirstOrDefaultAsync(x => x.idRutaXVehiculo == idRutaXVehiculo);
            return obj == null ? new RutasXVehiculos() : obj;
        }

        public async Task<object?> ConsultarTodos()
        {
            return await _dbcontext.TRutasXVehiculos.ToListAsync();
        }
        public async Task<bool> Editar(long idRutaXVehiculo, RutasXVehiculos rutasXVehiculos)
        {
            _dbcontext.TRutasXVehiculos.Add(rutasXVehiculos);
            _dbcontext.Entry(rutasXVehiculos).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IRutasXVehiculosServicios
    {
        Task<long> Agregar(RutasXVehiculos rutasXVehiculos);
        Task<bool> Editar(long idRutaXVehiculo, RutasXVehiculos rutasXVehiculos);
        Task<RutasXVehiculos> ConsultarPorId(long idRutaXVehiculo);
        Task<object?> ConsultarTodos();
        Task Borrar(long idRutaXVehiculo);
    }
}
