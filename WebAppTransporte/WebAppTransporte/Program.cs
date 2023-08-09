using Microsoft.EntityFrameworkCore;
using WebAppTransporte.LogicaDelNegocio.DbContexts;
using WebAppTransporte.LogicaDelNegocio.Entidades;
using WebAppTransporte.LogicaDelNegocio.Services;

var builder = WebApplication.CreateBuilder(args);

var strDbConn = builder.Configuration.GetConnectionString("ConexionDb");

//aca ubicamos el contex para conexion a base de datos
builder.Services.AddDbContext<DbContextsTransporte>(options =>
                options.UseSqlServer(strDbConn, ef => ef.MigrationsAssembly(typeof(DbContextsTransporte).Assembly.FullName)), ServiceLifetime.Scoped);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IAdjuntosServicios, AdjuntosServicios>();
builder.Services.AddTransient<ICarroceriasXTiposDeVehiculosServicios, CarroceriasXTiposDeVehiculosServicios>();
builder.Services.AddTransient<ICiudadesServicios, CiudadesServicios>();
builder.Services.AddTransient<IControlesXPuntosServicios, ControlesXPuntosServicios>();
builder.Services.AddTransient<IDepartamentosServicios, DepartamentosServicios>();
builder.Services.AddTransient<IEstadosPorRutasServicios, EstadosPorRutasServicios>();
builder.Services.AddTransient<IMenusServicios, MenusServicios>();
builder.Services.AddTransient<IPaisesServicios, PaisesServicios>();
builder.Services.AddTransient<IRolesServicios, RolesServicios>();
builder.Services.AddTransient<ITiposDeAccionesEnDestinoDeLaRutaServicios, TiposDeAccionesEnDestinoDeLaRutaServicios>();
builder.Services.AddTransient<ITiposDeArchivosAdjuntosServicios, TiposDeArchivosAdjuntosServicios>();
builder.Services.AddTransient<ITiposDeCarroceriasServicios, TiposDeCarroceriasServicios>();
builder.Services.AddTransient<ITiposDeDocumentosServicios, TiposDeDocumentosServicios>();
builder.Services.AddTransient<ITiposDeEmpresasServicios, TiposDeEmpresasServicios>();
builder.Services.AddTransient<ITiposDePersonasPorVehiculosServicios, TiposDePersonasPorVehiculosServicios>();
builder.Services.AddTransient<ITiposDePuntosDeControlServicios, TiposDePuntosDeControlServicios>();
builder.Services.AddTransient<ITiposDeRequisitosServicios, TiposDeRequisitosServicios>();
builder.Services.AddTransient<ITiposDeRolesServicios, TiposDeRolesServicios>();
builder.Services.AddTransient<ITiposDeVehiculosServicios, TiposDeVehiculosServicios>();
builder.Services.AddTransient<ITiposOrientacionesDeLaOfertaServicios, TiposOrientacionesDeLaOfertaServicios>();
builder.Services.AddTransient<IAccesosControlXPuntosServicios, AccesosControlXPuntosServicios>();
builder.Services.AddTransient<IDesplazamientosXRutasXVehiculosServicios, DesplazamientosXRutasXVehiculosServicios>();
builder.Services.AddTransient<IDestinosServicios, DestinosServicios>();
builder.Services.AddTransient<IDestinosXEmpresasServicios, DestinosXEmpresasServicios>();
builder.Services.AddTransient<IDestinosXRutasXVehiculosServicios, DestinosXRutasXVehiculosServicios>();
builder.Services.AddTransient<IEmpresasServicios, EmpresasServicios>();
builder.Services.AddTransient<IOfertasServicios, OfertasServicios>();
builder.Services.AddTransient<IPersonasServicios, PersonasServicios>();
builder.Services.AddTransient<IPersonasXVehiculosServicios, PersonasXVehiculosServicios>();
builder.Services.AddTransient<IPostuladosXOfertasServicios, PostuladosXOfertasServicios>();
builder.Services.AddTransient<IRequisitosServicios, RequisitosServicios>();
builder.Services.AddTransient<IRequisitosAdjuntosServicios, RequisitosAdjuntosServicios>();
builder.Services.AddTransient<IRolesXEmpresasServicios, RolesXEmpresasServicios>();
builder.Services.AddTransient<IRolXUsuariosServicios, RolXUsuariosServicios>();
builder.Services.AddTransient<IRutasXVehiculosServicios, RutasXVehiculosServicios>();
builder.Services.AddTransient<ISedesServicios, SedesServicios>();
builder.Services.AddTransient<ISedesEmpleadosServicios, SedesEmpleadosServicios>();
builder.Services.AddTransient<IUsuariosServicios, UsuariosServicios>();
builder.Services.AddTransient<IVehiculosServicios, VehiculosServicios>();
builder.Services.AddTransient<IPlantillas_OfertasServicios, Plantillas_OfertasServicios>();
builder.Services.AddTransient<IPlantillas_RequisitosXOfertasServicios, Plantillas_RequisitosXOfertasServicios>();







builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "TransporteWebCORS",
                      builder =>
                      {
                          builder
                             .AllowAnyOrigin()
                             .AllowAnyMethod()
                             .AllowAnyHeader();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("TransporteWebCORS");
app.Run();
