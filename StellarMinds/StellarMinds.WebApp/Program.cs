using StellarMinds.Infraestructura.InterfacesRepositorio.Usuarios;
using StellarMinds.Infraestructura.ListaMemoria.Usuarios;
using StellarMinds.LogicaAplicacion.CasosUso.Usuarios;
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
builder.Services.AddScoped<IRepositorioSocio, RepositorioSocio>();
builder.Services.AddScoped<IRepositorioAdmin, RepositorioAdministrador>();
builder.Services.AddScoped<IRepositorioCoordinador, RepositorioCoordinador>();

// Inyecto los casos de uso
builder.Services.AddScoped<ICUAlta<AltaSocioDto>, AltaSocio>();
builder.Services.AddScoped<ICUAlta<AltaAdministradorDto>, AltaAdministrador>();
builder.Services.AddScoped<ICUAlta<AltaCoordinadorDto>, AltaCoordinador>();
builder.Services.AddScoped<ICUGetAll<Usuario>, ListarUsuarios>();

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