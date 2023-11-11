using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class TiposDePlantillasOfertasServicios : ITiposDePlantillasOfertasServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public TiposDePlantillasOfertasServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(TiposDePlantillasOfertas tiposdeplantillasofertas)
        {
            _dbcontext.TTiposDePlantillasOfertas.Add(tiposdeplantillasofertas);
            await _dbcontext.SaveChangesAsync();
            return tiposdeplantillasofertas.idTipoDePlantillaOferta;

        }

        public async Task Borrar(long idTipoDePlantillaOferta)
        {
            var obj = await _dbcontext.TTiposDePlantillasOfertas.FirstOrDefaultAsync(x => x.idTipoDePlantillaOferta == idTipoDePlantillaOferta);
            _dbcontext.TTiposDePlantillasOfertas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<TiposDePlantillasOfertas> ConsultarPorId(long idTipoDePlantillaOferta)
        {
            var obj = await _dbcontext.TTiposDePlantillasOfertas.FirstOrDefaultAsync(x => x.idTipoDePlantillaOferta == idTipoDePlantillaOferta);
            return obj == null ? new TiposDePlantillasOfertas() : obj;
        }

        public async Task<bool> Editar(long idTipoDePlantillaOferta, TiposDePlantillasOfertas tiposdeplantillasofertas)
        {
            _dbcontext.TTiposDePlantillasOfertas.Add(tiposdeplantillasofertas);
            _dbcontext.Entry(tiposdeplantillasofertas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<List<TiposDePlantillasOfertas>> ConsultarTodos()
        {
            return await _dbcontext.TTiposDePlantillasOfertas.ToListAsync();
        }

        public async Task<TiposDePlantillasOfertas> ConsultarPorEnum(string enumerador)
        {
            var obj = await _dbcontext.TTiposDePlantillasOfertas.Where(x => x.enumerador == enumerador).FirstOrDefaultAsync();
            return obj == null ? new TiposDePlantillasOfertas() : obj;
        }
    }
    public interface ITiposDePlantillasOfertasServicios
    {
        Task<long> Agregar(TiposDePlantillasOfertas tiposdeplantillasofertas);
        Task<bool> Editar(long idTipoDePlantillaOferta, TiposDePlantillasOfertas tiposdeplantillasofertas);
        Task<TiposDePlantillasOfertas> ConsultarPorId(long idTipoDePlantillaOferta);
        Task Borrar(long idTipoDePlantillaOferta);
        Task<List<TiposDePlantillasOfertas>> ConsultarTodos();
        Task<TiposDePlantillasOfertas> ConsultarPorEnum(string enumerador);
    }
}
