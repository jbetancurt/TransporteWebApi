using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class CiudadesServicios : ICiudadesServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public CiudadesServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(Ciudades ciudades)
        {
            _dbcontext.TCiudades.Add(ciudades);
            await _dbcontext.SaveChangesAsync();
            return ciudades.idCiudad;
            
        }

        public async Task Borrar(long idCiudad)
        {
            var obj = await _dbcontext.TCiudades.FirstOrDefaultAsync(x => x.idCiudad == idCiudad);
            _dbcontext.TCiudades.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Ciudades> ConsultarPorId(long idCiudad)
        {
            var obj = await _dbcontext.TCiudades.FirstOrDefaultAsync(x => x.idCiudad == idCiudad);
            return obj == null ? new Ciudades() : obj;
        }

        public async Task<bool> Editar(long idCiudad, Ciudades ciudades)
        {
            _dbcontext.TCiudades.Add(ciudades);
            _dbcontext.Entry(ciudades).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<object?> ListarCiudades(int idDepartamento)
        {
            return await _dbcontext.TCiudades.Where(x => x.idDepartamento == idDepartamento).ToListAsync();
        }

    }
    public interface ICiudadesServicios
    {
        Task<long> Agregar(Ciudades ciudades);
        Task<bool> Editar(long idCiudad, Ciudades ciudades);
        Task<Ciudades> ConsultarPorId(long idCiudad);
        Task Borrar(long idCiudad);
        Task<object?> ListarCiudades(int idDepartamento);
    }
}
