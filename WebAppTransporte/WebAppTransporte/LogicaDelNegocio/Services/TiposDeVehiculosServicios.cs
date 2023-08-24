using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class TiposDeVehiculosServicios : ITiposDeVehiculosServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public TiposDeVehiculosServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(TiposDeVehiculos tiposDeVehiculos)
        {
            _dbcontext.TTiposDeVehiculos.Add(tiposDeVehiculos);
            await _dbcontext.SaveChangesAsync();
            return tiposDeVehiculos.idTipoDeVehiculo;
            
        }

        public async Task Borrar(long idTipoDeVehiculo)
        {
            var obj = await _dbcontext.TTiposDeVehiculos.FirstOrDefaultAsync(x => x.idTipoDeVehiculo == idTipoDeVehiculo);
            _dbcontext.TTiposDeVehiculos.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<TiposDeVehiculos> ConsultarPorId(long idTipoDeVehiculo)
        {
            var obj = await _dbcontext.TTiposDeVehiculos.FirstOrDefaultAsync(x => x.idTipoDeVehiculo == idTipoDeVehiculo);
            return obj == null ? new TiposDeVehiculos() : obj;
        }

        public async Task<bool> Editar(long idTipoDeVehiculo, TiposDeVehiculos tiposDeVehiculos)
        {
            _dbcontext.TTiposDeVehiculos.Add(tiposDeVehiculos);
            _dbcontext.Entry(tiposDeVehiculos).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<object?> ConsultarTodos()
        {
     
            return await _dbcontext.TTiposDeVehiculos.ToListAsync();
        }
    }
    public  interface ITiposDeVehiculosServicios
    {
        Task<long> Agregar(TiposDeVehiculos tiposDeVehiculos);
        Task<bool> Editar(long idTipoDeVehiculo, TiposDeVehiculos tiposDeVehiculos);
        Task<TiposDeVehiculos> ConsultarPorId(long idTipoDeVehiculo);
        Task Borrar(long idTipoDeVehiculo);
        Task<object?> ConsultarTodos();
    }
}
