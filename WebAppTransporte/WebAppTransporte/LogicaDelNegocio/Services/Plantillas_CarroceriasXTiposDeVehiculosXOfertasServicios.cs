﻿
using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class Plantillas_CarroceriasXTiposDeVehiculosXOfertasServicios : IPlantillas_CarroceriasXTiposDeVehiculosXOfertasServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public Plantillas_CarroceriasXTiposDeVehiculosXOfertasServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(Plantillas_CarroceriasXTiposDeVehiculosXOfertas plantillas_CarroceriasXTiposDeVehiculosXOfertas)
        {
            _dbcontext.TPlantillas_CarroceriasXTiposDeVehiculosXOfertas.Add(plantillas_CarroceriasXTiposDeVehiculosXOfertas);
            await _dbcontext.SaveChangesAsync();
            return plantillas_CarroceriasXTiposDeVehiculosXOfertas.idCarroceriaXTipoDeVehiculoXOferta;

        }

        public async Task Borrar(long idCarroceriaXTipoDeVehiculoXOferta)
        {
            var obj = await _dbcontext.TPlantillas_CarroceriasXTiposDeVehiculosXOfertas.FirstOrDefaultAsync(x => x.idCarroceriaXTipoDeVehiculoXOferta == idCarroceriaXTipoDeVehiculoXOferta);
            _dbcontext.TPlantillas_CarroceriasXTiposDeVehiculosXOfertas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Plantillas_CarroceriasXTiposDeVehiculosXOfertas> ConsultarPorId(long idCarroceriaXTipoDeVehiculoXOferta)
        {
            var obj = await _dbcontext.TPlantillas_CarroceriasXTiposDeVehiculosXOfertas.FirstOrDefaultAsync(x => x.idCarroceriaXTipoDeVehiculoXOferta == idCarroceriaXTipoDeVehiculoXOferta);
            return obj == null ? new Plantillas_CarroceriasXTiposDeVehiculosXOfertas() : obj;
        }

        public async Task<object?> ConsultarTodos()
        {
            return await _dbcontext.TPlantillas_CarroceriasXTiposDeVehiculosXOfertas.ToListAsync();
        }

        public async Task<bool> Editar(long idCarroceriaXTipoDeVehiculoXOferta, Plantillas_CarroceriasXTiposDeVehiculosXOfertas plantillas_CarroceriasXTiposDeVehiculosXOfertas)
        {
            _dbcontext.TPlantillas_CarroceriasXTiposDeVehiculosXOfertas.Add(plantillas_CarroceriasXTiposDeVehiculosXOfertas);
            _dbcontext.Entry(plantillas_CarroceriasXTiposDeVehiculosXOfertas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }

    }
    public interface IPlantillas_CarroceriasXTiposDeVehiculosXOfertasServicios
    {
        Task<long> Agregar(Plantillas_CarroceriasXTiposDeVehiculosXOfertas plantillas_CarroceriasXTiposDeVehiculosXOfertas);
        Task<bool> Editar(long idCarroceriaXTipoDeVehiculoXOferta, Plantillas_CarroceriasXTiposDeVehiculosXOfertas plantillas_CarroceriasXTiposDeVehiculosXOfertas);
        Task<Plantillas_CarroceriasXTiposDeVehiculosXOfertas> ConsultarPorId(long idCarroceriaXTipoDeVehiculoXOferta);
        Task<object?> ConsultarTodos();
        Task Borrar(long idCarroceriaXTipoDeVehiculoXOferta);
    }
}