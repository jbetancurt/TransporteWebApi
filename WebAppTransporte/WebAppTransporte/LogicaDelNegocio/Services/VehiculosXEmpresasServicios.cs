using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class VehiculosXEmpresasServicios : IVehiculosXEmpresasServicios
    {
        protected readonly DbContextsTransporte _dbcontext;
        public VehiculosXEmpresasServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(VehiculosXEmpresas vehiculosXEmpresas)
        {
            _dbcontext.TVehiculosXEmpresas.Add(vehiculosXEmpresas);
            await _dbcontext.SaveChangesAsync();
            return vehiculosXEmpresas.idVehiculoXEmpresa;
        }
        public async Task Borrar(long idVehiculoXEmpresa)
        {
            var obj = await _dbcontext.TVehiculosXEmpresas.FirstOrDefaultAsync(x => x.idVehiculoXEmpresa == idVehiculoXEmpresa);
            _dbcontext.TVehiculosXEmpresas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task<VehiculosXEmpresas> ConsultarPorId(long idVehiculoXEmpresa)
        {
            var obj = await _dbcontext.TVehiculosXEmpresas.FirstOrDefaultAsync(x => x.idVehiculoXEmpresa == idVehiculoXEmpresa);
            return obj == null ? new VehiculosXEmpresas() : obj;
        }

        public async Task<List<VehiculosXEmpresas>> ConsultarTodos()
        {
            return await _dbcontext.TVehiculosXEmpresas.ToListAsync();
        }
        public async Task<bool> Editar(long idVehiculoXEmpresa, VehiculosXEmpresas vehiculosXEmpresas)
        {
            _dbcontext.TVehiculosXEmpresas.Add(vehiculosXEmpresas);
            _dbcontext.Entry(vehiculosXEmpresas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IVehiculosXEmpresasServicios
    {
        Task<long> Agregar(VehiculosXEmpresas vehiculosXEmpresas);
        Task<bool> Editar(long idVehiculoXEmpresa, VehiculosXEmpresas vehiculosXEmpresas);
        Task<VehiculosXEmpresas> ConsultarPorId(long idVehiculoXEmpresa);
        Task<List<VehiculosXEmpresas>> ConsultarTodos();
        Task Borrar(long idVehiculoXEmpresa);
    }
}
