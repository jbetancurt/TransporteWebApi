using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class DestinosXEmpresasServicios : IDestinosXEmpresasServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public DestinosXEmpresasServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(DestinosXEmpresas destinosXEmpresas)
        {
            _dbcontext.TDestinosXEmpresas.Add(destinosXEmpresas);
            await _dbcontext.SaveChangesAsync();
            return destinosXEmpresas.idDestinoXEmpresa;
            
        }

        public async Task Borrar(long idDestinoXEmpresa)
        {
            var obj = await _dbcontext.TDestinosXEmpresas.FirstOrDefaultAsync(x => x.idDestinoXEmpresa == idDestinoXEmpresa);
            _dbcontext.TDestinosXEmpresas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<DestinosXEmpresas> ConsultarPorId(long idDestinoXEmpresa)
        {
            var obj = await _dbcontext.TDestinosXEmpresas.FirstOrDefaultAsync(x => x.idDestinoXEmpresa == idDestinoXEmpresa);
            return obj == null ? new DestinosXEmpresas() : obj;
        }

        public async Task<object?> ConsultarTodos()
        {
            return await _dbcontext.TDestinosXEmpresas.ToListAsync();
        }
        public async Task<bool> Editar(long idDestinoXEmpresa, DestinosXEmpresas destinosXEmpresas)
        {
            _dbcontext.TDestinosXEmpresas.Add(destinosXEmpresas);
            _dbcontext.Entry(destinosXEmpresas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IDestinosXEmpresasServicios
    {
        Task<long> Agregar(DestinosXEmpresas destinosXEmpresas);
        Task<bool> Editar(long idDestinoXEmpresa, DestinosXEmpresas destinosXEmpresas);
        Task<DestinosXEmpresas> ConsultarPorId(long idDestinoXEmpresa);
        Task<object?> ConsultarTodos();
        Task Borrar(long idDestinoXEmpresa);
    }
}
