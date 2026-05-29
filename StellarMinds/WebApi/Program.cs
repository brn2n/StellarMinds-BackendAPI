using StellarMinds.Infraestructura.EF;
using StellarMinds.Infraestructura.InterfacesRepositorio.Equipos;
using StellarMinds.Infraestructura.InterfacesRepositorio.Prestamos;
using StellarMinds.Infraestructura.InterfacesRepositorio.Usuarios;
using StellarMinds.LogicaAplicacion.CasosUso.Equipos;
using StellarMinds.LogicaAplicacion.CasosUso.PrestamoCU;
using StellarMinds.LogicaAplicacion.CasosUso.Usuarios;
using StellarMinds.LogicaAplicacion.Dtos.Equipos;
using StellarMinds.LogicaAplicacion.Dtos.PrestamoDtos;
using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.Entidades.Prestamos;
using RepositorioEquipo = StellarMinds.Infraestructura.EF.RepositorioEquipo;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

// Contenedor de inyeccion de dependencias
// inyecto los repositorios

builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioPrestamos, RepositorioPrestamo>();
builder.Services.AddScoped<IRepositorioEquipo, RepositorioEquipo>();
builder.Services.AddScoped<IRepositorioAuditoriaPrestamo, RepositorioAuditoriaPrestamo>();

// Inyecto los casos de uso USUARIO
builder.Services.AddScoped<ICUGetAll<ListarUsuariosDto>, ListarUsuarios>();
builder.Services.AddScoped<ICUAlta<AltaUsuarioDto>, AltaUsuario>();

// Inyecto los casos de uso EQUIPO
builder.Services.AddScoped<ICUAlta<AltaEquipoDto>, AltaEquipo>();
builder.Services.AddScoped<ICUGetAll<ListarEquipoDto>, ListarEquipos>();
builder.Services.AddScoped<ICUGetById<ListarEquipoDto>, ObtenerEquipoPorId>();
builder.Services.AddScoped<ICUDelete<AltaEquipoDto>, BajaEquipo>();
builder.Services.AddScoped<ICUEdit<ListarEquipoDto>, EditarEquipo>();

// Inyecto los casos de uso Prestamo
builder.Services.AddScoped<ICUAlta<AltaPrestamoDto>, AltaPrestamo>();
builder.Services.AddScoped<ICUDelete<Prestamo>, DevolverPrestamo>();

//builder.Services.AddScoped<SeedData>();

//Inyecto el Context de la BD
builder.Services.AddDbContext<StellarMindContext>(
    //option => option.UseSqlServer(builder.Configuration.GetConnectionString("Libreria"))
    );

builder.Services.AddScoped<SeedData>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{
    // Creo un scope para poder usar los servicios que inyecte, en este caso el SeedData, que es el encargado de llenar la base de datos con datos de prueba
    using (var scope = app.Services.CreateScope())
    {
        var seeder = scope.ServiceProvider.GetRequiredService<SeedData>();
        seeder.Run();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();