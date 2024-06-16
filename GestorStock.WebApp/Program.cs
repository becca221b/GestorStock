using Business;
using Configuration;
using DataEF.Repository;

var builder = WebApplication.CreateBuilder(args);

//Se obtiene la cadena de conexión de appsettings.json
var connectionString = builder.Configuration.GetConnectionString("StockConnectionString");

//Se añade al scope de todo el proyecto

 var config = new Config()
{
    ConnectionString = connectionString
};

builder.Services.AddScoped<Config>(p =>
{
    return config;
});
builder.Services.AddScoped<CompraRepository>();
builder.Services.AddScoped<CompraBusinnes>();
builder.Services.AddScoped<VentaRepository>();
builder.Services.AddScoped<VentaBusinnes>();


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
