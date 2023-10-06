using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class AccesosControlXPuntosServicios : IAccesosControlXPuntosServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public AccesosControlXPuntosServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(AccesosControlXPuntos accesosControlXPuntos)
        {
            _dbcontext.TAccesosControlXPuntos.Add(accesosControlXPuntos);
            await _dbcontext.SaveChangesAsync();
            return accesosControlXPuntos.idAccesoControlXPunto;
            
        }

        public async Task Borrar(long idAccesoControlXPunto)
        {
            var obj = await _dbcontext.TAccesosControlXPuntos.FirstOrDefaultAsync(x => x.idAccesoControlXPunto == idAccesoControlXPunto);
            _dbcontext.TAccesosControlXPuntos.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<AccesosControlXPuntos> ConsultarPorId(long idAccesoControlXPunto)
        {
            var obj = await _dbcontext.TAccesosControlXPuntos.FirstOrDefaultAsync(x => x.idAccesoControlXPunto == idAccesoControlXPunto);
            return obj == null ? new AccesosControlXPuntos() : obj;
        }

        public async Task<List<AccesosControlXPuntos>> ConsultarTodos()
        {
            return await _dbcontext.TAccesosControlXPuntos.ToListAsync();
        }

        public async Task<bool> Editar(long idAccesoControlXPunto, AccesosControlXPuntos accesosControlXPuntos)
        {
            _dbcontext.TAccesosControlXPuntos.Add(accesosControlXPuntos);
            _dbcontext.Entry(accesosControlXPuntos).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IAccesosControlXPuntosServicios
    {
        Task<long> Agregar(AccesosControlXPuntos accesosControlXPuntos);
        Task<bool> Editar(long idAccesoControlXPunto, AccesosControlXPuntos accesosControlXPuntos);
        Task<AccesosControlXPuntos> ConsultarPorId(long idAccesoControlXPunto);
        Task<List<AccesosControlXPuntos>> ConsultarTodos();
        Task Borrar(long idAccesoControlXPunto);
    }
}
