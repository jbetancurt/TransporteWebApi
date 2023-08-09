using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class TiposDeAccionesEnDestinoDeLaRutaServicios : ITiposDeAccionesEnDestinoDeLaRutaServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public TiposDeAccionesEnDestinoDeLaRutaServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(TiposDeAccionesEnDestinoDeLaRuta tiposDeAccionesEnDestinoDeLaRuta)
        {
            _dbcontext.TTiposDeAccionesEnDestinoDeLaRuta.Add(tiposDeAccionesEnDestinoDeLaRuta);
            await _dbcontext.SaveChangesAsync();
            return tiposDeAccionesEnDestinoDeLaRuta.idTipoDeAccionEnDestinoDeLaRuta;
            
        }

        public async Task Borrar(long idTipoDeAccionEnDestinoDeLaRuta)
        {
            var obj = await _dbcontext.TTiposDeAccionesEnDestinoDeLaRuta.FirstOrDefaultAsync(x => x.idTipoDeAccionEnDestinoDeLaRuta == idTipoDeAccionEnDestinoDeLaRuta);
            _dbcontext.TTiposDeAccionesEnDestinoDeLaRuta.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<TiposDeAccionesEnDestinoDeLaRuta> ConsultarPorId(long idTipoDeAccionEnDestinoDeLaRuta)
        {
            var obj = await _dbcontext.TTiposDeAccionesEnDestinoDeLaRuta.FirstOrDefaultAsync(x => x.idTipoDeAccionEnDestinoDeLaRuta == idTipoDeAccionEnDestinoDeLaRuta);
            return obj == null ? new TiposDeAccionesEnDestinoDeLaRuta() : obj;
        }

        public async Task<bool> Editar(long idTipoDeAccionEnDestinoDeLaRuta, TiposDeAccionesEnDestinoDeLaRuta tiposDeAccionesEnDestinoDeLaRuta)
        {
            _dbcontext.TTiposDeAccionesEnDestinoDeLaRuta.Add(tiposDeAccionesEnDestinoDeLaRuta);
            _dbcontext.Entry(tiposDeAccionesEnDestinoDeLaRuta).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true
        }
    }
    public interface ITiposDeAccionesEnDestinoDeLaRutaServicios
    {
        Task<long> Agregar(TiposDeAccionesEnDestinoDeLaRuta tiposDeAccionesEnDestinoDeLaRuta);
        Task<bool> Editar(long idTipoDeAccionEnDestinoDeLaRuta, TiposDeAccionesEnDestinoDeLaRuta tiposDeAccionesEnDestinoDeLaRuta);
        Task<TiposDeAccionesEnDestinoDeLaRuta> ConsultarPorId(long idTipoDeAccionEnDestinoDeLaRuta);
        Task Borrar(long idTipoDeAccionEnDestinoDeLaRuta);
    }
}
