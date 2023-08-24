using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class DepartamentosServicios : IDepartamentosServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public DepartamentosServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(Departamentos departamentos)
        {
            _dbcontext.TDepartamentos.Add(departamentos);
            await _dbcontext.SaveChangesAsync();
            return departamentos.idDepartamento;
            
        }

        public async Task Borrar(long idDepartamento)
        {
            var obj = await _dbcontext.TDepartamentos.FirstOrDefaultAsync(x => x.idDepartamento == idDepartamento);
            _dbcontext.TDepartamentos.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Departamentos> ConsultarPorId(long idDepartamento)
        {
            var obj = await _dbcontext.TDepartamentos.FirstOrDefaultAsync(x => x.idDepartamento == idDepartamento);
            return obj == null ? new Departamentos() : obj;
        }

        public async Task<bool> Editar(long idDepartamento, Departamentos departamentos)
        {
            _dbcontext.TDepartamentos.Add(departamentos);
            _dbcontext.Entry(departamentos).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<object?> ListarDepartamentos(int idPais)
        {
            return await _dbcontext.TDepartamentos.Where(x => x.idPais == idPais).ToListAsync();
        }
       
    }
    public interface IDepartamentosServicios
    {
        Task<long> Agregar(Departamentos departamentos);
        Task<bool> Editar(long idDepartamento, Departamentos departamentos);
        Task<Departamentos> ConsultarPorId(long idDepartamento);
        Task Borrar(long idDepartamento);
        Task<object?> ListarDepartamentos(int idPais);
    }
}
