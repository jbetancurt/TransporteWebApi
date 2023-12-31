﻿
using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class CargasXOfertasServicios : ICargasXOfertasServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public CargasXOfertasServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(CargasXOfertas cargasXOfertas)
        {
            _dbcontext.TCargasXOfertas.Add(cargasXOfertas);
            await _dbcontext.SaveChangesAsync();
            return cargasXOfertas.idCargaXOferta;

        }

        public async Task Borrar(long idCargaXOferta)
        {
            var obj = await _dbcontext.TCargasXOfertas.FirstOrDefaultAsync(x => x.idCargaXOferta == idCargaXOferta);
            _dbcontext.TCargasXOfertas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task BorrarPorIdOferta(long idOferta)
        {
            var obj = await _dbcontext.TCargasXOfertas.Where(x => x.idOferta == idOferta).ToListAsync();
            _dbcontext.TCargasXOfertas.RemoveRange(obj);
            await _dbcontext.SaveChangesAsync();
        }   

        public async Task<CargasXOfertas> ConsultarPorId(long idCargaXOferta)
        {
            var obj = await _dbcontext.TCargasXOfertas.FirstOrDefaultAsync(x => x.idCargaXOferta == idCargaXOferta);
            return obj == null ? new CargasXOfertas() : obj;
        }

        public async Task<List<CargasXOfertas>> ConsultarTodos()
        {
            return await _dbcontext.TCargasXOfertas.ToListAsync();
        }

        public async Task<List<CargasXOfertas>> ConsultarXOferta(long idOferta)
        {
            return await _dbcontext.TCargasXOfertas.Where(x => x.idOferta == idOferta).ToListAsync();
        }

        public async Task<bool> Editar(long idCargaXOferta, CargasXOfertas cargasXOfertas)
        {
            _dbcontext.TCargasXOfertas.Add(cargasXOfertas);
            _dbcontext.Entry(cargasXOfertas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface ICargasXOfertasServicios
    {
        Task<long> Agregar(CargasXOfertas cargasXOfertas);
        Task<bool> Editar(long idCargaXOferta, CargasXOfertas cargasXOfertas);
        Task<CargasXOfertas> ConsultarPorId(long idCargaXOferta);
        Task<List<CargasXOfertas>> ConsultarTodos();
        Task<List<CargasXOfertas>> ConsultarXOferta(long idOferta);
        Task Borrar(long idCargaXOferta);
        Task BorrarPorIdOferta(long idOferta);
    }
}
