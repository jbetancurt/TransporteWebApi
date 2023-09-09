using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class PersonasServicios : IPersonasServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public PersonasServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(Personas personas)
        {
            _dbcontext.TPersonas.Add(personas);
            await _dbcontext.SaveChangesAsync();
            return personas.idPersona;
            
        }

        public async Task Borrar(long idPersona)
        {
            var obj = await _dbcontext.TPersonas.FirstOrDefaultAsync(x => x.idPersona == idPersona);
            _dbcontext.TPersonas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Personas> ConsultarPorId(long idPersona)
        {
            var obj = await _dbcontext.TPersonas.FirstOrDefaultAsync(x => x.idPersona == idPersona);
            return obj == null ? new Personas() : obj;
        }

        public async Task<object?> ConsultarTodos()
        {
            return await _dbcontext.TPersonas.ToListAsync();
        }


        public async Task<bool> Editar(long idPersona, Personas personas)
        {
            _dbcontext.TPersonas.Add(personas);
            _dbcontext.Entry(personas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IPersonasServicios
    {
        Task<long> Agregar(Personas personas);
        Task<bool> Editar(long idPersona, Personas personas);
        Task<Personas> ConsultarPorId(long idPersona);
        Task<object?> ConsultarTodos();
        Task Borrar(long idPersona);
    }
}
