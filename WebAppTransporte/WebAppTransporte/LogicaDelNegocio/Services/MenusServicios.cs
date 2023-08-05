using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.Services
{
    public class MenusServicios : IMenusServicios
    {
        protected readonly DbContextsTransporte _dbcontext;

        public MenusServicios(DbContextsTransporte dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<long> Agregar(Menus menus)
        {
            _dbcontext.TMenus.Add(menus);
            await _dbcontext.SaveChangesAsync();
            return menus.idMenu;
        }

        public async Task Borrar(long idmenu)
        {
            var obj = await _dbcontext.TMenus.FirstOrDefaultAsync(x => x.idMenu == idmenu);
            _dbcontext.TMenus.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Menus> ConsultarPorId(long idmenu)
        {
            var obj = await _dbcontext.TMenus.FirstOrDefaultAsync(x => x.idMenu == idmenu);
            return obj == null ? new Menus() : obj;
        }

        public async Task<bool> Editar(long idMenu, Menus menus)
        {
            _dbcontext.TMenus.Add(menus);
            _dbcontext.Entry(menus).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IMenusServicios
    {
        Task<long> Agregar(Menus menus);
        Task<bool> Editar(long idMenu, Menus menus);
        Task<Menus> ConsultarPorId(long idmenu);
        Task Borrar(long idmenu);
    }
}
