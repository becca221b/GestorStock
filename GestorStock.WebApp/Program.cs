using Business;
using Configuration;
using DataEF;
using DataEF.Repository;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

//Se obtiene la cadena de conexión de appsettings.json
var connectionString = builder.Configuration.GetConnectionString("StockConnectionString");



builder.Services.AddDbContext<GestionStockContext>(options =>
   options.UseSqlServer(connectionString));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
    AddCookie(options =>
    {
        options.LoginPath = "/Acceso/Login";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    });

//Se añade al scope de todo el proyecto
builder.Services.AddScoped<CompraRepository>();
builder.Services.AddScoped<CompraBusinnes>();
builder.Services.AddScoped<VentaRepository>();
builder.Services.AddScoped<VentaBusinnes>();
builder.Services.AddScoped<ProductoBusinnes>();
builder.Services.AddScoped<ProductoRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UsuarioBusinnes>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Acceso}/{action=Login}/{id?}");

app.Run();
