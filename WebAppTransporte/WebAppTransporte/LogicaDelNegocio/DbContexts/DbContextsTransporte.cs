using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.Entidades;

namespace WebAppTransporte.LogicaDelNegocio.DbContexts
{
    public class DbContextsTransporte : DbContext
    {
        public DbContextsTransporte(DbContextOptions<DbContextsTransporte> options) : base(options)
        {

        }
        public DbSet<Adjuntos> TAdjuntos { get; set; }
        public DbSet<CarroceriasXTiposDeVehiculos> TCarroceriasXTiposDeVehiculos { get; set; }
        public DbSet<Ciudades> TCiudades { get; set; }
        public DbSet<ControlesXPuntos> TControlesXPuntos { get; set; }
        public DbSet<Departamentos> TDepartamentos { get; set; }
        public DbSet<EstadosPorRutas> TEstadosPorRutas { get; set; }
        public DbSet<Menus> TMenus { get; set; }
        public DbSet<Paises> TPaises { get; set; }
        public DbSet<Roles> TRoles { get; set; }
        public DbSet<TiposDeAccionesEnDestinoDeLaRuta> TTiposDeAccionesEnDestinoDeLaRuta { get; set; }
        public DbSet<TiposDeArchivosAdjuntos> TTiposDeArchivosAdjuntos { get; set; }
        public DbSet<TiposDeCarrocerias> TTiposDeCarrocerias { get; set; }
        public DbSet<TiposDeDocumentos> TTiposDeDocumentos { get; set; }
        public DbSet<TiposDeEmpresas> TTiposDeEmpresas { get; set; }
        public DbSet<TiposDePersonasPorVehiculos> TTiposDePersonasPorVehiculos { get; set; }
        public DbSet<TiposDePuntosDeControl> TTiposDePuntosDeControl { get; set; }
        public DbSet<TiposDeRequisitos> TTiposDeRequisitos { get; set; }
        public DbSet<TiposDeRoles> TTiposDeRoles { get; set; }
        public DbSet<TiposDeVehiculos> TTiposDeVehiculos { get; set; }
        public DbSet<TiposOrientacionesDeLaOferta> TTiposOrientacionesDeLaOferta { get; set; }
        public DbSet<AccesosControlXPuntos> TAccesosControlXPuntos { get; set; }
        public DbSet<DesplazamientosXRutasXVehiculos> TDesplazamientosXRutasXVehiculos { get; set; }
        public DbSet<Destinos> TDestinos { get; set; }
        public DbSet<DestinosXEmpresas> TDestinosXEmpresas { get; set; }
        public DbSet<DestinosXRutasXVehiculos> TDestinosXRutasXVehiculos { get; set; }
        public DbSet<Empresas> TEmpresas { get; set; }
        public DbSet<Ofertas> TOfertas { get; set; }
        public DbSet<Personas> TPersonas { get; set; }
        public DbSet<PersonasXVehiculos> TPersonasXVehiculos { get; set; }
        public DbSet<PostuladosXOfertas> TPostuladosXOfertas { get; set; }
        public DbSet<Requisitos> TRequisitos { get; set; }
        public DbSet<RequisitosAdjuntos> TRequisitosAdjuntos { get; set; }
        public DbSet<RequisitosXOfertas> TRequisitosXOfertas { get; set; }
        public DbSet<RolesXEmpresas> TRolesXEmpresas { get; set; }
        public DbSet<RolXUsuarios> TRolXUsuarios { get; set; }
        public DbSet<RutasXVehiculos> TRutasXVehiculos { get; set; }
        public DbSet<Sedes> TSedes { get; set; }
        public DbSet<SedesEmpleados> TSedesEmpleados { get; set; }
        public DbSet<Usuarios> TUsuarios { get; set; }
        public DbSet<Vehiculos> TVehiculos { get; set; }
        public DbSet<VehiculosXEmpresas> TVehiculosXEmpresas { get; set; }
        public DbSet<Plantillas_Ofertas> TPlantillas_Ofertas { get; set; }
        public DbSet<Plantillas_RequisitosXOfertas> TPlantillas_RequisitosXOfertas { get; set; }
    }

}
