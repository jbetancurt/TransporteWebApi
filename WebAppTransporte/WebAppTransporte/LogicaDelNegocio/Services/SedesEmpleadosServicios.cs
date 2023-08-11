using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class SedesEmpleadosServicios : ISedesEmpleadosServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public SedesEmpleadosServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(SedesEmpleados sedesEmpleados)
        {
            _dbcontext.TSedesEmpleados.Add(sedesEmpleados);
            await _dbcontext.SaveChangesAsync();
            return sedesEmpleados.idSedeEmpleado;
            
        }

        public async Task Borrar(long idSedeEmpleado)
        {
            var obj = await _dbcontext.TSedesEmpleados.FirstOrDefaultAsync(x => x.idSedeEmpleado == idSedeEmpleado);
            _dbcontext.TSedesEmpleados.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<SedesEmpleados> ConsultarPorId(long idSedeEmpleado)
        {
            var obj = await _dbcontext.TSedesEmpleados.FirstOrDefaultAsync(x => x.idSedeEmpleado == idSedeEmpleado);
            return obj == null ? new SedesEmpleados() : obj;
        }

        public async Task<bool> Editar(long idSedeEmpleado, SedesEmpleados sedesEmpleados)
        {
            _dbcontext.TSedesEmpleados.Add(sedesEmpleados);
            _dbcontext.Entry(sedesEmpleados).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface ISedesEmpleadosServicios
    {
        Task<long> Agregar(SedesEmpleados sedesEmpleados);
        Task<bool> Editar(long idSedeEmpleado, SedesEmpleados sedesEmpleados);
        Task<SedesEmpleados> ConsultarPorId(long idSedeEmpleado);
        Task Borrar(long idSedeEmpleado);
    }
}
