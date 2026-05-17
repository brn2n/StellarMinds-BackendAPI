using StellarMinds.Infraestructura.InterfacesRepositorio.Equipos;
using StellarMinds.Infraestructura.InterfacesRepositorio.Prestamos;
using StellarMinds.Infraestructura.InterfacesRepositorio.Usuarios;
using StellarMinds.Infraestructura.ListaMemoria;
using StellarMinds.Infraestructura.ListaMemoria.Prestamos;
using StellarMinds.LogicaAplicacion.CasosUso.Equipos;
using StellarMinds.LogicaAplicacion.CasosUso.Usuarios;
using StellarMinds.LogicaAplicacion.Dtos.Equipos;
using StellarMinds.LogicaAplicacion.Dtos.Usuarios;
using StellarMinds.LogicaAplicacion.InterfacesLogicaAplicacion;
using StellarMinds.LogicaNegocio.Entidades.Usuarios;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Contenedor de inyeccion de dependencias
// inyecto los repositorios

builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioPrestamos, RepositorioPrestamo>();
builder.Services.AddScoped<IRepositorioEquipo, RepositorioEquipo>();

// Inyecto los casos de uso USUARIO
builder.Services.AddScoped<ICUGetAll<Usuario>, ListarUsuarios>();
builder.Services.AddScoped<ICUAlta<AltaUsuarioDto>, AltaUsuario>();

// Inyecto los casos de uso EQUIPO
builder.Services.AddScoped<ICUAlta<AltaEquipoDto>, AltaEquipo>();
builder.Services.AddScoped<ICUGetAll<ListarEquipoDto>, ListarEquipos>();
builder.Services.AddScoped<ICUGetById<ListarEquipoDto>, ObtenerEquipoPorId>();
builder.Services.AddScoped<ICUDelete<AltaEquipoDto>, BajaEquipo>();
builder.Services.AddScoped<ICUEdit<ListarEquipoDto>, EditarEquipo>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}")
    .WithStaticAssets();

app.Run();