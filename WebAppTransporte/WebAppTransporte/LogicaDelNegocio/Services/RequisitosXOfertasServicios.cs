﻿using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class RequisitosXOfertasServicios : IRequisitosXOfertasServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public RequisitosXOfertasServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(RequisitosXOfertas requisitosXOfertas)
        {
            _dbcontext.TRequisitosXOfertas.Add(requisitosXOfertas);
            await _dbcontext.SaveChangesAsync();
            return requisitosXOfertas.idRequisitoXOferta;
            
        }

        public async Task Borrar(long idRequisitoXOferta)
        {
            var obj = await _dbcontext.TRequisitosXOfertas.FirstOrDefaultAsync(x => x.idRequisitoXOferta == idRequisitoXOferta);
            _dbcontext.TRequisitosXOfertas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task BorrarPorIdOferta(long idOferta)
        {
            var obj = await _dbcontext.TRequisitosXOfertas.Where(x => x.idOferta == idOferta).ToListAsync();
            _dbcontext.TRequisitosXOfertas.RemoveRange(obj);
            await _dbcontext.SaveChangesAsync();
        }   
        public async Task<RequisitosXOfertas> ConsultarPorId(long idRequisitoXOferta)
        {
            var obj = await _dbcontext.TRequisitosXOfertas.FirstOrDefaultAsync(x => x.idRequisitoXOferta == idRequisitoXOferta);
            return obj == null ? new RequisitosXOfertas() : obj;
        }

        public async Task<List<RequisitosXOfertas>> ConsultarTodos()
        {
            return await _dbcontext.TRequisitosXOfertas.ToListAsync();
        }

        public async Task<List<RequisitosXOfertas>> ConsultarXOferta(long idOferta)
        {
            return await _dbcontext.TRequisitosXOfertas.Where(x => x.idOferta == idOferta).ToListAsync();
        }

        public async Task<bool> Editar(long idRequisitoXOferta, RequisitosXOfertas requisitosXOfertas)
        {
            _dbcontext.TRequisitosXOfertas.Add(requisitosXOfertas);
            _dbcontext.Entry(requisitosXOfertas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IRequisitosXOfertasServicios
    {
        Task<long> Agregar(RequisitosXOfertas requisitosXOfertas);
        Task<bool> Editar(long idRequisitoXOferta, RequisitosXOfertas requisitosXOfertas);
        Task<RequisitosXOfertas> ConsultarPorId(long idRequisitoXOferta);
        Task<List<RequisitosXOfertas>> ConsultarTodos();
        Task<List<RequisitosXOfertas>> ConsultarXOferta(long idOferta);
        Task Borrar(long idRequisitoXOferta);
        Task BorrarPorIdOferta(long idOferta);
    }
}
