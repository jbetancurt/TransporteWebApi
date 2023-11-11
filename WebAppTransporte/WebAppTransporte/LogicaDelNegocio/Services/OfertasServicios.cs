using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class OfertasServicios : IOfertasServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public OfertasServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(Ofertas ofertas)
        {
            _dbcontext.TOfertas.Add(ofertas);
            await _dbcontext.SaveChangesAsync();
            return ofertas.idOferta;
            
        }

        public async Task Borrar(long idOferta)
        {
            var obj = await _dbcontext.TOfertas.FirstOrDefaultAsync(x => x.idOferta == idOferta);
            _dbcontext.TOfertas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Ofertas> ConsultarPorId(long idOferta)
        {
            var obj = await _dbcontext.TOfertas.FirstOrDefaultAsync(x => x.idOferta == idOferta);
            return obj == null ? new Ofertas() : obj;
        }


        public async Task<List<Ofertas>> ConsultarTodos()
        {
            return await _dbcontext.TOfertas.ToListAsync();
        }

        public async Task<List<Ofertas>> ConsultarXIdEmpresa(long idEmpresa)
        {
            return await _dbcontext.TOfertas.Where(x => x.idEmpresa == idEmpresa).ToListAsync();
        }

        public async Task<bool> Editar(long idOferta, Ofertas ofertas)
        {
            _dbcontext.TOfertas.Add(ofertas);
            _dbcontext.Entry(ofertas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IOfertasServicios
    {
        Task<long> Agregar(Ofertas ofertas);
        Task<bool> Editar(long idOferta, Ofertas ofertas);
        Task<Ofertas> ConsultarPorId(long idOferta);
        Task<List<Ofertas>> ConsultarTodos();
        Task<List<Ofertas>> ConsultarXIdEmpresa(long idEmpresa);
        Task Borrar(long idOferta);
    }
}
