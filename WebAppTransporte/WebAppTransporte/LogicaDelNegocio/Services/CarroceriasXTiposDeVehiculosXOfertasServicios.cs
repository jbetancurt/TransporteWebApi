
using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class CarroceriasXTiposDeVehiculosXOfertasServicios : ICarroceriasXTiposDeVehiculosXOfertasServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public CarroceriasXTiposDeVehiculosXOfertasServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(CarroceriasXTiposDeVehiculosXOfertas carroceriasXTiposDeVehiculosXOfertas)
        {
            _dbcontext.TCarroceriasXTiposDeVehiculosXOfertas.Add(carroceriasXTiposDeVehiculosXOfertas);
            await _dbcontext.SaveChangesAsync();
            return carroceriasXTiposDeVehiculosXOfertas.idCarroceriaXTipoDeVehiculoXOferta;

        }

        public async Task Borrar(long idCarroceriaXTipoDeVehiculoXOferta)
        {
            var obj = await _dbcontext.TCarroceriasXTiposDeVehiculosXOfertas.FirstOrDefaultAsync(x => x.idCarroceriaXTipoDeVehiculoXOferta == idCarroceriaXTipoDeVehiculoXOferta);
            _dbcontext.TCarroceriasXTiposDeVehiculosXOfertas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task BorrarPorIdOferta(long idOferta)
        {
            var obj = await _dbcontext.TCarroceriasXTiposDeVehiculosXOfertas.Where(x => x.idOferta == idOferta).ToListAsync();
            _dbcontext.TCarroceriasXTiposDeVehiculosXOfertas.RemoveRange(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<CarroceriasXTiposDeVehiculosXOfertas> ConsultarPorId(long idCarroceriaXTipoDeVehiculoXOferta)
        {
            var obj = await _dbcontext.TCarroceriasXTiposDeVehiculosXOfertas.FirstOrDefaultAsync(x => x.idCarroceriaXTipoDeVehiculoXOferta == idCarroceriaXTipoDeVehiculoXOferta);
            return obj == null ? new CarroceriasXTiposDeVehiculosXOfertas() : obj;
        }

        public async Task<List<CarroceriasXTiposDeVehiculosXOfertas>> ConsultarTodos()
        {
            return await _dbcontext.TCarroceriasXTiposDeVehiculosXOfertas.ToListAsync();
        }

        public async Task<bool> Editar(long idCarroceriaXTipoDeVehiculoXOferta, CarroceriasXTiposDeVehiculosXOfertas carroceriasXTiposDeVehiculosXOfertas)
        {
            _dbcontext.TCarroceriasXTiposDeVehiculosXOfertas.Add(carroceriasXTiposDeVehiculosXOfertas);
            _dbcontext.Entry(carroceriasXTiposDeVehiculosXOfertas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<List<CarroceriasXTiposDeVehiculosXOfertas>> ConsultarXOferta(long idOferta)
        {
            return await _dbcontext.TCarroceriasXTiposDeVehiculosXOfertas.Where(x => x.idOferta == idOferta).ToListAsync();
        }

    }
    public interface ICarroceriasXTiposDeVehiculosXOfertasServicios
    {
        Task<long> Agregar(CarroceriasXTiposDeVehiculosXOfertas carroceriasXTiposDeVehiculosXOfertas);
        Task<bool> Editar(long idCarroceriaXTipoDeVehiculoXOferta, CarroceriasXTiposDeVehiculosXOfertas carroceriasXTiposDeVehiculosXOfertas);
        Task<CarroceriasXTiposDeVehiculosXOfertas> ConsultarPorId(long idCarroceriaXTipoDeVehiculoXOferta);
        Task<List<CarroceriasXTiposDeVehiculosXOfertas>> ConsultarTodos();
        Task<List<CarroceriasXTiposDeVehiculosXOfertas>> ConsultarXOferta(long idOferta);
        Task Borrar(long idCarroceriaXTipoDeVehiculoXOferta);
        Task BorrarPorIdOferta(long idOferta);
    }
}
