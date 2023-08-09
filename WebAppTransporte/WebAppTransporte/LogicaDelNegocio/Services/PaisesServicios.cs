using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class PaisesServicios : IPaisesServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public PaisesServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(Paises paises)
        {
            _dbcontext.TPaises.Add(paises);
            await _dbcontext.SaveChangesAsync();
            return paises.idPais;
            
        }

        public async Task Borrar(long idPais)
        {
            var obj = await _dbcontext.TPaises.FirstOrDefaultAsync(x => x.idPais == idPais);
            _dbcontext.TPaises.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Paises> ConsultarPorId(long idPais)
        {
            var obj = await _dbcontext.TPaises.FirstOrDefaultAsync(x => x.idPais == idPais);
            return obj == null ? new Paises() : obj;
        }

        public async Task<bool> Editar(long idPais, Paises paises)
        {
            _dbcontext.TPaises.Add(paises);
            _dbcontext.Entry(paises).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IPaisesServicios
    {
        Task<long> Agregar(Paises paises);
        Task<bool> Editar(long idPais, Paises paises);
        Task<Paises> ConsultarPorId(long idPais);
        Task Borrar(long idPais);
    }
}
