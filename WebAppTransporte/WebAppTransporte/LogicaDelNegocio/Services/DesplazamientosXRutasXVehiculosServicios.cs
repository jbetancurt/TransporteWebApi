using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class DesplazamientosXRutasXVehiculosServicios : IDesplazamientosXRutasXVehiculosServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public DesplazamientosXRutasXVehiculosServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(DesplazamientosXRutasXVehiculos desplazamientosXRutasXVehiculos)
        {
            _dbcontext.TDesplazamientosXRutasXVehiculos.Add(desplazamientosXRutasXVehiculos);
            await _dbcontext.SaveChangesAsync();
            return desplazamientosXRutasXVehiculos.idDesplazamientoXRutaXVehiculo;
            
        }

        public async Task Borrar(long idDesplazamientoXRutaXVehiculo)
        {
            var obj = await _dbcontext.TDesplazamientosXRutasXVehiculos.FirstOrDefaultAsync(x => x.idDesplazamientoXRutaXVehiculo == idDesplazamientoXRutaXVehiculo);
            _dbcontext.TDesplazamientosXRutasXVehiculos.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<DesplazamientosXRutasXVehiculos> ConsultarPorId(long idDesplazamientoXRutaXVehiculo)
        {
            var obj = await _dbcontext.TDesplazamientosXRutasXVehiculos.FirstOrDefaultAsync(x => x.idDesplazamientoXRutaXVehiculo == idDesplazamientoXRutaXVehiculo);
            return obj == null ? new DesplazamientosXRutasXVehiculos() : obj;
        }

        public async Task<object?> ConsultarTodos()
        {
            return await _dbcontext.TDesplazamientosXRutasXVehiculos.ToListAsync();
        }

        public async Task<bool> Editar(long idDesplazamientoXRutaXVehiculo, DesplazamientosXRutasXVehiculos desplazamientosXRutasXVehiculos)
        {
            _dbcontext.TDesplazamientosXRutasXVehiculos.Add(desplazamientosXRutasXVehiculos);
            _dbcontext.Entry(desplazamientosXRutasXVehiculos).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IDesplazamientosXRutasXVehiculosServicios
    {
        Task<long> Agregar(DesplazamientosXRutasXVehiculos desplazamientosXRutasXVehiculos);
        Task<bool> Editar(long idDesplazamientoXRutaXVehiculo, DesplazamientosXRutasXVehiculos desplazamientosXRutasXVehiculos);
        Task<DesplazamientosXRutasXVehiculos> ConsultarPorId(long idDesplazamientoXRutaXVehiculo);
        Task<object?> ConsultarTodos();
        Task Borrar(long idDesplazamientoXRutaXVehiculo);
    }
}
