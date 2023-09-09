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

        public async Task Borrar(long idCarroceriaXTipoDeVehiculo)
        {
            var obj = await _dbcontext.TCarroceriasXTiposDeVehiculos.FirstOrDefaultAsync(x => x.idCarroceriaXTipoDeVehiculo == idCarroceriaXTipoDeVehiculo);
            _dbcontext.TCarroceriasXTiposDeVehiculos.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<CarroceriasXTiposDeVehiculos> ConsultarPorId(long idCarroceriaXTipoDeVehiculo)
        {
            var obj = await _dbcontext.TCarroceriasXTiposDeVehiculos.FirstOrDefaultAsync(x => x.idCarroceriaXTipoDeVehiculo == idCarroceriaXTipoDeVehiculo);
            return obj == null ? new CarroceriasXTiposDeVehiculos() : obj;
        }

        public async Task<object?> ConsultarTodos()
        {
            return await _dbcontext.TCarroceriasXTiposDeVehiculos.ToListAsync();
        }

        public async Task<bool> Editar(long idCarroceriaXTipoDeVehiculo, CarroceriasXTiposDeVehiculos carroceriasXTiposDeVehiculos)
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
        Task<bool> Editar(long idCarroceriaXTipoDeVehiculo, CarroceriasXTiposDeVehiculos carroceriasXTiposDeVehiculos);
        Task<CarroceriasXTiposDeVehiculos> ConsultarPorId(long idCarroceriaXTipoDeVehiculo);
        Task<object?> ConsultarTodos();
        Task Borrar(long idCarroceriaXTipoDeVehiculo);
    }
}
