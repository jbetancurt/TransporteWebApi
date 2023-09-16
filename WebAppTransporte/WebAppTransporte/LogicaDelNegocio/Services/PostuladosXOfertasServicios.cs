using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class PostuladosXOfertasServicios : IPostuladosXOfertasServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public PostuladosXOfertasServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(PostuladosXOfertas postuladosXOfertas)
        {
            _dbcontext.TPostuladosXOfertas.Add(postuladosXOfertas);
            await _dbcontext.SaveChangesAsync();
            return postuladosXOfertas.idPostuladoXOferta;
            
        }

        public async Task Borrar(long idPostuladoXOferta)
        {
            var obj = await _dbcontext.TPostuladosXOfertas.FirstOrDefaultAsync(x => x.idPostuladoXOferta == idPostuladoXOferta);
            _dbcontext.TPostuladosXOfertas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<PostuladosXOfertas> ConsultarPorId(long idPostuladoXOferta)
        {
            var obj = await _dbcontext.TPostuladosXOfertas.FirstOrDefaultAsync(x => x.idPostuladoXOferta == idPostuladoXOferta);
            return obj == null ? new PostuladosXOfertas() : obj;
        }

        public async Task<object?> ConsultarTodos()
        {
            return await _dbcontext.TPostuladosXOfertas.ToListAsync();
        }

        public async Task<bool> Editar(long idPostuladoXOferta, PostuladosXOfertas postuladosXOfertas)
        {
            _dbcontext.TPostuladosXOfertas.Add(postuladosXOfertas);
            _dbcontext.Entry(postuladosXOfertas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IPostuladosXOfertasServicios
    {
        Task<long> Agregar(PostuladosXOfertas postuladosXOfertas);
        Task<bool> Editar(long idPostuladoXOferta, PostuladosXOfertas postuladosXOfertas);
        Task<PostuladosXOfertas> ConsultarPorId(long idPostuladoXOferta);
        Task<object?> ConsultarTodos();
        Task Borrar(long idPostuladoXOferta);
    }
}
