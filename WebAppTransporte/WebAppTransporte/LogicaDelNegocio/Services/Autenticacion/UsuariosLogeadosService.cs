using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Entidades.Autenticacion;

namespace WebAppTransporte.LogicaDelNegocio.Services.Autenticacion
{
	public class UsuariosLogeadosService : IUsuariosLogeadosService
	{
		protected readonly DbContextsTransporte _dbcontext;

		public UsuariosLogeadosService(DbContextsTransporte dbcontext)
		{
			_dbcontext = dbcontext;
		}

		public async Task<long> Agregar(UsuariosLogeados usuariosLogeados)
		{
			_dbcontext.TUsuariosLogeados.Add(usuariosLogeados);
			await _dbcontext.SaveChangesAsync();
			return usuariosLogeados.idUsuarioLogeado;

		}

		public async Task Borrar(long idUsuarioLogeado)
		{
			var obj = await _dbcontext.TUsuariosLogeados.FirstOrDefaultAsync(x => x.idUsuarioLogeado == idUsuarioLogeado);
			_dbcontext.TUsuariosLogeados.Remove(obj);
			await _dbcontext.SaveChangesAsync();
		}

		public async Task<UsuariosLogeados> ConsultarPorId(long idUsuarioLogeado)
		{
			var obj = await _dbcontext.TUsuariosLogeados.FirstOrDefaultAsync(x => x.idUsuarioLogeado == idUsuarioLogeado);
			return obj == null ? new UsuariosLogeados() : obj;
		}

		public async Task<bool> Editar(long idUsuarioLogeado, UsuariosLogeados UsuariosLogeados)
		{
			_dbcontext.TUsuariosLogeados.Add(UsuariosLogeados);
			_dbcontext.Entry(UsuariosLogeados).State = EntityState.Modified;
			await _dbcontext.SaveChangesAsync();
			return true;
		}
	}

	public interface IUsuariosLogeadosService
	{
		Task<long> Agregar(UsuariosLogeados usuariosLogeados);
		Task<bool> Editar(long idUsuarioLogeado, UsuariosLogeados UsuariosLogeados);
		Task<UsuariosLogeados> ConsultarPorId(long idUsuarioLogeado);
		Task Borrar(long idUsuarioLogeado);
	}
}
