using Microsoft.EntityFrameworkCore;
using Practico3AJAX.Data;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Añadir localización (carpeta Resources para los archivos .resx)
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddDbContext<ProyectoDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Añadir soporte para la localización en las vistas
builder.Services.AddControllersWithViews()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization();

var app = builder.Build();

// Definir las culturas soportadas (en este caso, inglés y español)
var supportedCultures = new[] { new CultureInfo("en"), new CultureInfo("es") };

var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("es"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
};

// Aplicar la configuración de localización
app.UseRequestLocalization(localizationOptions);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Definir las rutas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

