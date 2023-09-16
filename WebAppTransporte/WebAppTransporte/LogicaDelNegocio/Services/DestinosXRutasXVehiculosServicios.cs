using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class DestinosXRutasXVehiculosServicios : IDestinosXRutasXVehiculosServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public DestinosXRutasXVehiculosServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(DestinosXRutasXVehiculos destinosXRutasXVehiculos)
        {
            _dbcontext.TDestinosXRutasXVehiculos.Add(destinosXRutasXVehiculos);
            await _dbcontext.SaveChangesAsync();
            return destinosXRutasXVehiculos.idDestinoXRutaXVehiculo;
            
        }

        public async Task Borrar(long idDestinoXRutaXVehiculo)
        {
            var obj = await _dbcontext.TDestinosXRutasXVehiculos.FirstOrDefaultAsync(x => x.idDestinoXRutaXVehiculo == idDestinoXRutaXVehiculo);
            _dbcontext.TDestinosXRutasXVehiculos.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<DestinosXRutasXVehiculos> ConsultarPorId(long idDestinoXRutaXVehiculo)
        {
            var obj = await _dbcontext.TDestinosXRutasXVehiculos.FirstOrDefaultAsync(x => x.idDestinoXRutaXVehiculo == idDestinoXRutaXVehiculo);
            return obj == null ? new DestinosXRutasXVehiculos() : obj;
        }

        public async Task<object?> ConsultarTodos()
        {
            return await _dbcontext.TDestinosXRutasXVehiculos.ToListAsync();
        }

        public async Task<bool> Editar(long idDestinoXRutaXVehiculo, DestinosXRutasXVehiculos destinosXRutasXVehiculos)
        {
            _dbcontext.TDestinosXRutasXVehiculos.Add(destinosXRutasXVehiculos);
            _dbcontext.Entry(destinosXRutasXVehiculos).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IDestinosXRutasXVehiculosServicios
    {
        Task<long> Agregar(DestinosXRutasXVehiculos destinosXRutasXVehiculos);
        Task<bool> Editar(long idDestinoXRutaXVehiculo, DestinosXRutasXVehiculos destinosXRutasXVehiculos);
        Task<DestinosXRutasXVehiculos> ConsultarPorId(long idDestinoXRutaXVehiculo);
        Task<object?> ConsultarTodos();
        Task Borrar(long idDestinoXRutaXVehiculo);
    }
}
