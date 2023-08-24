﻿using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class TiposOrientacionesDeLaOfertaServicios : ITiposOrientacionesDeLaOfertaServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public TiposOrientacionesDeLaOfertaServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(TiposOrientacionesDeLaOferta tiposOrientacionesDeLaOferta)
        {
            _dbcontext.TTiposOrientacionesDeLaOferta.Add(tiposOrientacionesDeLaOferta);
            await _dbcontext.SaveChangesAsync();
            return tiposOrientacionesDeLaOferta.idTipoOrientacionOferta;
            
        }

        public async Task Borrar(long idTipoOrientacionOferta)
        {
            var obj = await _dbcontext.TTiposOrientacionesDeLaOferta.FirstOrDefaultAsync(x => x.idTipoOrientacionOferta == idTipoOrientacionOferta);
            _dbcontext.TTiposOrientacionesDeLaOferta.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<TiposOrientacionesDeLaOferta> ConsultarPorId(long idTipoOrientacionOferta)
        {
            var obj = await _dbcontext.TTiposOrientacionesDeLaOferta.FirstOrDefaultAsync(x => x.idTipoOrientacionOferta == idTipoOrientacionOferta);
            return obj == null ? new TiposOrientacionesDeLaOferta() : obj;
        }

        public async Task<bool> Editar(long idTipoOrientacionOferta, TiposOrientacionesDeLaOferta tiposOrientacionesDeLaOferta)
        {
            _dbcontext.TTiposOrientacionesDeLaOferta.Add(tiposOrientacionesDeLaOferta);
            _dbcontext.Entry(tiposOrientacionesDeLaOferta).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<object?> ConsultarTodos()
        {
            return await _dbcontext.TTiposOrientacionesDeLaOferta.ToListAsync();
        }
    }
    public interface ITiposOrientacionesDeLaOfertaServicios
    {
        Task<long> Agregar(TiposOrientacionesDeLaOferta tiposOrientacionesDeLaOferta);
        Task<bool> Editar(long idTipoOrientacionOferta, TiposOrientacionesDeLaOferta tiposOrientacionesDeLaOferta);
        Task<TiposOrientacionesDeLaOferta> ConsultarPorId(long idTipoOrientacionOferta);
        Task Borrar(long idTipoOrientacionOferta);
        Task<object?> ConsultarTodos();
    }
}
