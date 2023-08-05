using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class PersonasXVehiculosServicios : IPersonasXVehiculosServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public PersonasXVehiculosServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(PersonasXVehiculos personasXVehiculos)
        {
            _dbcontext.TPersonasXVehiculos.Add(personasXVehiculos);
            await _dbcontext.SaveChangesAsync();
            return personasXVehiculos.idPersonaXVehiculo;
            
        }

        public async Task Borrar(long idPersonaXVehiculo)
        {
            var obj = await _dbcontext.TPersonasXVehiculos.FirstOrDefaultAsync(x => x.idPersonaXVehiculo == idPersonaXVehiculo);
            _dbcontext.TPersonasXVehiculos.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<PersonasXVehiculos> ConsultarPorId(long idPersonaXVehiculo)
        {
            var obj = await _dbcontext.TPersonasXVehiculos.FirstOrDefaultAsync(x => x.idPersonaXVehiculo == idPersonaXVehiculo);
            return obj == null ? new PersonasXVehiculos() : obj;
        }

        public async Task<bool> Editar(long idPersonaXVehiculo, PersonasXVehiculos personasXVehiculos)
        {
            _dbcontext.TPersonasXVehiculos.Add(personasXVehiculos);
            _dbcontext.Entry(personasXVehiculos).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IPersonasXVehiculosServicios
    {
        Task<long> Agregar(PersonasXVehiculos personasXVehiculos);
        Task<bool> Editar(long idPersonaXVehiculo, PersonasXVehiculos personasXVehiculos);
        Task<PersonasXVehiculos> ConsultarPorId(long idPersonaXVehiculo);
        Task Borrar(long idPersonaXVehiculo);
    }
}
