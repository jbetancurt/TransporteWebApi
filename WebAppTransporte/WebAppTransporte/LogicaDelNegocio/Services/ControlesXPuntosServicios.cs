using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class ControlesXPuntosServicios : IControlesXPuntosServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public ControlesXPuntosServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(ControlesXPuntos controlesXPuntos)
        {
            try
            {
                _dbcontext.TControlesXPuntos.Add(controlesXPuntos);
                await _dbcontext.SaveChangesAsync();
                return controlesXPuntos.idControlXPunto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
                      
        }

        public async Task Borrar(long idControlXPunto)
        {
            var obj = await _dbcontext.TControlesXPuntos.FirstOrDefaultAsync(x => x.idControlXPunto == idControlXPunto);
            _dbcontext.TControlesXPuntos.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<ControlesXPuntos> ConsultarPorId(long idControlXPunto)
        {
            var obj = await _dbcontext.TControlesXPuntos.FirstOrDefaultAsync(x => x.idControlXPunto == idControlXPunto);
            return obj == null ? new ControlesXPuntos() : obj;
        }
        public async Task<object?> ConsultarTodos()
        {
            return await _dbcontext.TControlesXPuntos.ToListAsync();
        }

        public async Task<bool> Editar(long idControlXPunto, ControlesXPuntos controlesXPuntos)
        {
            _dbcontext.TControlesXPuntos.Add(controlesXPuntos);
            _dbcontext.Entry(controlesXPuntos).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    
    public interface IControlesXPuntosServicios
    {
        Task<long> Agregar(ControlesXPuntos controlesXPuntos);
        Task<bool> Editar(long idControlXPunto, ControlesXPuntos controlesXPuntos);
        Task<ControlesXPuntos> ConsultarPorId(long idControlXPunto);
        Task<object?> ConsultarTodos();
        Task Borrar(long idControlXPunto);
    }
}
