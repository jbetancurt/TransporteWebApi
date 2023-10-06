using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class EmpresasServicios : IEmpresasServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public EmpresasServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(Empresas empresas)
        {
            _dbcontext.TEmpresas.Add(empresas);
            await _dbcontext.SaveChangesAsync();
            return empresas.idEmpresa;
            
        }

        public async Task Borrar(long idEmpresa)
        {
            var obj = await _dbcontext.TEmpresas.FirstOrDefaultAsync(x => x.idEmpresa == idEmpresa);
            _dbcontext.TEmpresas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Empresas> ConsultarPorId(long idEmpresa)
        {
            var obj = await _dbcontext.TEmpresas.FirstOrDefaultAsync(x => x.idEmpresa == idEmpresa);
            return obj == null ? new Empresas() : obj;
        }
        public async Task<List<Empresas>> ConsultarTodos()
        {
            return await _dbcontext.TEmpresas.ToListAsync();
        }

        public async Task<bool> Editar(long idEmpresa, Empresas empresas)
        {
            _dbcontext.TEmpresas.Add(empresas);
            _dbcontext.Entry(empresas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IEmpresasServicios
    {
        Task<long> Agregar(Empresas empresas);
        Task<bool> Editar(long idEmpresa, Empresas empresas);
        Task<Empresas> ConsultarPorId(long idEmpresa);
        Task<List<Empresas>> ConsultarTodos();
        Task Borrar(long idEmpresa);
    }
}
