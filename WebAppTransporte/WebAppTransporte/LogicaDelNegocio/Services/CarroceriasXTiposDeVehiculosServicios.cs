using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class CarroceriasXTiposDeVehiculosServicios : ICarroceriasXTiposDeVehiculosServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public CarroceriasXTiposDeVehiculosServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(CarroceriasXTiposDeVehiculos carroceriasXTiposDeVehiculos)
        {
            _dbcontext.TCarroceriasXTiposDeVehiculos.Add(carroceriasXTiposDeVehiculos);
            await _dbcontext.SaveChangesAsync();
            return carroceriasXTiposDeVehiculos.idCarroceriaXTipoDeVehiculo;
            
        }

        public async Task Borrar(long idCarroceriasXTiposDeVehiculos)
        {
            var obj = await _dbcontext.TCarroceriasXTiposDeVehiculos.FirstOrDefaultAsync(x => x.idCarroceriaXTipoDeVehiculo == idCarroceriasXTiposDeVehiculos);
            _dbcontext.TCarroceriasXTiposDeVehiculos.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<CarroceriasXTiposDeVehiculos> ConsultarPorId(long idCarroceriasXTiposDeVehiculos)
        {
            var obj = await _dbcontext.TCarroceriasXTiposDeVehiculos.FirstOrDefaultAsync(x => x.idCarroceriaXTipoDeVehiculo == idCarroceriasXTiposDeVehiculos);
            return obj == null ? new CarroceriasXTiposDeVehiculos() : obj;
        }

        public async Task<bool> Editar(long idCarroceriasXTiposDeVehiculos, CarroceriasXTiposDeVehiculos carroceriasXTiposDeVehiculos)
        {
            _dbcontext.TCarroceriasXTiposDeVehiculos.Add(carroceriasXTiposDeVehiculos);
            _dbcontext.Entry(carroceriasXTiposDeVehiculos).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }

    }
    public interface ICarroceriasXTiposDeVehiculosServicios
    {
        Task<long> Agregar(CarroceriasXTiposDeVehiculos carroceriasXTiposDeVehiculos);
        Task<bool> Editar(long idCarroceriasXTiposDeVehiculos, CarroceriasXTiposDeVehiculos carroceriasXTiposDeVehiculos);
        Task<CarroceriasXTiposDeVehiculos> ConsultarPorId(long idCarroceriasXTiposDeVehiculos);
        Task Borrar(long idCarroceriasXTiposDeVehiculos);
    }
}
