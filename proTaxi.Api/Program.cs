using Microsoft.EntityFrameworkCore;
using proTaxi.Persistence.Context;
using proTaxi.Persistence.Interfaces;
using proTaxi.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Taxi_Db>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Taxi_Db")));
builder.Services.AddTransient<IRoleRepository, RoleRepository>();
builder.Services.AddTransient<ITaxiRepository, TaxiRepository>();
builder.Services.AddTransient<ITripRepository, TripRepository>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
