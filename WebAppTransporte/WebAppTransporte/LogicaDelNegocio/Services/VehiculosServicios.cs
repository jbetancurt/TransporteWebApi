using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class VehiculosServicios : IVehiculosServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public VehiculosServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(Vehiculos vehiculos)
        {
            _dbcontext.TVehiculos.Add(vehiculos);
            await _dbcontext.SaveChangesAsync();
            return vehiculos.idVehiculo;
            
        }

        public async Task Borrar(long idVehiculo)
        {
            var obj = await _dbcontext.TVehiculos.FirstOrDefaultAsync(x => x.idVehiculo == idVehiculo);
            _dbcontext.TVehiculos.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Vehiculos> ConsultarPorId(long idVehiculo)
        {
            var obj = await _dbcontext.TVehiculos.FirstOrDefaultAsync(x => x.idVehiculo == idVehiculo);
            return obj == null ? new Vehiculos() : obj;
        }

        public async Task<bool> Editar(long idVehiculo, Vehiculos vehiculos)
        {
            _dbcontext.TVehiculos.Add(vehiculos);
            _dbcontext.Entry(vehiculos).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IVehiculosServicios
    {
        Task<long> Agregar(Vehiculos vehiculos);
        Task<bool> Editar(long idVehiculo, Vehiculos vehiculos);
        Task<Vehiculos> ConsultarPorId(long idVehiculo);
        Task Borrar(long idVehiculo);
    }
}
