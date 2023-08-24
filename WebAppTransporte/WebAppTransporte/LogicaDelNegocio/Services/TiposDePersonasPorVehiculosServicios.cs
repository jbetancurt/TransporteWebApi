using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class TiposDePersonasPorVehiculosServicios : ITiposDePersonasPorVehiculosServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public TiposDePersonasPorVehiculosServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(TiposDePersonasPorVehiculos tiposDePersonasPorVehiculos)
        {
            _dbcontext.TTiposDePersonasPorVehiculos.Add(tiposDePersonasPorVehiculos);
            await _dbcontext.SaveChangesAsync();
            return tiposDePersonasPorVehiculos.idTipoDePersonaPorVehiculo;
            
        }

        public async Task Borrar(long idTipoDePersonaPorVehiculo)
        {
            var obj = await _dbcontext.TTiposDePersonasPorVehiculos.FirstOrDefaultAsync(x => x.idTipoDePersonaPorVehiculo == idTipoDePersonaPorVehiculo);
            _dbcontext.TTiposDePersonasPorVehiculos.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<TiposDePersonasPorVehiculos> ConsultarPorId(long idTipoDePersonaPorVehiculo)
        {
            var obj = await _dbcontext.TTiposDePersonasPorVehiculos.FirstOrDefaultAsync(x => x.idTipoDePersonaPorVehiculo == idTipoDePersonaPorVehiculo);
            return obj == null ? new TiposDePersonasPorVehiculos() : obj;
        }

        public async Task<bool> Editar(long idTipoDePersonaPorVehiculo, TiposDePersonasPorVehiculos tiposDePersonasPorVehiculos)
        {
            _dbcontext.TTiposDePersonasPorVehiculos.Add(tiposDePersonasPorVehiculos);
            _dbcontext.Entry(tiposDePersonasPorVehiculos).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<object?> ConsultarTodos()
        {
            return await _dbcontext.TTiposDePersonasPorVehiculos.ToListAsync();
        }
    }
    public interface ITiposDePersonasPorVehiculosServicios
    {
        Task<long> Agregar(TiposDePersonasPorVehiculos tiposDePersonasPorVehiculos);
        Task<bool> Editar(long idTipoDePersonaPorVehiculo, TiposDePersonasPorVehiculos tiposDePersonasPorVehiculos);
        Task<TiposDePersonasPorVehiculos> ConsultarPorId(long idTipoDePersonaPorVehiculo);
        Task Borrar(long idTipoDePersonaPorVehiculo);
        Task<object?> ConsultarTodos();
    }
}
