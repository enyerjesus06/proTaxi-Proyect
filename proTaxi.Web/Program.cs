using Microsoft.EntityFrameworkCore;
using proTaxi.Persistence.Context;
using proTaxi.Persistence.Interfaces;
using proTaxi.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Taxi_Db>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Taxi_Db")));
builder.Services.AddTransient<IRoleRepository, RoleRepository>();
builder.Services.AddTransient<ITaxiRepository, TaxiRepository>();
builder.Services.AddTransient<ITripRepository, TripRepository>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
