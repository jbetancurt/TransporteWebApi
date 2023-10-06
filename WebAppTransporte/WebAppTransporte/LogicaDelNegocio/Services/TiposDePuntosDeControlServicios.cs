using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class TiposDePuntosDeControlServicios : ITiposDePuntosDeControlServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public TiposDePuntosDeControlServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(TiposDePuntosDeControl tiposDePuntosDeControl)
        {
            _dbcontext.TTiposDePuntosDeControl.Add(tiposDePuntosDeControl);
            await _dbcontext.SaveChangesAsync();
            return tiposDePuntosDeControl.idTipoDePuntoDeControl;
            
        }

        public async Task Borrar(long idTipoDePuntoDeControl)
        {
            var obj = await _dbcontext.TTiposDePuntosDeControl.FirstOrDefaultAsync(x => x.idTipoDePuntoDeControl == idTipoDePuntoDeControl);
            _dbcontext.TTiposDePuntosDeControl.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<TiposDePuntosDeControl> ConsultarPorId(long idTipoDePuntoDeControl)
        {
            var obj = await _dbcontext.TTiposDePuntosDeControl.FirstOrDefaultAsync(x => x.idTipoDePuntoDeControl == idTipoDePuntoDeControl);
            return obj == null ? new TiposDePuntosDeControl() : obj;
        }

        public async Task<bool> Editar(long idTipoDePuntoDeControl, TiposDePuntosDeControl tiposDePuntosDeControl)
        {
            _dbcontext.TTiposDePuntosDeControl.Add(tiposDePuntosDeControl);
            _dbcontext.Entry(tiposDePuntosDeControl).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<List<TiposDePuntosDeControl>> ConsultarTodos()
        {
            return await _dbcontext.TTiposDePuntosDeControl.ToListAsync();
        }
    }
    public interface ITiposDePuntosDeControlServicios
    {
        Task<long> Agregar(TiposDePuntosDeControl tiposDePuntosDeControl);
        Task<bool> Editar(long idTipoDePuntoDeControl, TiposDePuntosDeControl tiposDePuntosDeControl);
        Task<TiposDePuntosDeControl> ConsultarPorId(long idTipoDePuntoDeControl);
        Task Borrar(long idTipoDePuntoDeControl);
        Task<List<TiposDePuntosDeControl>> ConsultarTodos();
    }
}
